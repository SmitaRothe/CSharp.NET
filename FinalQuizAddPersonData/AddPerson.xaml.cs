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
using System.Windows.Shapes;

namespace FinalQuizAddPersonData
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        private string name;
        private int age;
        public AddPerson()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsValid()) { return; }
            try
            {
                Person p = new Person
                {
                    Name = txtName.Text,
                    Age = int.Parse(txtAge.Text)
                };    
                    Person person = Global.context.people.Add(p);
                    Global.context.SaveChanges();
                    
             }
             catch (SystemException exc)
                {
                    MessageBox.Show(exc.Message);
                }

                ClearInputs();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            }
                
        

        public bool IsFieldsValid()
        {
            if (txtName.Text == "" || txtAge.Text == "")
            {
                MessageBox.Show("All fields must be filled", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }


        public void ClearInputs()
        {
            txtName.Text = "";
            txtAge.Text = "";
        }
    }
}
