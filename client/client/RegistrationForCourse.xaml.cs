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
using System.Text.RegularExpressions;
using Windows.UI;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace client
{

    public sealed partial class RegistrationForCourse : Page
    {
        ServiceReference4.Service1Client client = new ServiceReference4.Service1Client();
        List<string> howtopay = new List<string>();
        public RegistrationForCourse()
        {
            this.InitializeComponent();
        }



        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registration));

        }
     

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private async void Registration(object sender, RoutedEventArgs e)
        {

            ServiceReference4.RegistrationForCourse rf = new ServiceReference4.RegistrationForCourse();

            if (Legal.IsNumber(amountPaid.Text)&& courseCombo.SelectedIndex >-1 && customer.SelectedIndex > -1 && howToPay.SelectedIndex > -1 && Legal.IsNumber(price.Text))
            {
                rf.price  = Convert.ToInt32(price.Text);
                rf.amountPaid = Convert.ToInt32(amountPaid.Text);
                rf.course = (ServiceReference4.Course)(courseCombo.SelectedItem);
                rf.customer = (ServiceReference4.Customers)(customer.SelectedItem);
                rf.paymentMethod = howtopay[howToPay.SelectedIndex];
                rf.notes = notes.Text + " ";
                int z;
                z = await client.AddPersonToCourseAsync(rf);
                if (z > 0)
                {
                txtMessage.Text = "ההרשמה בוצעה בהצלחה";

                    //ריקון הבוקסים פלייסהולדר
                    courseCombo.SelectedIndex = -1;
                    customer.SelectedIndex = -1;
                    howToPay.SelectedIndex = -1;
                    amountPaid.Text = string.Empty;
                    price.Text = string.Empty;
                    notes.Text = string.Empty;

                }
                else
                {
                 txtMessage.Text = "ההרשמה לא התבצעה נא נסה שנית";
                }

                
            }
            else
            {
                if (Legal.IsNumber(amountPaid.Text) == false)
                {
                    amountPaid.Text = "יש לכתוב מספרים בלבד";
                }
                
                if (courseCombo.SelectedIndex < 0)
                {
                    courseCombo.PlaceholderText = "חובה לבחור סדנה";
                }
                if (courseCombo.SelectedIndex < 0)
                {
                    customer.PlaceholderText = "חובה לבחור לקוח";
                }
                if (howToPay.SelectedIndex < 0)
                {
                    howToPay.PlaceholderText = "חובה לבחור צורת תשלום";
                }

               
            }

           

        }

        
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            //load the registrationForCourse list
          

            //load the course list
            List<ServiceReference4.Course> c = await client.GetCourseListAsync();
            courseCombo.ItemsSource = c.Where(p => p.status.Contains("בהרשמה")).ToList();

            //load the customers list
            customer.ItemsSource = await client.GetCustomersListAsync();

            howtopay.Add("מזומן");
            howtopay.Add("אשראי");
            howtopay.Add("העברה");
            howtopay.Add("הוראת קבע");

            howToPay.ItemsSource = howtopay;



        }

        private void courseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(courseCombo.SelectedIndex>-1)
              price.Text = (courseCombo.SelectedItem as ServiceReference4.Course).price.ToString();

        }

        private void Courses(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Course));

        }
    }
}   

