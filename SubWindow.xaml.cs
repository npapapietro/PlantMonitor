using System;
using System.Windows;
using System.Windows.Controls;

namespace PlantMonitor
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        private PlantObj Plant;

        private enum EditSelector
        {
            Select_None,
            Select_Name,
            Select_Size
        }
       
        private EditSelector currentSelected;

        public SubWindow(PlantObj currentPlant)
        {
            Plant = currentPlant;
            InitializeComponent();
            populate();
            currentSelected = EditSelector.Select_None;

        }

        private void populate()
        {
            NameChange.Text = Plant.Name;

            if(Plant.moved[0]!=DateTime.MinValue)
            {
                DateCreated.SelectedDate = Plant.moved[0];
            }

            BucketSizeDisplay.Text = Plant.getsize();

            LogBook.ItemsSource = Plant.cuts;
        }

        /*
        * Buttons * 
        */

        private void DataGridAddRow(object sender, RoutedEventArgs e)
        {
            Plant.cuts.Add(new CutDetails { Date=DateTime.Now,Usable=0,Total=0,Notes=string.Empty });
        }

        private void DatGridRemoveRow(object sender, RoutedEventArgs e)
        {
            if(Plant.cuts.Count>=1)
            {
                Plant.cuts.RemoveAt(Plant.cuts.Count-1);
            }
            
        }

        private void EditName(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
            currentSelected = EditSelector.Select_Name;
            EditPromptBlock.Text = "Edit Name";
            EditPromptComboBox.Visibility = System.Windows.Visibility.Collapsed;
            EditPromptBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void EditSize(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
            currentSelected = EditSelector.Select_Size;
            EditPromptBlock.Text = "Edit Size";
            EditPromptBox.Visibility = System.Windows.Visibility.Collapsed;
            EditPromptComboBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // YesButton Clicked! Let's hide our InputBox and handle the input text.

            InputBox.Visibility = System.Windows.Visibility.Collapsed;
            
            
            // Do something with the Input


            switch (currentSelected)
            {
                case EditSelector.Select_Name:
                    {
                        String input = EditPromptBox.Text;
                        Plant.Name = input;
                        NameChange.Text = Plant.Name;
                        break;
                    }
                case EditSelector.Select_Size:
                    {
                        ComboBoxItem choiceItem = (ComboBoxItem)EditPromptComboBox.SelectedItem;
                        String choice = choiceItem.Content.ToString();
                        BucketSizeDisplay.Text = choice;
                        if (choice == "3 gallons" && Plant.moved[1]==DateTime.MinValue)
                        {
                            Plant.moved[1] = DateTime.Now;
                            Plant.currentsize = PlantObj.BucketSize.threegal;
                           
                        }
                        else if(choice == "7 gallons" && Plant.moved[2] == DateTime.MinValue)
                        {
                            Plant.moved[2] = DateTime.Now;
                            Plant.currentsize = PlantObj.BucketSize.sevengal;
                        }
                        break;
                    }
                    

                default:
                    break;
            }           

            // Clear InputBox.
            EditPromptBox.Text = String.Empty;
            EditPromptBlock.Text = String.Empty;
            currentSelected = EditSelector.Select_None;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            // NoButton Clicked! Let's hide our InputBox.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Clear InputBox.
            EditPromptBox.Text = String.Empty;
        }

        private void SetDateTime(object sender, RoutedEventArgs e)
        {
            //Set Initial Date
            if (Plant.moved[0]==DateTime.MinValue)
            {
                DatePicker date = DateCreated;
                if (date.ToString() == string.Empty)
                {
                    Plant.moved[0] = DateTime.Now;
                }
                else
                {
                    Plant.moved[0] = (DateTime)date.SelectedDate + DateTime.Now.TimeOfDay;
                }
                //Display it
                date.SelectedDate = Plant.moved[0];
            }       

            //If not initalized
            if (Plant.currentsize == PlantObj.BucketSize.nogal)
            {
                Plant.currentsize = PlantObj.BucketSize.onegal;
                BucketSizeDisplay.Text = "1 gallon";
            }
            
        }

        //Return Plant
        public PlantObj changed_PlantObj
        {
            get
            {
                return Plant;
            }
        }
        
    }

}
