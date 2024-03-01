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
    public sealed partial class CourseMeeting : Page
    {
        ServiceReference4.Service1Client client = new ServiceReference4.Service1Client();
        List<ServiceReference4.CourseMeeting> lstCourseM = new List<ServiceReference4.CourseMeeting>();
        ServiceReference4.Course course;
        ServiceReference4.Sceduel S;


        public CourseMeeting()
        {
            this.InitializeComponent();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Course));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                course = e.Parameter as ServiceReference4.Course;
            }
        }

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            lstCourseM = await client.GetCourseMeetingListAsync();
            lstCourseMng.ItemsSource = lstCourseM.Where(c => c.course.code == course.code);
        }

        private async void UpdateCm(object sender, RoutedEventArgs e)
        {
            List<Sceduel> listSceduel = await client.GetSceduelListAsync();
            List<Sceduel> l;
            if (STUpdate.Tag as string == "singel")
            {

                if (date.SelectedDate != null && time.SelectedTime != null)
                {

                    if (date.Date.DayOfWeek != DayOfWeek.Saturday && date.Date.DayOfWeek != DayOfWeek.Friday)
                    {
                        l = listSceduel.Where(x => x.dateInMonth == date.Date.Date && x.timeInDay == Convert.ToDateTime(time.SelectedTime.Value.ToString())).ToList();

                        if (l.Count <= 0)
                        {
                            ServiceReference4.Sceduel S = new ServiceReference4.Sceduel();
                            S.code = await client.GetCodeToSceduelAsync();
                            S.dateInMonth = date.Date.Date;
                            S.timeInDay = Convert.ToDateTime(time.SelectedTime.Value.ToString());

                            if (Legal.IsNumber(lengthM.Text))
                            {

                                ServiceReference4.CourseMeeting cm = lstCourseMng.SelectedItem as ServiceReference4.CourseMeeting;

                                int R = await client.AddSceduelAsync(S);
                                if (R <= 0)
                                {
                                    txtMessage.Text = "טעות בתאריך";
                                }
                               else { 
                                cm.ddate = S;
                                cm.lengthSessionInminutes = Convert.ToInt32(lengthM.Text);
                                cm.notes = notes.Text+ " ";
                                cm.contentMeeting = content.Text+ " ";
                                cm.isPerformed = prem.IsChecked.Value;
                                int f;

                                f = await client.UpdateCourseMeetingAsync(cm);
                                if (f > 0)
                                {
                                        txtMessage.Text = "העריכה בוצעה בהצלחה";


                                    date.SelectedDate = null;
                                    time.SelectedTime = null;

                                    time.Header = "שעה";
                                    date.Header = " תאריך";
                                    lengthM.PlaceholderText = string.Empty;
                                        lengthM.Text = string.Empty;

                                        bS.IsEnabled = false;
                                        bA.IsEnabled = false;
                                        lstCourseMng.SelectedIndex = -1;
                                        prem.IsChecked = false;
                                        notes.Text = string.Empty;
                                        content.Text = string.Empty;
                                    }

                                else
                                {
                                    txtMessage.Text = "ההרשמה לא התבצעה אנא נסה שנית";
                                    await client.DeleteSceduelAsync(S);
                                }
                            }
                            }
                            else
                            {

                                   lengthM.PlaceholderText = "יש לכתוב מספרים בלבד";

                              
                            }
                        }
                        else
                        {
                            txtMessage.Text = "התאריך תפוס נא בחר תאריך אחר";
                        }
                    }
                 
                     else
                    {
                        txtMessage.Text = "לא ניתן לקבוע פגישה לימי שישי ושבת";
                    }

                } 
            else
            {
                if (time.SelectedTime == null)
                    time.Header = "חובה לבחור שעה";
                else
                    date.Header = "חובה לבחור תאריך";


            }
            }

            else
            {
            }
            
        }

        private void lstCourseMng_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bS.IsEnabled = true;
            bA.IsEnabled = true;

            txtMessage.Text = " ";
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            STUpdate.Visibility = Visibility.Visible;
            if ((sender as Button).Tag as string == "singel")
            {
                STUpdate.Tag = "singel";
            }
            else
            {
                STUpdate.Tag = "all";
            }
        }
    }
}
