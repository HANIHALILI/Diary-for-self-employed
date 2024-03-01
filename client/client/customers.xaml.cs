using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using client.ServiceReference4;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customers : Page
    {
        
        Service1Client client1 = new Service1Client();
        List<ServiceReference4.Customers> customers = null;
        public Customers()
        {
            this.InitializeComponent();
        }

        private void addCustomer(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddCustomer));

        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            //load the customers list
           customers = await client1.GetCustomersListAsync();
            lstCustomers.ItemsSource = customers;
            
            //load the cities list
            city.ItemsSource = await client1.GetCitiesListAsync();
            city.SelectedIndex = -1;
            lstCustomers.SelectedIndex = -1;

        }
        private void lstCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtMessage.Text = " ";
            if (lstCustomers.SelectedIndex > -1)
            {
            //put the detail in the boxes
                scroll.Tag = lstCustomers.SelectedItem;
            detailsPop.IsOpen = true;     
            txtTitle.Text = "פרטי לקוח";
            firstName.Text = (scroll.Tag as ServiceReference4.Customers).name;
            adress.Text = (scroll.Tag as ServiceReference4.Customers).adress;
            telephon.Text = (scroll.Tag as ServiceReference4.Customers).telephone;
            mail.Text = (scroll.Tag as ServiceReference4.Customers).mail;
            cityTxt.Visibility = Visibility.Visible;
            cityTxt.PlaceholderText = (scroll.Tag as ServiceReference4.Customers).city.nameCity;
            city.Visibility = Visibility.Collapsed; 
            notes.Text = (scroll.Tag as ServiceReference4.Customers).notes;

            //close the boxes
            firstName.IsReadOnly = true;
            adress.IsReadOnly = true;
            telephon.IsReadOnly = true;
            mail.IsReadOnly = true;
            cityTxt.IsReadOnly = true;
            notes.IsReadOnly = true;

            btnUpDate.Visibility = Visibility.Collapsed;

            CPage.Opacity = 0.5;
            }
               
            
        }
        private void closeDetailsPop(object sender, RoutedEventArgs e)
        {
            detailsPop.IsOpen = false;
            CPage.Opacity = 1;
            lstCustomers.SelectedIndex = -1;

        }

        private void OpenUpdatePop(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = " ";
            if (((sender as Button).Parent as StackPanel).Tag.ToString() == "out")
            {
                scroll.Tag = ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag);
                detailsPop.IsOpen = true;
                //put the detail in the boxes
                txtTitle.Text = "עדכן פרטי לקוח";
             
                detailsPop.IsOpen = true;
           


                firstName.Text = (scroll.Tag as ServiceReference4.Customers).name;
                adress.Text = (scroll.Tag as ServiceReference4.Customers).adress;
                telephon.Text = (scroll.Tag as ServiceReference4.Customers).telephone;
                mail.Text = (scroll.Tag as ServiceReference4.Customers).mail;
                city.PlaceholderText = ( (scroll.Tag as ServiceReference4.Customers).city.nameCity);
                notes.Text = (scroll.Tag as ServiceReference4.Customers).notes;
                btnUpDate.Visibility = Visibility.Visible;
                city.Visibility = Visibility.Visible;
                cityTxt.Visibility = Visibility.Collapsed;

                //close the boxes
                firstName.IsReadOnly = false;
                adress.IsReadOnly = false;
                telephon.IsReadOnly = false;
                mail.IsReadOnly = false;
                city.IsEnabled = true;
                notes.IsReadOnly = false;

                CPage.Opacity = 0.5;
            }
            if (lstCustomers.SelectedIndex > -1)
            {
                //put the detail in the boxes
                txtTitle.Text = "עדכן פרטי לקוח";
                scroll.Tag = lstCustomers.SelectedItem;
                detailsPop.IsOpen = true;
                firstName.Text = (scroll.Tag as ServiceReference4.Customers).name;
                adress.Text = (scroll.Tag as ServiceReference4.Customers).adress;
                telephon.Text = (scroll.Tag as ServiceReference4.Customers).telephone;
                mail.Text = (scroll.Tag as ServiceReference4.Customers).mail;
                city.PlaceholderText = (scroll.Tag as ServiceReference4.Customers).city.nameCity;
                notes.Text = (scroll.Tag as ServiceReference4.Customers).notes;
                btnUpDate.Visibility = Visibility.Visible;
                city.Visibility = Visibility.Visible;
                cityTxt.Visibility = Visibility.Collapsed;

                //open the boxes
                firstName.IsReadOnly = false;
                adress.IsReadOnly = false;
                telephon.IsReadOnly = false;
                mail.IsReadOnly = false;
                city.IsEnabled = true;
                notes.IsReadOnly = false;

                CPage.Opacity = 0.5;
            }
        }
        private async void updateC(object sender, RoutedEventArgs e)
        {
            //ServiceReference4.Customers c = (ServiceReference4.Customers)(lstCustomers.SelectedItem);
            //c.adress = adress.Text + " ";
            //c.name = firstName.Text;
            //c.telephone = telephon.Text;
            //c.mail =  mail.Text ;
            //c.city = (ServiceReference4.Cities)(city.SelectedItem);
            //c.notes = notes.Text + " ";
            //await client1.UpdateCustomersAsync(c);
           

            if (Legal.IsNumber(telephon.Text) && firstName.Text.Length > 1 && city.SelectedIndex > -1 && Legal.CheackMail(mail.Text))
            {
                ServiceReference4.Customers c = scroll.Tag as ServiceReference4.Customers;
                //if (((sender as Button).Parent as StackPanel).Tag.ToString() == "out")
                //{
                //    c = ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag) as ServiceReference4.Customers;
                //}
                //else
                //{
                //    c = (ServiceReference4.Customers)(lstCustomers.SelectedItem);

                //}
                c.adress = adress.Text + " ";
                c.name = firstName.Text;
                c.telephone = telephon.Text;
                c.mail = mail.Text;
                c.city = (ServiceReference4.Cities)(city.SelectedItem);
                c.notes = notes.Text + " ";
                int y = await client1.UpdateCustomersAsync(c);

                if (y > 0)
                {
                    txtMessage.Text = "הלקוח עודכן בהצלחה";

                    //city.SelectedIndex = -1;
                    //adress.Text = string.Empty;
                    //firstName.Text = string.Empty;
                    //telephon.Text = string.Empty;
                    //mail.Text = string.Empty;
                    //notes.Text = string.Empty;

                }
                else
                {

                    txtMessage.Text = "הלקוח לא עודכן אנא נסה שנית";
                }
            }
            else
            {
                if (Legal.IsNumber(telephon.Text) == false)
                {
                    telephon.Text = "יש לכתוב מספרים בלבד";
                }
                if (Legal.CheackMail(mail.Text) == false)
                {
                    mail.Text = "יש לכתוב כתובת מייל תקינה";
                }

                if (city.SelectedIndex < 0)
                {
                    city.PlaceholderText = "חובה לבחור עיר";
                }
                if (firstName.Text.Length < 1)
                {
                    firstName.Text = "מינימום 2 תווים";
                }

            }
            VV();
        }

        //delets functions
        private void OpendeletePop(object sender, RoutedEventArgs e)
        {
            deletePop.IsOpen = true;

        }
        private async void deleteC(object sender, RoutedEventArgs e)
        {
            //delete  customer
            ServiceReference4.Customers c = (ServiceReference4.Customers)(lstCustomers.SelectedItem);
         int f =   await client1.DeleteCustomersAsync(c);
            if (f > 0)
            {
                txtMessage1.Text = "המחיקה בוצעה בהצלחה";
            }
            else
            {
                txtMessage1.Text = "המחיקה לא בוצעה נא נסה שנית";
            }
            deletePop.IsOpen = false;
        }

        private void closeDPop(object sender, RoutedEventArgs e)
        {
            deletePop.IsOpen = false;
           // lstCustomers.SelectedIndex = -1;
        }

        private void find_TextChanged(object sender, TextChangedEventArgs e)
        {

            List<ServiceReference4.Customers> list = new List<ServiceReference4.Customers>();
            list = customers.Where(p => $"{p.name}{p.adress}{p.telephone}{p.city.nameCity}{p.mail}{p.notes}".Contains(find.Text)).ToList();
            lstCustomers.ItemsSource = list;
        }
        private void VV()
        {
            firstName.Text = (scroll.Tag as ServiceReference4.Customers).name;
            adress.Text = (scroll.Tag as ServiceReference4.Customers).adress;
            telephon.Text = (scroll.Tag as ServiceReference4.Customers).telephone;
            mail.Text = (scroll.Tag as ServiceReference4.Customers).mail;
            cityTxt.Visibility = Visibility.Visible;
            cityTxt.PlaceholderText = (scroll.Tag as ServiceReference4.Customers).city.nameCity;
            city.Visibility = Visibility.Collapsed;
            notes.Text = (scroll.Tag as ServiceReference4.Customers).notes;

            //close the boxes
            firstName.IsReadOnly = true;
            adress.IsReadOnly = true;
            telephon.IsReadOnly = true;
            mail.IsReadOnly = true;
            cityTxt.IsReadOnly = true;
            notes.IsReadOnly = true;

            btnUpDate.Visibility = Visibility.Collapsed;

            CPage.Opacity = 0.5;
        }
    }
}
