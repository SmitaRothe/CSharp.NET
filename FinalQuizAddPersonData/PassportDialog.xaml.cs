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
using System.Windows.Shapes;

namespace FinalQuizAddPersonData
{
    /// <summary>
    /// Interaction logic for PassportDialog.xaml
    /// </summary>
    public partial class PassportDialog : Window
    {
        byte[] currPersonImage;
        int id;
        string name;
        public Person newPerson;

        public PassportDialog(Person person)
        {
            InitializeComponent();
            // person.Name
            if (person != null)
            {
                
                newPerson = person;
                this.id = person.Id;
                lblGetName.Content = newPerson.Name;
            }         
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    currPersonImage = File.ReadAllBytes(dlg.FileName);
                    tbImage.Visibility = Visibility.Hidden;
                    BitmapImage bitmap = Utils.ByteArrayToBitmapImage(currPersonImage); // ex: SystemException
                    imageViewer.Source = bitmap;
                }
                catch (Exception ex) when (ex is SystemException || ex is IOException)
                {
                    MessageBox.Show(ex.Message, "File reading failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        public bool IsFieldsValid()
        {
            if (txtPassportNo.Text == "" )
            {
                MessageBox.Show("All fields must be filled", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (currPersonImage == null)
            {
                MessageBox.Show("Please choose a picture", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
                if (!IsFieldsValid()) { return; }
                try
                {
                Passport p = new Passport
                {
                    Id = id,
                    Name = lblGetName.Content.ToString(),
                    PassportNo = txtPassportNo.Text,
                   Photo=currPersonImage         
                 };

                Passport passport = Global.context.passports.Add(p);
                Global.context.SaveChanges();
                ClearInputs();
                }
                catch (SystemException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        public void ClearInputs()
        {
            txtPassportNo.Text = "";
            lblGetName.Content = "";
            currPersonImage = null;
        }

    }
    }

