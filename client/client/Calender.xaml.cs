using System;
using System.Collections.Generic;
using System.Drawing;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calender : Page
    {
        ServiceReference4.Service1Client client = new ServiceReference4.Service1Client();

        List<ServiceReference4.Course> courses = null;
        List<ServiceReference4.CourseMeeting> CourseMeetings = null;
        List<ServiceReference4.CourseMeeting> C = null;
        List<ServiceReference4.CourseMeeting> CD = null;
        List<ServiceReference4.CourseMeeting> CT = null;

        ListView l;
        List<ServiceReference4.PersonalMeeting> p = new List<ServiceReference4.PersonalMeeting>();
        List<ServiceReference4.PersonalMeeting> pD = new List<ServiceReference4.PersonalMeeting>();
        List<ServiceReference4.PersonalMeeting> pT = new List<ServiceReference4.PersonalMeeting>();

        List<ServiceReference4.CourseMeeting> c = new List<ServiceReference4.CourseMeeting>();
        Windows.UI.Color color = new Windows.UI.Color();
        Windows.UI.Color color1 = new Windows.UI.Color();

        List<ServiceReference4.PersonalMeeting> personalMeetings = null;
        public static DateTime theSelectedDate;
        public static int theDayInWeek;

        public Calender()
        {
            this.InitializeComponent();
        }

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            courses = await client.GetCourseListAsync();
            CourseMeetings = await client.GetCourseMeetingListAsync();
            personalMeetings = await client.GetPersonalMeetingListAsync();
            color.A = 100;
            color.R = 146;
            color.G = 78;
            color.B = 149;
            color1.A = 100;
            color1.R = 0;
            color1.G = 0;
            color1.B = 0;
        }

        private void dp_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            //dp.Date as caoender IsEnabled = false;


            if (gridWeek.Children.Count > 1)
            {


                while (gridWeek.Children.Count != 1)
                {
                    gridWeek.Children.Remove(gridWeek.Children.First());

                }
            }

            if (dp.Date == null)
            {
                if (gridWeek.Children.Count > 1)
                {


                    while (gridWeek.Children.Count != 1)
                    {
                        gridWeek.Children.Remove(gridWeek.Children.First());

                    }
                }
            }
            else
            {
                theSelectedDate = dp.Date.Value.DateTime.Date.Date.Date.Date.Date.Date.Date.Date.Date.Date.Date.Date.Date.Date;


                C = CourseMeetings.Where(x => x.ddate.dateInMonth >= theSelectedDate.AddDays(-1 * (int)(theSelectedDate.DayOfWeek)) && x.ddate.dateInMonth <= theSelectedDate.AddDays(6 - (int)(theSelectedDate.DayOfWeek))).ToList();

                p = personalMeetings.Where(x => x.dday.dateInMonth >= theSelectedDate.AddDays(-1 * (int)(theSelectedDate.DayOfWeek)) && x.dday.dateInMonth <= theSelectedDate.AddDays(6 - (int)(theSelectedDate.DayOfWeek))).ToList();
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        theDayInWeek = 0;
                        pD = p.Where(x => x.dday.dateInMonth.DayOfWeek == DayOfWeek.Sunday).ToList();
                        CD = c.Where(x => x.ddate.dateInMonth.DayOfWeek == DayOfWeek.Sunday).ToList();

                    }

                    if (i == 1)
                    {
                        theDayInWeek = 1;
                        pD = p.Where(x => x.dday.dateInMonth.DayOfWeek == DayOfWeek.Monday).ToList();
                        CD = c.Where(x => x.ddate.dateInMonth.DayOfWeek == DayOfWeek.Monday).ToList();


                    }

                    if (i == 2)
                    {
                        theDayInWeek = 2;
                        pD = p.Where(x => x.dday.dateInMonth.DayOfWeek == DayOfWeek.Tuesday).ToList();
                        CD = c.Where(x => x.ddate.dateInMonth.DayOfWeek == DayOfWeek.Tuesday).ToList();


                    }

                    if (i == 3)
                    {
                        theDayInWeek = 3;
                        pD = p.Where(x => x.dday.dateInMonth.DayOfWeek == DayOfWeek.Wednesday).ToList();
                        CD = c.Where(x => x.ddate.dateInMonth.DayOfWeek == DayOfWeek.Wednesday).ToList();


                    }

                    if (i == 4)
                    {
                        theDayInWeek = 4;
                        pD = p.Where(x => x.dday.dateInMonth.DayOfWeek == DayOfWeek.Thursday).ToList();
                        CD = c.Where(x => x.ddate.dateInMonth.DayOfWeek == DayOfWeek.Thursday).ToList();


                    }

                   l = new ListView();
                    foreach (ServiceReference4.PersonalMeeting item in pD)
                    {
                        
                        //לעצב
                        StackPanel s = new StackPanel();
                        SolidColorBrush b = new SolidColorBrush();
                        SolidColorBrush b1 = new SolidColorBrush();

                        Button n = new Button();
                        n.Content = "פירוט";
                        b.Color = color;
                        b1.Color = color1;

                        n.BorderBrush = b;
                        n.Background = b1;


                        TextBlock t = new TextBlock();
                        t.Foreground = b;
                        t.Text += item.customer.name + " ";
                        t.Text += item.typeAdvice.nameTypeAdvice + " " + item.dday.dateInMonth.Day + "/" + item.dday.dateInMonth.Month + " ";
                        t.Text += item.dday.timeInDay.Hour + ":" + item.dday.timeInDay.Minute;
                        s.Margin = new Thickness(3);
                        s.Tag = item;
                        s.Children.Add(t);
                        //   s.Children.Add(n);
                        l.Items.Add(s);

                    }l.ItemsSource = pD;
                    foreach (ServiceReference4.CourseMeeting item in CD)
                    {
                        //kgmc
                        StackPanel s = new StackPanel();
                        ListViewItem ls = new ListViewItem();
                        SolidColorBrush b = new SolidColorBrush();
                        SolidColorBrush b1 = new SolidColorBrush();

                        Button n = new Button();
                        n.Content = "פירוט";
                        b.Color = color;
                        b1.Color = color1;

                        n.BorderBrush = b;
                        n.Background = b1;


                        TextBlock t = new TextBlock();
                        t.Foreground = b;
                        t.Text += item.course.codeTypeCourse.nameTypeCourse + " " + item.ddate.dateInMonth.Day + "/" + item.ddate.dateInMonth.Month + " ";
                        t.Text += item.ddate.timeInDay.Hour + ":" + item.ddate.timeInDay.Minute;
                        s.Margin = new Thickness(3);
                        l.Tag = item;
                        s.Children.Add(t);
                        l.Items.Add(s);

                    }
                    l.SelectionChanged += LSelectionChanged;


                    Grid.SetColumn(l, theDayInWeek);
                    Grid.SetRow(l, 1);
                    gridWeek.Children.Add(l);


                }
            }
        }

        private void LSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ServiceReference4.PersonalMeeting p = l.SelectedItem as ServiceReference4.PersonalMeeting;
            this.Frame.Navigate(typeof(PersonalMeeting),p);
            ////ServiceReference4.PersonalMeeting p = e.Parameter as ServiceReference4.PersonalMeeting;

            //detailsPop.IsOpen = true;
            //txtTitle.Text = "פרטי פגישה";
            //cPage.Opacity = 0.5;


            //typeAdvice.Visibility = Visibility.Visible;
            //typeAdviceCombo.Visibility = Visibility.Collapsed;
            //dateT.Visibility = Visibility.Visible;
            //date.Visibility = Visibility.Collapsed;
            //timeT.Visibility = Visibility.Visible;
            //time.Visibility = Visibility.Collapsed;
            //howToMeetT.Visibility = Visibility.Visible;
            //howToMeet.Visibility = Visibility.Collapsed;
            //methodPayT.Visibility = Visibility.Visible;
            //methodPay.Visibility = Visibility.Collapsed;

            //name.IsReadOnly = true;
            //typeAdvice.IsEnabled = true;
            //dateT.IsReadOnly = true;
            //timeT.IsReadOnly = true;
            //howToMeetT.IsReadOnly = true;
            //length.IsReadOnly = true;
            //price.IsReadOnly = true;
            //amountTopay.IsReadOnly = true;
            //methodPayT.IsReadOnly = true;


            ////name.Text = p.customer.name;
            ////typeAdvice.Text= p.typeAdvice.nameTypeAdvice;
            ////dateT.Text = (p).dday.dateInMonth.ToString();
            ////timeT.Text = (p).dday.timeInDay.ToString();
            ////howToMeetT.Text = (p).howToMeet;
            ////length.Text = (p).lengthSessionInminutes.ToString();
            ////price.Text = (p).price.ToString();
            ////amountTopay.Text = (p).amountPaid.ToString();
            ////methodPay.Text = (p).paymentMethod;
            ////isPerformed.Text = (p).isPerformed.ToString();
        }

        private void clear1(object sender, RoutedEventArgs e)
        {
            detailsPop.IsOpen = false;
            cPage.Opacity = 1;
        }
        private void OpenDPOP(object sender, RoutedEventArgs e)
        {
          
        }

        private void OpenUPOP(object sender, RoutedEventArgs e)
        {
           
                detailsPop.IsOpen = true;
                cPage.Opacity = 0.5;
                ServiceReference4.PersonalMeeting p = (sender as Button).Tag as ServiceReference4.PersonalMeeting;


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

            //  //    howToMeet.ItemsSource = typeof(f).GetProperties().;

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
    }  

