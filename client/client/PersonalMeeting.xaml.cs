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
    public sealed partial class PersonalMeeting : Page
    {
        Service1Client client = new Service1Client();

        List<ServiceReference4.Customers> customersList = null;
        List<ServiceReference4.TypeAdvice> typeA = null;
        List<string> howtopay = new List<string>();
        List<string> howtomeet = new List<string>();

        List<ServiceReference4.PersonalMeeting> personalMeetingsList = null;

        List<ServiceReference4.Cities> c = new List<ServiceReference4.Cities>();
        private object selectOption;

        public PersonalMeeting()
        {
            this.InitializeComponent();

        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
    


        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        private void RegistrationForPersonalMeeting(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationForPersonalMeeting));

        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
           
              personalMeetingsList = await client.GetPersonalMeetingListAsync();
            pML.ItemsSource = personalMeetingsList;

            customersList = await client.GetCustomersListAsync();
  
            typeA = await client.GetTypeAdviceListAsync();
            typeAdviceCombo.ItemsSource = typeA;
            howtopay.Add("אשראי");
            howtopay.Add("העברה"); howtopay.Add("מזומן"); howtopay.Add("הוראת קבע");
            howtomeet.Add("טלפון"); howtomeet.Add("זום"); howtomeet.Add("פרונטלי");

            howToMeet.ItemsSource = howtomeet;

            methodPay.ItemsSource = howtopay;
            c = await client.GetCitiesListAsync();
         }

      
        private  void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            List<ServiceReference4.PersonalMeeting> list = new List<ServiceReference4.PersonalMeeting>();   
            list = personalMeetingsList.Where(p => $"{p.customer.name}{p.amountPaid}{p.dday.dateInMonth}{p.isPerformed}{p.howToMeet}{p.price}{p.dday.timeInDay}{p.typeAdvice.nameTypeAdvice}{p.lengthSessionInminutes}{p.paymentMethod}".Contains(find.Text)).ToList();
            pML.ItemsSource = list;

        }
     
        private void pML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (pML.SelectedIndex > -1)
            {
                detailsPop.IsOpen = true;
                txtTitle.Text = "פרטי פגישה";
                pPage.Opacity = 0.5;
                scroller.Tag = pML.SelectedItem;

                typeAdvice.Visibility = Visibility.Visible;
                typeAdviceCombo.Visibility = Visibility.Collapsed;
                dateT.Visibility = Visibility.Visible;
                date.Visibility = Visibility.Collapsed;
                timeT.Visibility = Visibility.Visible;
                time.Visibility = Visibility.Collapsed;
                howToMeetT.Visibility = Visibility.Visible;
                howToMeet.Visibility = Visibility.Collapsed;
                methodPayT.Visibility = Visibility.Visible;
                methodPay.Visibility = Visibility.Collapsed;

                name.IsReadOnly = true;
                typeAdvice.IsEnabled = true;
                dateT.IsReadOnly = true;
                timeT.IsReadOnly = true;
                howToMeetT.IsReadOnly = true;
                length.IsReadOnly = true;
                price.IsReadOnly = true;
                amountTopay.IsReadOnly = true;
                methodPayT.IsReadOnly = true;


                name.Text = customersList.FirstOrDefault(cust => cust.code == (scroller.Tag as ServiceReference4.PersonalMeeting).customer.code)?.name;
                typeAdvice.Text = typeA.FirstOrDefault(cust => cust.nameTypeAdvice == (scroller.Tag as ServiceReference4.PersonalMeeting).typeAdvice.nameTypeAdvice)?.nameTypeAdvice;
                dateT.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).dday.dateInMonth.ToString();
                timeT.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).dday.timeInDay.ToString();
                howToMeetT.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).howToMeet;
                length.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).lengthSessionInminutes.ToString();
                price.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).price.ToString();
                amountTopay.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).amountPaid.ToString();
                methodPay.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).paymentMethod;
                isPerformed.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).isPerformed.ToString();
            }

        }
        private void clear1(object sender, RoutedEventArgs e)
        {
            detailsPop.IsOpen = false;
            pPage.Opacity = 1;
            name.IsReadOnly = true;
            typeAdvice.IsEnabled = true;
            dateT.IsReadOnly = true;
            timeT.IsReadOnly = true;
            howToMeetT.IsReadOnly = true;
            length.IsReadOnly = true;
            price.IsReadOnly = true;
            amountTopay.IsReadOnly = true;
            methodPayT.IsReadOnly = true;
            btnUpDate.Visibility = Visibility.Collapsed;
            pML.SelectedIndex = -1;
        }

        private void OpenUPOP(object sender, RoutedEventArgs e)
        {
            if(((sender as Button).Parent as StackPanel).Tag.ToString() == "out")
            {
                detailsPop.IsOpen = true;
                pPage.Opacity = 0.5;
                scroller.Tag = ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag);
                ServiceReference4.PersonalMeeting f = scroller.Tag as ServiceReference4.PersonalMeeting;
                txtTitle.Text = "עדכן פרטי פגישה";
                btnUpDate.Visibility = Visibility.Visible;

                typeAdvice.Visibility = Visibility.Collapsed;
                typeAdviceCombo.Visibility = Visibility.Visible;
                dateT.Visibility = Visibility.Collapsed;
                date.Visibility = Visibility.Visible;
                timeT.Visibility = Visibility.Collapsed;
                time.Visibility = Visibility.Visible;
                howToMeetT.Visibility = Visibility.Collapsed;
                howToMeet.Visibility = Visibility.Visible;
                methodPayT.Visibility = Visibility.Collapsed;
                methodPay.Visibility = Visibility.Visible;


                name.IsReadOnly = false;
                typeAdvice.IsEnabled = false;
                dateT.IsReadOnly = false;
                timeT.IsReadOnly = false;
                howToMeetT.IsReadOnly = false;
                length.IsReadOnly = false;
                price.IsReadOnly = false;
                amountTopay.IsReadOnly = false;
                methodPayT.IsReadOnly = false;

          //      howToMeet.ItemsSource = typeof(f).GetProperties().;

                name.Text = customersList.FirstOrDefault(cust => cust.name == f.customer.name)?.name;
                typeAdvice.Text = typeA.FirstOrDefault(cust => cust.nameTypeAdvice == f.typeAdvice.nameTypeAdvice)?.nameTypeAdvice;
                dateT.Text = f.dday.dateInMonth.ToString();
                timeT.Text = f.dday.timeInDay.ToString();
                howToMeet.PlaceholderText = f.howToMeet;
                length.Text = f.lengthSessionInminutes.ToString();
                price.Text = f.price.ToString();
                amountTopay.Text = f.amountPaid.ToString();
                methodPay.Text = f.paymentMethod;
                isPerformed.Text = f.isPerformed.ToString();
            }
            if (pML.SelectedIndex > -1)
            {
                txtTitle.Text = "עדכן פרטי פגישה";
                detailsPop.IsOpen = true;
                btnUpDate.Visibility = Visibility.Visible;

                typeAdvice.Visibility = Visibility.Collapsed;
                typeAdviceCombo.Visibility = Visibility.Visible;
                dateT.Visibility = Visibility.Collapsed;
                date.Visibility = Visibility.Visible;
                timeT.Visibility = Visibility.Collapsed;
                time.Visibility = Visibility.Visible;
                howToMeetT.Visibility = Visibility.Collapsed;
                howToMeet.Visibility = Visibility.Visible;
                methodPayT.Visibility = Visibility.Collapsed;
                methodPay.Visibility = Visibility.Visible;



                name.IsReadOnly = false;
                typeAdvice.IsEnabled = false;
                dateT.IsReadOnly = false;
                timeT.IsReadOnly = false;
                howToMeetT.IsReadOnly = false;
                length.IsReadOnly = false;
                price.IsReadOnly = false;
                amountTopay.IsReadOnly = false;
                methodPayT.IsReadOnly = false;

                name.Text = customersList.FirstOrDefault(cust => cust.name == (scroller.Tag as ServiceReference4.PersonalMeeting).customer.name)?.name;
                typeAdvice.Text = typeA.FirstOrDefault(cust => cust.nameTypeAdvice == (scroller.Tag as ServiceReference4.PersonalMeeting).typeAdvice.nameTypeAdvice)?.nameTypeAdvice;
                dateT.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).dday.dateInMonth.ToString();
                timeT.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).dday.timeInDay.ToString();
                howToMeet.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).howToMeet;
                length.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).lengthSessionInminutes.ToString();
                price.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).price.ToString();
                amountTopay.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).amountPaid.ToString();
                methodPay.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).paymentMethod;
                isPerformed.Text = (scroller.Tag as ServiceReference4.PersonalMeeting).isPerformed.ToString();

            }
            else
            {
                txtTitle.Text = "עדכן פרטי פגישה";
                detailsPop.IsOpen = true;
                btnUpDate.Visibility = Visibility.Visible;

                typeAdvice.Visibility = Visibility.Collapsed;
                typeAdviceCombo.Visibility = Visibility.Visible;
                dateT.Visibility = Visibility.Collapsed;
                date.Visibility = Visibility.Visible;
                timeT.Visibility = Visibility.Collapsed;
                time.Visibility = Visibility.Visible;
                howToMeetT.Visibility = Visibility.Collapsed;
                howToMeet.Visibility = Visibility.Visible;
                methodPayT.Visibility = Visibility.Collapsed;
                methodPay.Visibility = Visibility.Visible;



                name.IsReadOnly = false;
                typeAdvice.IsEnabled = false;
                dateT.IsReadOnly = false;
                timeT.IsReadOnly = false;
                howToMeetT.IsReadOnly = false;
                length.IsReadOnly = false;
                price.IsReadOnly = false;
                amountTopay.IsReadOnly = false;
                methodPayT.IsReadOnly = false;
                ServiceReference4.PersonalMeeting p = (sender as NavigationEventArgs).Parameter as ServiceReference4.PersonalMeeting;
                name.Text = p.customer.name;
                typeAdvice.Text = p.typeAdvice.nameTypeAdvice;
                dateT.Text = (p).dday.dateInMonth.ToString();
                timeT.Text = (p).dday.timeInDay.ToString();
                howToMeetT.Text = (p).howToMeet;
                length.Text = (p).lengthSessionInminutes.ToString();
                price.Text = (p).price.ToString();
                amountTopay.Text = (p).amountPaid.ToString();
                methodPay.Text = (p).paymentMethod;
                isPerformed.Text = (p).isPerformed.ToString();
            }
        }
        private async void updatePm(object sender, RoutedEventArgs e)
        {

            ServiceReference4.PersonalMeeting p = scroller.Tag as  ServiceReference4.PersonalMeeting;
            if (Legal.IsNumber(amountTopay.Text) && typeAdviceCombo.SelectedIndex > -1  && Legal.IsNumber(length.Text) && methodPay.SelectedIndex > -1 && howToMeet.SelectedIndex > -1 && date.SelectedDate != null && time.SelectedTime != null)
            {
               p.howToMeet = howtomeet[howToMeet.SelectedIndex];
               p.paymentMethod = howtopay[methodPay.SelectedIndex];
                p.price = Convert.ToInt32(price.Text);
               p.lengthSessionInminutes = Convert.ToInt32(length.Text);
               p.amountPaid = Convert.ToInt32(amountTopay.Text);
               p.isPerformed = Convert.ToBoolean(isPerformed.Text);
               p.typeAdvice = (ServiceReference4.TypeAdvice)(typeAdviceCombo.SelectedItem);
                p.dday.timeInDay = Convert.ToDateTime(time.SelectedTime.Value.ToString());
                p.dday.dateInMonth = Convert.ToDateTime(date.SelectedDate.Value.ToString());

                int f;

                f = await client.UpdatePersonalMeetingAsync(p);
                if (f > 0)
                {
                    txtMassege.Text = "העדכון בוצע בהצלחה";
                    // פלייסהולדר
                    typeAdviceCombo.SelectedIndex = -1;
                    howToMeet.SelectedIndex = -1;
                    methodPay.SelectedIndex = -1;
                    length.Text = string.Empty;
                    amountTopay.Text = string.Empty;
                    price.Text = string.Empty;
                    date.SelectedDate = null;
                    time.SelectedTime = null;
                    typeAdvice.Visibility = Visibility.Visible;
                    typeAdviceCombo.Visibility = Visibility.Collapsed;
                    dateT.Visibility = Visibility.Visible;
                    date.Visibility = Visibility.Collapsed;
                    timeT.Visibility = Visibility.Visible;
                    time.Visibility = Visibility.Collapsed;
                    howToMeetT.Visibility = Visibility.Visible;
                    howToMeet.Visibility = Visibility.Collapsed;
                    methodPayT.Visibility = Visibility.Visible;
                    methodPay.Visibility = Visibility.Collapsed;

                    name.IsReadOnly = true;
                    typeAdvice.IsEnabled = true;
                    dateT.IsReadOnly = true;
                    timeT.IsReadOnly = true;
                    howToMeetT.IsReadOnly = true;
                    length.IsReadOnly = true;
                    price.IsReadOnly = true;
                    amountTopay.IsReadOnly = true;
                    methodPayT.IsReadOnly = true;
                    btnUpDate.Visibility = Visibility.Collapsed;
                }


                else
                    txtMassege.Text = "העדכון לא התבצע אנא נסה שנית";

            }

            else
            {


                if (typeAdviceCombo.SelectedIndex < 0)
                {
                    typeAdviceCombo.PlaceholderText = "חובה לבחור יעוץ";
                }
                if (methodPay.SelectedIndex < 0)
                {
                    methodPay.PlaceholderText = "חובה לבחור צורת תשלום";
                }
                if (howToMeet.SelectedIndex < 0)
                {
                    howToMeet.PlaceholderText = "חובה לבחור אופן פגישה ";
                }
                if (Legal.IsNumber(amountTopay.Text) == false)
                {
                    amountTopay.Text = "יש לכתוב מספרים בלבד";
                }
                if (Legal.IsNumber(length.Text) == false)
                {
                    length.Text = "יש לכתוב מספרים בלבד";
                }
                if (date.SelectedDate == null)
                {
                    date.Header = "חובה לבחור תאריך";
                }
                if (time.SelectedTime == null)
                {
                    time.Header = "חובה לבחור שעה";
                }

            }

          

        }



        private void CloseDPop(object sender, RoutedEventArgs e)
        {
            deletePop.IsOpen = false;
            detailsPop.Opacity = 1;
          //  pML.SelectedIndex = -1;

        }

        private void OpenDPOP(object sender, RoutedEventArgs e)
        {
            deletePop.IsOpen = true;
            detailsPop.Opacity = 0.5;
      

        }

        private async  void deletePm(object sender, RoutedEventArgs e)
        {
            await client.DeletePersonalMeetingAsync((ServiceReference4.PersonalMeeting)(sender as Button).Tag);
            pML.Items.Remove(pML.Items.FirstOrDefault(x => x == (sender as Button).Tag));


            deletePop.IsOpen = false;
            detailsPop.Opacity = 1;

        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)  //מחזיק בתוכו את הפרמטר שנשלח
            {
                RoutedEventArgs c = new RoutedEventArgs();
                OpenUPOP(e,c);
            }
        }


    }
}
