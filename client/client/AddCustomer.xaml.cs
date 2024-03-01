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
using Windows.Networking;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddCustomer : Page
    {
        Service1Client client = new Service1Client();
        List<Cities> citiesList = null;
     List<   ServiceReference4.Customers >c = new   List<   ServiceReference4.Customers >();
      List<  ServiceReference4.Customers> d = new List<ServiceReference4.Customers>();

        public AddCustomer()
        {
            this.InitializeComponent();
            
        }
        
        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Customers));

        }

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            citiesList = await client.GetCitiesListAsync();
            city.ItemsSource = citiesList;
            c = await client.GetCustomersListAsync();
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            ServiceReference4.Customers x = new ServiceReference4.Customers();

            if (Legal.IsNumber(telephon.Text) && firstName.Text.Length > 1 && city.SelectedIndex >-1 && Legal.CheackMail(mail.Text))
            {

                x.code = await client.GetCodeToCustomersAsync();
                x.city = (Cities)(city.SelectedItem);
                x.adress = adress.Text + " ";
                x.name = firstName.Text;
                x.telephone = telephon.Text;
                x.mail = mail.Text;
                x.notes = notes.Text + " ";
                d = c.Where(h => h.name == x.name).ToList();
                if(d.Count == 0)
                {

              
                int y;
                y = await client.AddCustomersAsync(x);

                 if (y > 0)
                 {
                    txtMessage.Text = "הלקוח נוסף בהצלחה";

                    city.SelectedIndex = -1;
                    adress.Text = string.Empty;
                    firstName.Text = string.Empty;
                    telephon.Text = string.Empty;
                    mail.Text = string.Empty;
                    notes.Text = string.Empty;

                 }
                 else
                 {

                    txtMessage.Text = "הלקוח לא נוסף אנא נסה שנית";
                 }
                }
                else
                {
                    txtMessage.Text = "קיים לקוח עם שם זהה נא שנה את השם ";
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
                if (firstName.Text.Length< 1)
                {
                    firstName.Text = "מינימום 2 תווים";
                }

            }
        }

       
    }
}
