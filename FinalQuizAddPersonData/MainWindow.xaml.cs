using System;
using System.Collections.Generic;
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

namespace FinalQuizAddPersonData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public Person newPerson;
        
        public MainWindow()
        {
            InitializeComponent();
 
            try
            {
                Global.context = new PersonDBContext();
                FetchRecord();
            }
            catch (SystemException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //private void LoadData()
        //{
        //    List<Person> personList = Global.context.people.ToList<Person>();
        //    LvPersonDialog.ItemsSource = personList;
        //    LvPersonDialog.Items.Refresh();
        //}

       
        private void FetchRecord()
        {
            LvPersonDialog.ItemsSource = Global.context.people.ToList();
        }
       
        //private void LvPersonDialog_MouseDoubleClick(object sender, SelectionChangedEventArgs e)
        //{
        //    Person newPerson = (Person)LvPersonDialog.SelectedItem;
        //    PassportDialog passportDialog = new PassportDialog(newPerson);
        //    passportDialog.ShowDialog();
        //}

        private void Window_Activated(object sender, EventArgs e)
        {        
            FetchRecord();
        }
 
        private void LvPersonDialog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person newPerson = (Person)LvPersonDialog.SelectedItem;
            PassportDialog passportDialog = new PassportDialog(newPerson);
            passportDialog.ShowDialog();
        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPerson addPerson = new AddPerson();
            //addPerson.ShowDialog();
            addPerson.Owner = this;
            addPerson.Show();
        }
    }
}
