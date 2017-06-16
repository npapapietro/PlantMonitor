using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;


namespace PlantMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum LayoutActions
        {
            Remove_Obj,
            Manage_Obj
        }

        private class MyTuple
        {
            public string Key { get; set; }
            public int Value { get; set; }
            public MyTuple(string n, int x)
            {
                Key = n;
                Value = x;
            }
        }

        private LayoutActions currSelect;

        private int rwidth = 32, rheight = 32, gapmult = 5;

        static private int row_count = 0, col_count = 0;

        private List<PlantObj> plantlist { get; set; }

        private ObservableCollection<MyTuple> name_list { get; set; }

        public MainWindow()
        {
            InitializeComponent();                       
            INIT();
        }
   

        /// <summary>
        /// Main Window's Buttons
        /// </summary>

        private void Remove_Obj_Click(object sender, RoutedEventArgs e)
        {
            currSelect = LayoutActions.Remove_Obj;
        }

        private void Manage_Obj_Click(object sender, RoutedEventArgs e)
        {
            currSelect = LayoutActions.Manage_Obj;
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            
            for (int k = 0; k < row_count; k++)
            {
                double[] ecorner = place_ellipse(k, col_count);
                double[] tcorner = place_textblock(k, col_count);

                PlantObj newCirc = new PlantObj(null, k, col_count);
                plantlist.Add(newCirc);
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    Canvas.SetLeft(newCirc.tobj, tcorner[0] - newCirc.tobj.ActualWidth / 2.0);
                    Canvas.SetTop(newCirc.tobj, tcorner[1] - newCirc.tobj.ActualHeight / 2.0);

                }));

                Canvas.SetLeft(newCirc.cobj, ecorner[0]);
                Canvas.SetTop(newCirc.cobj, ecorner[1]);

                MyCanvas.Children.Add(newCirc.cobj);
                MyCanvas.Children.Add(newCirc.tobj);
            }
            col_count++;
            MyCanvas.Height += rheight + gapmult * 1;
            updateOverviewGrid();
        }
        
        private void AddCol_Click(object sender, RoutedEventArgs e)
        {
            for (int k = 0; k < col_count; k++)
            {
                double[] ecorner = place_ellipse(row_count, k);
                double[] tcorner = place_textblock(row_count, k);

                PlantObj newCirc = new PlantObj(null, row_count, k);
                plantlist.Add(newCirc);
                MyCanvas.UpdateLayout();

                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    Canvas.SetLeft(newCirc.tobj, tcorner[0] - newCirc.tobj.ActualWidth / 2.0);
                    Canvas.SetTop(newCirc.tobj, tcorner[1] - newCirc.tobj.ActualHeight / 2.0);

                }));        
                
                Canvas.SetLeft(newCirc.cobj, ecorner[0]);
                Canvas.SetTop(newCirc.cobj, ecorner[1]);

                MyCanvas.Children.Add(newCirc.cobj);
                MyCanvas.Children.Add(newCirc.tobj);
            }
            row_count++;
            MyCanvas.Width += rwidth +  gapmult;
            updateOverviewGrid();
        }
           
        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
            start = e.GetPosition(this);
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (currSelect)
            {
                case LayoutActions.Remove_Obj:
                    break;

                case LayoutActions.Manage_Obj:
                    {
                        int index = -1;
                        string originalName;
                        if (e.OriginalSource is Ellipse)
                        {
                            Ellipse ClickedEllipse = (Ellipse)e.OriginalSource;
                            originalName = ClickedEllipse.Uid;
                            index = findIndex(originalName);

                        }

                        else if (e.OriginalSource is TextBlock)
                        {
                            TextBlock ClickedTB = (TextBlock)e.OriginalSource;
                            originalName = ClickedTB.Uid;
                            index = findIndex(originalName);
                        }

                        else return;

                        if (index != -1)
                        {
                            managePlant(index);
                        }

                        break;
                    }
                default:
                    return;
            }
        }

        Point start, end;

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            string jsonload;

            dlg.Filter = "JSON documents (.json)|*.json";

            if (dlg.ShowDialog() == true)
            {
                jsonload = File.ReadAllText(dlg.FileName);
            }
            else return;

            plantlist.Clear();
            row_count *= 0; col_count *= 0;
            MyCanvas.Children.Clear();

            var x = JsonConvert.DeserializeObject<List<PlantObj>>(jsonload);

            plantlist = x;

            plantIterator();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            var jsonsave = JsonConvert.SerializeObject(plantlist);

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Untitled";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON documents (.json)|*.json";

            if(dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, jsonsave);
            }

            
        }
        
        private void MyCanvas_ZoomMWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                var st = new ScaleTransform();
                double zoom = e.Delta > 0 ? .3 : -.3;
                st.ScaleX += zoom;
                st.ScaleY += zoom;
                MyCanvas.RenderTransform = st;
            }
        }

        private void editDetails_Closed(object sender, EventArgs e)
        {
            SubWindow win = (SubWindow)sender;
            win.changed_PlantObj.updateCanvasObjs();
            PlantObj updatedPlant = win.changed_PlantObj;
            plantlist.Add(updatedPlant);

            for (int t = MyCanvas.Children.Count - 1; t >= 0; t--)
            {
                if (MyCanvas.Children[t].Uid == updatedPlant.get_internalID && MyCanvas.Children[t] is Ellipse)
                {                    
                    MyCanvas.Children[t] = updatedPlant.cobj;
                }
                else if (MyCanvas.Children[t].Uid == updatedPlant.get_internalID && MyCanvas.Children[t] is TextBlock)
                {
                    TextBlock temp = (TextBlock)MyCanvas.Children[t];
                    double oldleft = Canvas.GetLeft(MyCanvas.Children[t]) + temp.ActualWidth/2.0;
                    
                    Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                    {                        
                        Canvas.SetLeft(updatedPlant.tobj, oldleft - updatedPlant.tobj.ActualWidth/2.0);
                    }));
                    MyCanvas.Children[t] = updatedPlant.tobj;
                }
            }

            updateOverviewGrid();
            MyCanvas.UpdateLayout();
        }

        /// <summary>
        /// Helper functions
        /// </summary>

        private void INIT()
        {
            plantlist = new List<PlantObj>();

            PlantObj newCirc = new PlantObj(null, row_count, col_count);

            plantlist.Add(newCirc);

            double[] ecorner = place_ellipse(0, 0);
            double[] tcorner = place_textblock(0, 0);

            Loaded += delegate
            {
                Canvas.SetLeft(newCirc.tobj, tcorner[0] - newCirc.tobj.ActualWidth / 2.0);
                Canvas.SetTop(newCirc.tobj, tcorner[1] - newCirc.tobj.ActualHeight / 2.0);
            };

            Canvas.SetLeft(newCirc.cobj, ecorner[0]);
            Canvas.SetTop(newCirc.cobj, ecorner[1]);

            MyCanvas.Children.Add(newCirc.cobj);
            MyCanvas.Children.Add(newCirc.tobj);

            row_count++;
            col_count++;

            updateOverviewGrid();      
        }

        private double[] canvas_point(int i, int j)
        {
            return new double[] { i * (gapmult + rwidth)  + rwidth / 1.0,
                    j * (gapmult * 5 + rheight / 2.0) + rheight / 1.0 };
        }

        private double[] place_ellipse(int i, int j)
        {
            double[] corner = canvas_point(i, j);
            return new double[] { corner[0] - rwidth / 2.0, corner[1] - rheight / 2.0 };
        }

        private double[] place_textblock(int i, int j)
        {
            double[] corner = canvas_point(i, j);
            return new double[] { corner[0], corner[1] };
        }

        private void managePlant(int index)
        {
            //Send details to SubWindow
            SubWindow editDetails = new SubWindow(plantlist[index]);

            //Remove old one from List
            plantlist.Remove(plantlist[index]);

            //Add owner and close event
            editDetails.Owner = Application.Current.MainWindow;
            editDetails.Closed += new EventHandler(editDetails_Closed);
            editDetails.Show();
        }

        private int findIndex(string nameID)
        {
            for (int i = 0; i < plantlist.Count; i++)
            {
                if (plantlist[i].identify(nameID))
                {
                    return i;
                }
            }
            return -1;
        }

        private void updateOverviewGrid()
        {
            
            var localdict = new SortedDictionary<string, int>();
            var localist = new ObservableCollection<MyTuple>();
            
            foreach (PlantObj plant in plantlist)
            {
                
                if (!localdict.ContainsKey(plant.Name))
                {
                    localdict.Add(plant.Name,1);                    
                }
                else
                {
                    localdict[plant.Name]++;
                }
            }

            foreach(KeyValuePair<string,int> item in localdict)
            {
                localist.Add(new MyTuple(item.Key, item.Value));
            }
            name_list = localist;
            OverviewGrid.ItemsSource = name_list;
            
        }

        #region Load file

        private void canvasPlacer(object obj, int m, int n)
        {
            if (obj is Ellipse)
            {
                Ellipse obj_e = (Ellipse)obj;
                double[] ecorner = place_ellipse(m, n);
                Canvas.SetLeft(obj_e, ecorner[0]);
                Canvas.SetTop(obj_e, ecorner[1]);
                MyCanvas.Children.Add(obj_e);
            }
            
            if(obj is TextBlock)
            {
                TextBlock obj_t = (TextBlock)obj;
                double[] tcorner = place_textblock(m, n);
                MyCanvas.Children.Add(obj_t);
                obj_t.Loaded += delegate
                {
                    Canvas.SetLeft(obj_t, tcorner[0] - obj_t.ActualWidth / 2.0);
                    Canvas.SetTop(obj_t, tcorner[1] - obj_t.ActualHeight / 2.0);
                    
                };
            }
        }

        private void plantIterator()
        {
            foreach (PlantObj plant in plantlist)
            {
                int m = plant.my_position[0], n = plant.my_position[1];

                canvasPlacer(plant.cobj, m, n);
                canvasPlacer(plant.tobj, m, n);
                if (m > row_count)
                {
                    row_count = m;
                }
                if (n > col_count)
                {
                    col_count = n;
                }
                
            }

            MyCanvas.Height =  col_count * (gapmult + rwidth) + 62;
            MyCanvas.Width = row_count * (gapmult + rheight) + 62;

        }
        #endregion

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
   
}
