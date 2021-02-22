using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelAppExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
        public partial class MainWindow : Window
        {

     
            public string fileName = @"..\..\trips.txt";
            List<Trip> tripList = new List<Trip>();


            public MainWindow()
            {
                InitializeComponent();
                LoadFile();
            }

            private void LvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            btnUpdatetrip.IsEnabled = true;
            btnDeletetrip.IsEnabled = true;

                var selectedItem = lvList.SelectedItem;
                if (selectedItem is Trip)
                    {
                    Trip trip = (Trip)lvList.SelectedItem;
                    txtDestination.Text = trip.Destination;
                    txtName.Text = trip.Name;
                    txtPassport.Text = trip.Passport;
                    dpDepartureDate.Text = trip.Departure.ToString();
                    dpReturnDate.Text = trip.Return.ToString();
                    }
            }

        private void LoadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] myData = line.Split(';');
                        DateTime departureDate;
                        if (!DateTime.TryParse(myData[3], out departureDate))
                        {
                            MessageBox.Show("Input string error. Go to next line...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            continue;
                        }
                        DateTime returnDate;
                        if (!DateTime.TryParse(myData[4], out returnDate))
                        {
                            MessageBox.Show("Input string error. Go to next line...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            continue;
                        }
                        Trip trip = new Trip(myData[0], myData[1], myData[2], departureDate, returnDate);
                        tripList.Add(trip);
                        line = sr.ReadLine();
                    }

                    lvList.ItemsSource = tripList;
                }
            }
            catch (Exception ex) {
                MessageBox.Show( ex.Message);
            }
            }

            private void BtnSaveSelected_Click(object sender, RoutedEventArgs e)
            {
            // Displays a SaveFileDialog so the user can save the file
            // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.Filter = "trip files(*.trips)|*.trips";
                saveFileDialog1.Title = "Save the selected trips in a File";
                if (saveFileDialog1.ShowDialog() == true)
                {
                // //for exporting the selected trip to the .trip extention file
                // List<Trip> tripListSelected = new List<Trip>();
                // Trip trip = new Trip(GrdList.Columns[0].ToString(), GrdList.Columns[1].ToString(), GrdList.Columns[2].ToString(), DateTime.Parse(GrdList.Columns[3].ToString()), DateTime.Parse(GrdList.Columns[4].ToString()));
                // tripListSelected.Add(trip);
                // string allData = "";
                //foreach (Trip trip1 in tripListSelected)
                //{
                //   allData += trip1.ToString() + "\n";
                //}
                //File.WriteAllText(saveFileDialog1.FileName, allData);


                //for exporting all the data to the .trip extention file
                string allData = "";
                foreach (Trip trip1 in tripList)
                {
                    allData += trip1.ToString() + "\n";
                }
                File.WriteAllText(saveFileDialog1.FileName, allData);
            }
            else
                {
                    MessageBox.Show("File error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            private void BtnAddtrip_Click(object sender, RoutedEventArgs e)
            {
                if ((txtDestination.Text == ""))
                {
                    MessageBox.Show("Input string error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if ((txtName.Text == ""))
                {
                    MessageBox.Show("Input string error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if ((txtPassport.Text == ""))
                {
                    MessageBox.Show("Input string error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DateTime? selectedDate = dpDepartureDate.SelectedDate;
                if (selectedDate == null)
                {
                    MessageBox.Show("Choose a date for the trip", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DateTime? selectedDate2 = dpReturnDate.SelectedDate;
                if (selectedDate2 == null)
                {
                    MessageBox.Show("Choose a date for the trip", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            Trip trip = new Trip(txtDestination.Text, txtName.Text, txtPassport.Text, DateTime.Parse(selectedDate.ToString()), DateTime.Parse(selectedDate2.ToString()));
                tripList.Add(trip);
                ResetValue();
            }

            private void BtnDeletetrip_Click(object sender, RoutedEventArgs e)
            {
                if (lvList.SelectedIndex == -1)
                {
                    MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (lvList.SelectedItems.Count > 0)
            {
                var item = lvList.SelectedItems[0];
                //rest of your logic
                Trip tripToBeDeleted = (Trip)(item);

                if (tripToBeDeleted != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure to delete the trip?", "CONFIRMATION", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        tripList.Remove(tripToBeDeleted);
                        ResetValue();
                    }
                }
            }

           

    }

            private void BtnUpdatetrip_Click(object sender, RoutedEventArgs e)
            {
                if (lvList.SelectedIndex == -1)
                {
                    MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
                Trip triptoBeUpdated = (Trip)lvList.SelectedItem;
                triptoBeUpdated.Destination = txtDestination.Text;
                triptoBeUpdated.Name = txtName.Text;
                triptoBeUpdated.Passport = txtPassport.Text;
                triptoBeUpdated.Departure = DateTime.Parse(dpDepartureDate.SelectedDate.Value.ToString());
                triptoBeUpdated.Return= DateTime.Parse(dpReturnDate.SelectedDate.Value.ToString());
                
                ResetValue();
            }

            private void ResetValue()
            {
                lvList.Items.Refresh();
               
                txtDestination.Text = "";
                txtName.Text = "";
                txtPassport.Text = "";
                dpDepartureDate.Text = "";
                dpReturnDate.Text = "";
                lvList.SelectedIndex = -1;
                btnDeletetrip.IsEnabled = false;
                btnUpdatetrip.IsEnabled = false;
            }

            private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                SaveFile();
            }

            private void SaveFile()
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (Trip trip in tripList)
                    {
                        writer.WriteLine(trip.ToDataString());
                    }
                }
            }

    }

    }



