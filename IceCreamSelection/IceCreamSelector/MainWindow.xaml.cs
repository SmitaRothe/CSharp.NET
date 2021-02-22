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

namespace IceCreamSelector
{

    //test by smita

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> SelectedOnes = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            const string dataFile = @"..\..\available.txt";
            if (File.Exists(dataFile))
            {
                List<string> flavorsList = new List<string>();
                foreach(string line in File.ReadAllLines(dataFile))
                {
                    flavorsList.Add(line);
                }
                lvIceCreamFlavors.ItemsSource = flavorsList;
            }
        }

        private void BtnDeleteScoop_Click(object sender, RoutedEventArgs e)
        {
            if (lvSelectedFlavors.Items.Count == 0)
            {
                return;
            }
            if (lvSelectedFlavors.SelectedIndex == -1)
            {
                MessageBox.Show("please choose a scoop");
            }
            var selectedForDelete = lvSelectedFlavors.SelectedItems;
            //do a loop into selectedForDelete and remove them from the selected ones
            foreach(string item in selectedForDelete)
            {
                SelectedOnes.Remove(item);
            }
            lvSelectedFlavors.ItemsSource = null;
            lvSelectedFlavors.ItemsSource = SelectedOnes;
        }


        private void btnAddFlavors_Click(object sender, RoutedEventArgs e)
        {
            var selectedList = lvIceCreamFlavors.SelectedItems;
            
            foreach(string item in selectedList)
            {
                //is having list of selected items
                SelectedOnes.Add(item);

            }
            lvSelectedFlavors.ItemsSource = null;
            lvSelectedFlavors.ItemsSource = SelectedOnes;
            lvIceCreamFlavors.SelectedIndex = -1;
        }

        private void btnClearFlavors_Click(object sender, RoutedEventArgs e)
        {
            //add validation if you already selected or not
            //if you want some flavors you want to empty the itemsource
            if (lvSelectedFlavors.Items.Count == 0)
            {
                return;
            }
            //confirmation
            MessageBoxResult result=MessageBox.Show("Are you sure to delete the list", "Clear All", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                lvSelectedFlavors.ItemsSource = null;
            }
            SelectedOnes.Clear();
        }
    }
}
