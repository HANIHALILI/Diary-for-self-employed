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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Course : Page
    {
        ServiceReference4.Service1Client client = new ServiceReference4.Service1Client();
        List<ServiceReference4.RegistrationForCourse> registrationForCoursesList;
        List<ServiceReference4.TypeCourse> tp = null;
        List<ServiceReference4.Course> coursesList;
       //public  ListView l = new ListView();
        
        public Course()
        {
            this.InitializeComponent();
     
        }


        private void AddCourse(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddCourse));
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
       

        private void RegistrationForCourse(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationForCourse));

        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
           coursesList = await client.GetCourseListAsync();;
             tp = await client.GetTypeCourseListAsync();
           
            lstCourse.ItemsSource = coursesList;
           
            typeCourse.ItemsSource = tp;
            lstCourse.SelectedIndex = -1;
            typeCourse.SelectedIndex = -1;
             registrationForCoursesList = await client.GetRegistrationToCourseListAsync();

            rFC.SelectedIndex = -1;
        }
        private async void find_TextChanged(object sender, TextChangedEventArgs e)
        { 
            List<ServiceReference4.Course> v = null;
            List<ServiceReference4.Course> c= await client.GetCourseListAsync();
            v = c.Where(p => $"{p.discribtion}{p.price}{p.numberOfLessons}{p.status}{p.codeTypeCourse.nameTypeCourse}".Contains(find.Text)).ToList();
            lstCourse.ItemsSource = v;
        }

        private void lstCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusT.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Visible;

            if (lstCourse.SelectedIndex>-1) {
                detailsPop.Tag = (ServiceReference4.Course)(lstCourse.SelectedItem);
                detailsPop.IsOpen = true;
                txtTitle.Text = "פרטי סדנה";
                saveBtn.Visibility = Visibility.Collapsed;
                courseP.Opacity = 0.5;

                typeCourse.Visibility = Visibility.Collapsed;
                typeCourseT.Visibility = Visibility.Visible;

                price.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).price.ToString();

                numOfLessons.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).numberOfLessons.ToString();
                status.PlaceholderText = ((ServiceReference4.Course)(lstCourse.SelectedItem)).status;
                discribtion.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).discribtion;
                typeCourse.ItemsSource = tp.Select(p => p.code.ToString().CompareTo(((ServiceReference4.Course)(lstCourse.SelectedItem)).codeTypeCourse.code.ToString()));
                typeCourseT.Text = tp.FirstOrDefault(cust => cust.nameTypeCourse == ((ServiceReference4.Course)(lstCourse.SelectedItem)).codeTypeCourse.nameTypeCourse)?.nameTypeCourse;

                typeCourseT.IsReadOnly = true;
                price.IsReadOnly = true;
                numOfLessons.IsReadOnly = true;
                statusT.IsReadOnly = true;
                discribtion.IsReadOnly = true;
          }
        }
        private void closeDetailsPop(object sender, RoutedEventArgs e)
        {
            detailsPop.IsOpen = false;
            historyPop.IsOpen = false;

            courseP.Opacity = 1;
            typeCourse.SelectedIndex = -1;
            rFC.SelectedIndex = -1;
            lstCourse.SelectedIndex = -1;
        }
        private void OpenUpdatePOP(object sender, RoutedEventArgs e)
        {
            statusT.Visibility = Visibility.Collapsed;
            status.Visibility = Visibility.Visible;
            if (((sender as Button).Parent as StackPanel).Tag.ToString() == "out")
            {

                lstCourse.SelectedItem = (((sender as Button).Parent as StackPanel).Parent as StackPanel).Parent as ListViewItem;

                var u = (((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag;
                detailsPop.IsOpen = true;
                txtTitle.Text = "עדכן פרטי סדנה";
                saveBtn.Visibility = Visibility.Visible;
                courseP.Opacity = 0.5;

                typeCourse.Visibility = Visibility.Visible;
                typeCourseT.Visibility = Visibility.Collapsed;
                detailsPop.Tag = u;
                price.Text = ((ServiceReference4.Course)(u)).price.ToString();
                numOfLessons.Text = ((ServiceReference4.Course)(u)).numberOfLessons.ToString();
                statusT.PlaceholderText = ((ServiceReference4.Course)(u)).status;
                discribtion.Text = ((ServiceReference4.Course)(u)).discribtion;

                typeCourse.ItemsSource = tp.Select(p => p.code.ToString().CompareTo(((ServiceReference4.Course)(u)).codeTypeCourse.code.ToString()));

                typeCourseT.Text = tp.FirstOrDefault(cust => cust.nameTypeCourse == ((ServiceReference4.Course)(u)).codeTypeCourse.nameTypeCourse)?.nameTypeCourse;

                
                price.IsReadOnly = false;
                numOfLessons.IsReadOnly = false;
                statusT.IsReadOnly = false;
                discribtion.IsReadOnly = false;
            }
            if (lstCourse.SelectedIndex > -1)
            {

                detailsPop.IsOpen = true;
                txtTitle.Text = "עדכן פרטי סדנה";
                saveBtn.Visibility = Visibility.Visible;
                courseP.Opacity = 0.5;

                typeCourse.Visibility = Visibility.Visible;
                typeCourseT.Visibility = Visibility.Collapsed;

                price.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).price.ToString();
                numOfLessons.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).numberOfLessons.ToString();
                statusT.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).status;
                discribtion.Text = ((ServiceReference4.Course)(lstCourse.SelectedItem)).discribtion;

                typeCourse.ItemsSource = tp.Select(p => p.code.ToString().CompareTo(((ServiceReference4.Course)(lstCourse.SelectedItem)).codeTypeCourse.code.ToString()));

                typeCourseT.Text = tp.FirstOrDefault(cust => cust.nameTypeCourse == ((ServiceReference4.Course)(lstCourse.SelectedItem)).codeTypeCourse.nameTypeCourse)?.nameTypeCourse;


                price.IsReadOnly = false;
                numOfLessons.IsReadOnly = false;
                statusT.IsReadOnly = false;
                discribtion.IsReadOnly = false;
            }

        }
        private async void UpdateC(object sender, RoutedEventArgs e)
        {
            if (Legal.IsNumber(numOfLessons.Text) && Legal.IsNumber(price.Text) && status.SelectedIndex > -1 && typeCourse.SelectedIndex > -1)
            {
                int x = Convert.ToInt32(numOfLessons.Text);

                ServiceReference4.Course C = (ServiceReference4.Course)((sender as Button).Tag);
                C.codeTypeCourse = (ServiceReference4.TypeCourse)(((typeCourse.SelectedItem) as ComboBoxItem).Parent as StackPanel).Tag;
                C.discribtion = discribtion.Text + " ";
                C.status = (status.SelectedItem as ComboBoxItem).Content.ToString();
                C.price = Convert.ToDouble(price.Text);
                C.numberOfLessons = x;

                int y;
                y = await client.UpdateCourseAsync(C);
                if (y > 0)
                {
                    txtMessage1.Text = "הסדנה נוספה בהצלחה";
                    typeCourse.SelectedIndex = -1;
                    status.SelectedIndex = -1;
                    discribtion.Text = string.Empty;
                    price.Text = string.Empty;
                    numOfLessons.Text = string.Empty;
                }
                else
                {
                    txtMessage1.Text = "הסדנה לא נוספה אנא נסה שנית";
                }
                int z;
                z = await client.AddLstCourseMeetingAsync(x, C);
                if (z > 0)
                {
                    txtMessage1.Text = "שיעורי הסדנה נוספו בהצלחה";
                }
                else
                {
                    txtMessage1.Text = "שיעורי הסדנה לא נוספו אנא נסה שנית";
                }

            }
            else
            {
                if (Legal.IsNumber(numOfLessons.Text) == false)
                {
                    numOfLessons.Text = "יש לכתוב מספרים בלבד";
                }
                if (Legal.IsNumber(price.Text) == false)
                {
                    price.Text = "יש לכתוב מספרים בלבד";
                }
                if (typeCourse.SelectedIndex < 0)
                {
                    typeCourse.PlaceholderText = "חובה לבחור סוג סדנה";
                }
                if (status.SelectedIndex < 0)
                {
                    status.PlaceholderText = "חובה לבחור מצב סדנה";
                }

            }
            

           

          
        }

        private void OpenDeletePOP(object sender, RoutedEventArgs e)
        {
            deletePop.IsOpen = true;
            lstCourse.SelectedItem = ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Parent as DataTemplate) ;
        }

        private void closeDPop(object sender, RoutedEventArgs e)
        {
            deletePop.IsOpen = false;
            typeCourse.SelectedIndex = -1;
        }

        private async void deleteC(object sender, RoutedEventArgs e)
        {
            await client.DeleteCourseAsync((ServiceReference4.Course)((sender as Button).Tag));
            deletePop.IsOpen = false;
        }

        private void CourseMeeting(object sender, RoutedEventArgs e)
        {
          
            this.Frame.Navigate(typeof(CourseMeeting),((ServiceReference4.Course)((((sender as Button).Parent as StackPanel).Parent as StackPanel).Parent as Popup).Tag));
        }










        private void rFC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            detailsPopM.IsOpen = true;
            btnUpDateM.Visibility = Visibility.Collapsed;
        }

        private void OpendeletePopM(object sender, RoutedEventArgs e)
        {
            deletePopM.IsOpen = true;
            historyPop.Opacity = 0.4;
        }

        private void OpenUpdatePopM(object sender, RoutedEventArgs e)
        {
            detailsPopM.IsOpen = true;
            historyPop.Opacity = 0.4;

            btnUpDateM.Visibility = Visibility.Visible;
        }

        private void closeDetailsPopM(object sender, RoutedEventArgs e)
        {
            detailsPopM.IsOpen = false;
            historyPop.Opacity = 1;
        }

        private void closeDPopM(object sender, RoutedEventArgs e)
        {
            deletePopM.IsOpen = false;
            historyPop.Opacity = 1;
        }

        private async void deleteCM(object sender, RoutedEventArgs e)
        {

            int d = await client.DeleteRegistrationToCourseAsync((ServiceReference4.RegistrationForCourse)(rFC.SelectedItem));
            if (d > 1)
            {
                txtMessage1M.Text = "הרשומה נחמקה בהצלחה";
            }
            else
            {
                txtMessage1M.Text = "הרשומה לא נחמקה נא נסה שנית";
            }
        }

        private void updateCM(object sender, RoutedEventArgs e)

        {

        }

        private void OpenHistoryPOP(object sender, RoutedEventArgs e)
        {

            //foreach (ListViewItem item in lstCourse.Items)
            //{
            //    if ((ServiceReference4.Course)(item.Tag) == (sender as Button).Tag as ServiceReference4.Course)
            //    {
            //        lstCourse.SelectedItem = item;
            //    }
            //}

            //= coursesList.Where(p => p.code == ((sender as Button).Tag as ServiceReference4.Course).code) as ListViewItem;
            if (((sender as Button).Parent as StackPanel).Tag.ToString() == "out")
            {

                ServiceReference4.Course u = (((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag as ServiceReference4.Course;
                rFC.ItemsSource = registrationForCoursesList.Where(p => p.course.code == u.code).ToList();

            }
            if (lstCourse.SelectedIndex > -1)
            {
            rFC.ItemsSource = registrationForCoursesList.Where(p => p.course.code == ((ServiceReference4.Course)(lstCourse.SelectedItem)).code);

            }


            historyPop.IsOpen = true;
            courseP.Opacity = 0.5;
        }
    }
}
