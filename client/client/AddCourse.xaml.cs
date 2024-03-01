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
    public sealed partial class AddCourse : Page
    {
        ServiceReference4.Service1Client client = new ServiceReference4.Service1Client();
        ServiceReference4.Course C = new ServiceReference4.Course();
        public AddCourse()
        {
            this.InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Course));
        }

        private void HomeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            courseCombo.ItemsSource = await client.GetTypeCourseListAsync();
        }
        private async void AddCourse1(object sender, RoutedEventArgs e)
        {
          
            if (Legal.IsNumber(numberOfLessons.Text) && Legal.IsNumber(price.Text) && ststusCombo.SelectedIndex>-1 && courseCombo.SelectedIndex>-1)
            {
                int x = Convert.ToInt32(numberOfLessons.Text);

                C.code = await client.GetCodeToCourseAsync();           
                C.codeTypeCourse = (ServiceReference4.TypeCourse)(courseCombo.SelectedItem);
                C.discribtion = discrabtion.Text + " ";         
                C.status = (ststusCombo.SelectedItem as ComboBoxItem).Content.ToString();
                C.price = Convert.ToDouble(price.Text);
                C.numberOfLessons = x;
              
                int y = await client.AddCourseAsync(C);
                if(y>0)
                {
                  int z =await client.AddLstCourseMeetingAsync(x, C);
                  if (z >0)
                   {
                        txtMessage.Text = "הסדנה נוספה בהצלחה";
                        txtMessage1.Text = "שיעורי הסדנה נוספו בהצלחה";
                        courseCombo.SelectedIndex = -1;
                        ststusCombo.SelectedIndex = -1;
                        discrabtion.Text = string.Empty;
                        price.Text = string.Empty;
                        numberOfLessons.Text = string.Empty;
                        btnCM.Visibility = Visibility.Visible;
                   
                   }
                 else
                   {
                        int m = await client.DeleteCourseAsync(C);
                        txtMessage.Text = "הסדנה לא נוספה אנא נסה שנית";
                        txtMessage1.Text = "שיעורי הסדנה לא נוספו אנא נסה שנית";
                   }
                }
                else
                {
                    txtMessage.Text = "הסדנה לא נוספה אנא נסה שנית";
                }
     
               
            }
            else
            {
                if (Legal.IsNumber(numberOfLessons.Text) == false)
                {
                    numberOfLessons.Text = "יש לכתוב מספרים בלבד";
                }
                if (Legal.IsNumber(price.Text) == false)
                {
                    price.Text = "יש לכתוב מספרים בלבד";
                }
                if (courseCombo.SelectedIndex<0)
                {
                    courseCombo.PlaceholderText = "חובה לבחור סוג סדנה";
                }
                if (ststusCombo.SelectedIndex < 0)
                {
                    ststusCombo.PlaceholderText = "חובה לבחור מצב סדנה";
                }

            }
        }

        private void CourseMmeting(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseMeeting),C);
        }
    }
}
