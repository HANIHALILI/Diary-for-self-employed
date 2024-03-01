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
    public sealed partial class RegistrationForPersonalMeeting : Page
    {
        ServiceReference4.Service1Client client1 = new ServiceReference4.Service1Client();
        List<ServiceReference4.TypeAdvice> typeAdvicesList = null;
        List<string> howtopay = new List<string>();
        List<string> howtomeet = new List<string>();

        public RegistrationForPersonalMeeting()
        {
            this.InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registration));

        }

        private async void registrationToPersonalMeeting(object sender, RoutedEventArgs e)

        {
            time.Header = "שעה";
            date.Header = " תאריך";
            lengthInMinutes.PlaceholderText = string.Empty;
            amountPaid.PlaceholderText = string.Empty;
            howToMeet.PlaceholderText = string.Empty;
            howToPay.PlaceholderText = string.Empty;
            howToPay.PlaceholderText = string.Empty;
            customer.PlaceholderText = string.Empty;
            adviceCombo.PlaceholderText = string.Empty;
            txtMassege.Text = " ";
            List<Sceduel> listSceduel = await client1.GetSceduelListAsync();
            List<Sceduel> l;
            if (date.SelectedDate != null && time.SelectedTime != null)
            {

                if (date.Date.DayOfWeek != DayOfWeek.Saturday && date.Date.DayOfWeek != DayOfWeek.Friday )
                {
                    l = listSceduel.Where(x => x.dateInMonth == date.Date.Date && x.timeInDay == Convert.ToDateTime(time.SelectedTime.Value.ToString())).ToList();
                   
                        if (l.Count <= 0)
                        {

                            ServiceReference4.Sceduel S = new ServiceReference4.Sceduel();
                            S.dateInMonth = date.Date.Date;
                            S.timeInDay = Convert.ToDateTime(time.SelectedTime.Value.ToString());
                          
                         
                                if (Legal.IsNumber(amountPaid.Text) && adviceCombo.SelectedIndex > -1 && customer.SelectedIndex > -1 && Legal.IsNumber(lengthInMinutes.Text) && howToPay.SelectedIndex > -1 && howToMeet.SelectedIndex > -1 && date.SelectedDate != null)
                                {

                                    ServiceReference4.PersonalMeeting p = new ServiceReference4.PersonalMeeting();
                                S.code = await client1.GetCodeToSceduelAsync();
                                int R = await client1.AddSceduelAsync(S);
                                if (R <= 0)
                                {
                                    txtMassege.Text = "טעות בתאריך";
                                }
                                p.code = await client1.GetCodeToPersonalMeetingAsync();
                                    p.customer = (ServiceReference4.Customers)(customer.SelectedItem);
                                    p.typeAdvice = (TypeAdvice)(adviceCombo.SelectedItem);
                                    p.dday = S;
                                    p.howToMeet = howtomeet[howToMeet.SelectedIndex];
                                    p.paymentMethod = howtopay[howToPay.SelectedIndex];
                                    p.lengthSessionInminutes = Convert.ToInt32(lengthInMinutes.Text);
                                    p.amountPaid = Convert.ToInt32(amountPaid.Text);
                                    p.price = Convert.ToInt32(price.Text);
                                    int f;

                                    f = await client1.AddPersonalMeetingAsync(p);
                                    if (f > 0)
                                    {
                                        txtMassege.Text = "ההרשמה בוצעה בהצלחה";

                                        customer.SelectedIndex = -1;
                                        adviceCombo.SelectedIndex = -1;
                                        howToMeet.SelectedIndex = -1;
                                        howToPay.SelectedIndex = -1;
                                        lengthInMinutes.Text = string.Empty;
                                        amountPaid.Text = string.Empty;
                                        price.Text = string.Empty;
                                        date.SelectedDate = null;
                                        time.SelectedTime = null;

                                        time.Header = "שעה";
                                        date.Header = " תאריך";
                                        lengthInMinutes.PlaceholderText = string.Empty;
                                        amountPaid.PlaceholderText = string.Empty;
                                        howToMeet.PlaceholderText = string.Empty;
                                        howToPay.PlaceholderText = string.Empty;
                                        howToPay.PlaceholderText = string.Empty;
                                        customer.PlaceholderText = string.Empty;
                                        adviceCombo.PlaceholderText = string.Empty;

                                    }
                                    else
                                    {
                                        txtMassege.Text = "ההרשמה לא התבצעה אנא נסה שנית";
                                        await client1.DeleteSceduelAsync(S);
                                    }
                                }
                                else
                                {
                                    if (adviceCombo.SelectedIndex < 0)
                                    {
                                        adviceCombo.PlaceholderText = "חובה לבחור יעוץ";
                                    }
                                    if (customer.SelectedIndex < 0)
                                    {
                                        customer.PlaceholderText = "חובה לבחור לקוח";
                                    }
                                    if (howToPay.SelectedIndex < 0)
                                    {
                                        howToPay.PlaceholderText = "חובה לבחור צורת תשלום";
                                    }
                                    if (howToMeet.SelectedIndex < 0)
                                    {
                                        howToMeet.PlaceholderText = "חובה לבחור אופן פגישה ";
                                    }
                                    if (Legal.IsNumber(amountPaid.Text) == false)
                                    {
                                        amountPaid.PlaceholderText = "יש לכתוב מספרים בלבד";
                                    }
                                    if (Legal.IsNumber(lengthInMinutes.Text) == false)
                                    {
                                        lengthInMinutes.PlaceholderText = "יש לכתוב מספרים בלבד";


                                    }

                                }
                            


                        }
                        else
                        {
                            txtMassege.Text = "התאריך תפוס נא בחר תאריך אחר";
                        }

                }
                else
                {
                    txtMassege.Text = "לא ניתן לקבוע פגישה לימי שישי ושבת";
                }

              
            }
            else
            {
                if(time.SelectedTime == null)
                  time.Header = "חובה לבחור שעה";
                else
                date.Header = "חובה לבחור תאריך";
                

            }

        }



        private void HomeBack(object sender, RoutedEventArgs e)                         
        {                                                                               
            this.Frame.Navigate(typeof(MainPage));                                      
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            typeAdvicesList = await client1.GetTypeAdviceListAsync();
            adviceCombo.ItemsSource = typeAdvicesList;
            customer.ItemsSource = await client1.GetCustomersListAsync();
            howtopay.Add("אשראי");
            howtopay.Add("העברה"); howtopay.Add("מזומן"); howtopay.Add("הוראת קבע");
            howtomeet.Add("טלפון"); howtomeet.Add("זום"); howtomeet.Add("פרונטלי");
            howToPay.ItemsSource = howtopay;
            howToMeet.ItemsSource = howtomeet;
            
            client.Calender c = new Calender();
            SceduelMin = c;

        }

        private void PersonalMeetings(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PersonalMeeting));

        }
    }
}
