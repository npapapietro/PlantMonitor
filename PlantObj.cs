using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PlantMonitor
{
    [JsonConverter(typeof(PlantObjSerializer))]
    public class PlantObj : IEquatable<PlantObj>
    {
        #region Initialize
        private void INIT()
        {
            cuts = new ObservableCollection<CutDetails>{ new CutDetails { Date = DateTime.Now, Usable = 0, Total = 0, Notes = "Initial, change me" }};

            moved = new DateTime[3];

            internalID = Guid.NewGuid().ToString();

            initShapes();

            currentsize = BucketSize.nogal;
        }

        private void initShapes()
        {
            plant_ellipse = new Ellipse()
            {
                Stroke = Brushes.Orange,
                Fill = Brushes.Red,
                StrokeThickness = 9,
                Width = radius,
                Height = radius,
                Uid = internalID
            };

            plant_textblock = new TextBlock()
            {
                Foreground = Brushes.Black,
                FontSize = 8,
                Uid = internalID,
                Text = Name
            };
        }

        static private int radius = 32;

        private Ellipse plant_ellipse;

        private TextBlock plant_textblock;

        private string internalID;

        #endregion
        
        public PlantObj(string name, int row, int col)
        {
            my_position = new int[] { row, col };

            if (name == null)
            {
                Name = "temp";
            }
            else
            {
                Name = name;
            }

            INIT();

        }

        public PlantObj() { }

        public string Name { get; set; }

        /// <summary>
        /// Stores the dates when changing bucketsize
        /// </summary>
        public DateTime[] moved { get; set; }

        public ObservableCollection<CutDetails> cuts { get; set; }

        public enum BucketSize
        {
            nogal,
            onegal,
            threegal,
            sevengal
        }

        public BucketSize currentsize { get; set; }

        public int[] my_position { get; set; }

        public Ellipse cobj
        {
            get
            {
                return plant_ellipse;
            }
        }

        public TextBlock tobj
        {
            get
            {
                return plant_textblock;
            }
        }

        public bool identify(string name)
        {
            if (name == internalID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string get_internalID
        {
            get
            {
                return internalID;
            }
            set
            {
                internalID = value;
            }
        }

        public string getsize()
        {
            if (currentsize == BucketSize.nogal)
                return "0 gallons";
            else if (currentsize == BucketSize.onegal)
                return "1 gallon";
            else if (currentsize == BucketSize.threegal)
                return "3 gallons";
            else if (currentsize == BucketSize.sevengal)
                return "7 gallon";
            else
                return "No Size Set";
        }

        public void updateCanvasObjs()
        {
            if (moved[0] != DateTime.MinValue)
            {
                plant_ellipse.Fill = Brushes.Green;
            }

            if (currentsize == BucketSize.onegal)
            {
                plant_ellipse.StrokeThickness = 9;
            }
            else if (currentsize == BucketSize.threegal)
            {
                plant_ellipse.StrokeThickness = 5;
            }
            else if (currentsize == BucketSize.sevengal)
            {
                plant_ellipse.StrokeThickness = 3;
            }

            plant_textblock.Text = Name;
        }

        public void loadPlantObj()
        {
            initShapes();
        }

        #region Equality
        public bool Equals(PlantObj p)
        {
            if (p == null)
            {
                return false;
            }

            return Name.Equals(p.Name) &&
                moved.SequenceEqual(p.moved) &&
                currentsize.Equals(p.currentsize) &&
                my_position.SequenceEqual(p.my_position) &&
                string.Equals(get_internalID, p.get_internalID) &&
                cuts.SequenceEqual(p.cuts);
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            PlantObj p = obj as PlantObj;
            if(p == null )
            {
                return false;
            }

            return Name.Equals(p.Name) &&
                moved.SequenceEqual(p.moved) &&
                currentsize.Equals(p.currentsize) &&
                my_position.SequenceEqual(p.my_position) &&
                string.Equals(get_internalID, p.get_internalID) &&
                cuts.SequenceEqual(p.cuts);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
            /*
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + moved.GetHashCode();
                hash = hash * 23 + currentsize.GetHashCode();
                hash = hash * 23 + my_position.GetHashCode();
                hash = hash * 23 + tobj.GetHashCode();
                hash = hash * 23 + cobj.GetHashCode();
                hash = hash * 23 + cuts.GetHashCode();
                return hash;
            }
            */
        }

        public static bool operator ==(PlantObj lhs, PlantObj rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }
            if (ReferenceEquals(lhs, null))
            {
                return false;
            }
            if (ReferenceEquals(rhs, null))
            {
                return false;
            }

            return lhs.Name == rhs.Name &&
                lhs.moved.SequenceEqual(rhs.moved) &&
                lhs.currentsize == rhs.currentsize &&
                lhs.my_position.SequenceEqual(rhs.my_position) &&
                string.Equals(lhs.get_internalID, rhs.get_internalID) &&
                lhs.cuts.SequenceEqual(rhs.cuts);
        }

        public static bool operator !=(PlantObj lhs, PlantObj rhs)
        {
            return !(lhs == rhs);
        }

        #endregion
    }

    public class CutDetails : IEquatable<CutDetails>
    {
        public DateTime Date { get; set; }

        public double Total { get; set; }

        public double Usable { get; set; }

        public string Notes { get; set; }

        #region Equality

        public static bool operator ==(CutDetails lhs, CutDetails rhs)
        {
            if (ReferenceEquals(lhs,rhs))
            {
                return true;
            }
            if (ReferenceEquals(lhs, null))
            {
                return false;
            }
            if (ReferenceEquals(rhs, null))
            {
                return false;
            }

            return lhs.Date == rhs.Date &&
                lhs.Notes == rhs.Notes &&
                lhs.Usable == rhs.Usable &&
                lhs.Total == rhs.Total;
        }

        public static bool operator !=(CutDetails lhs, CutDetails rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj){

            if (ReferenceEquals(obj,null))
            {
                return false;
            }

            
            if (ReferenceEquals(this,obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((CutDetails)obj);
        }

        public bool Equals(CutDetails other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Date.Equals(other.Date) &&
                string.Equals(Notes, other.Notes) &&
                Usable.Equals(other.Usable) &&
                Total.Equals(other.Total);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Date.GetHashCode();
                hash = hash * 23 + Usable.GetHashCode();
                hash = hash * 23 + Total.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}