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
    public sealed partial class Setting : Page
    {
        Service1Client client = new Service1Client();
        List<ServiceReference4.Cities> citiesList = null;
        List<ServiceReference4.TypeAdvice> typeAdvicesList = null;
        List<ServiceReference4.TypeCourse> typeCoursesList = null;


        public Setting()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

            citiesList = await client.GetCitiesListAsync();
            cityCombo.ItemsSource = citiesList;

            typeAdvicesList = await client.GetTypeAdviceListAsync();
            adviceCombo.ItemsSource = typeAdvicesList;

            typeCoursesList = await client.GetTypeCourseListAsync();
            coursesCombo.ItemsSource = typeCoursesList;

            cityCombo.SelectedIndex = -1;
            coursesCombo.SelectedIndex = -1;
            adviceCombo.SelectedIndex = -1;

        }

        private async void Delete1(object sender, RoutedEventArgs e)
        {

            if ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag.ToString() == "city")
            {
                ServiceReference4.Cities c = new ServiceReference4.Cities();

                if (Legal.IsHebrew(txt1.Text))
                {
                    if (cityCombo.SelectedIndex > 0)
                    {
                        c = (ServiceReference4.Cities)(cityCombo.SelectedItem);
                        c.nameCity = txt1.Text;
                        int d = await client.UpdateCitiesAsync(c);
                         if(d>0)
                            txt1.Text = "העדכון בוצע בהצלחה";
                         else
                            txt1.Text = "העדכון לק בוצע נא נסה שנית";


                    }
                    else
                    {
                        c.code = await client.GetCodeToCityAsync();
                        c.nameCity = txt1.Text;
                        int d = await client.AddCityAsync(c);
                        if (d > 0)
                          
                        txt1.Text = "ההוספה בוצעה בהצלחה";
                        else
                            txt1.Text = "ההוספה לא בוצעה נא נסה שנית";


                    }
                }
                else
                {
                    if (cityCombo.SelectedIndex > 0)
                    {
                       c = (ServiceReference4.Cities)(cityCombo.SelectedItem);
                       int   d =   await client.DeleteCityAsync(c);
                        if(d>0)
                        txt1.Text = "המחיקה בוצע בהצלחה";
                        else
                            txt1.Text = "המחיקה לא בוצעה נא נסה שנית";

                    }
                    else
                    {
                        txt1.Header = "יש לכתוב שם בעברית בלבד";
                    }
                }
            }
            if ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag.ToString() == "course")
            {

                ServiceReference4.TypeCourse c = new ServiceReference4.TypeCourse();

                if (Legal.IsHebrew(txt.Text))
                {
                    if (coursesCombo.SelectedIndex > 0)
                    {
                        c = (ServiceReference4.TypeCourse)(coursesCombo.SelectedItem);
                        c.nameTypeCourse = txt.Text;
                       int d = await client.UpdateTypeCurseAsync(c);
                        if (d > 0)
                            txt.Text = "העדכון בוצע בהצלחה";
                        else
                            txt.Text = "העדכון לא בוצע נא נסה שנית";

                    }
                    else
                    {
                        c.code = await client.GetCodeToTypeAdviceAsync();
                        c.nameTypeCourse = txt.Text;
                       int d =  await client.AddTypeCourseAsync(c);
                        if (d > 0)
                            txt.Text = "ההוספה בוצעה בהצלחה";
                        else
                            txt.Text = "ההוספה לא בוצעה נא נסה שנית";

                    }
                }
                else
                {
                    if(coursesCombo.SelectedIndex > 0)
                    {
                        c = (ServiceReference4.TypeCourse)(coursesCombo.SelectedItem);
                       int d =     await client.DeleteTypeCourseAsync(c);
                        if (d > 0)
                            txt.Text = "המחיקה בוצעה בהצלחה";
                        else
                            txt.Text = "המחיקה לא בוצעה נא נסה שנית";
                    }
                    else
                    {
                       txt.Header = "יש לכתוב שם בעברית בלבד";
                    }
                   
                }
            }
            if ((((sender as Button).Parent as StackPanel).Parent as StackPanel).Tag.ToString() == "advice")
            {

                ServiceReference4.TypeAdvice a = new ServiceReference4.TypeAdvice();
                if (Legal.IsHebrew(txt2.Text))
                {
                    if (adviceCombo.SelectedIndex > 0)
                    {
                        a = (ServiceReference4.TypeAdvice)(adviceCombo.SelectedItem);
                        a.nameTypeAdvice = txt2.Text;
                     int d =   await client.UpdateTypeAdviceAsync(a);

                        if (d > 0)
                            txt2.Text = "העדכון בוצע בהצלחה";
                        else
                            txt2.Text = "העדכון לא בוצע נא נסה שנית";
                    }
                    else
                    {
                        a.code = await client.GetCodeToTypeAdviceAsync();
                        a.nameTypeAdvice = txt2.Text;

                       int d = await client.AddTypeAdviceAsync(a);
                       if(d>0)
                        txt2.Text = "ההוספה בוצעה בהצלחה";
                          else
                            txt2.Text = "ההוספה לא בוצעה נא נסה שנית";

                    }
                }
                else
                {
                    if (adviceCombo.SelectedIndex > 0)
                    {
                        a= (ServiceReference4.TypeAdvice)(adviceCombo.SelectedItem);
                   int d =       await client.DeleteTypeAdviceAsync(a);
                          if (d > 0)
                            txt2.Text = "המחיקה בוצעה בהצלחה";
                        else
                            txt2.Text = "המחיקה לא בוצעה נא נסה שנית";
                    }
                    else
                    {
                        txt2.Header = "יש לכתוב שם בעברית בלבד";
                    }
                }
            }
        
        }
    


        private void SetCities(object sender, RoutedEventArgs e)
            {
            stackCity.Visibility = Visibility.Visible;
            stackCourses.Visibility = Visibility.Collapsed;
            stackAdvice.Visibility = Visibility.Collapsed;
            cityCombo.SelectedIndex = -1;
            txt2.Text = "";
            txt.Text = "";
            txt.Header = "";
            txt2.Header = "";

        }

        private void SetAdvices(object sender, RoutedEventArgs e)
        {
            stackCity.Visibility = Visibility.Collapsed;
            stackCourses.Visibility = Visibility.Collapsed;
            stackAdvice.Visibility = Visibility.Visible;  
           
            adviceCombo.SelectedIndex = -1;
            txt.Text = "";
            txt1.Text = "";
            txt.Header = "";
            txt1.Header = "";
        }

        private void SetCourses(object sender, RoutedEventArgs e)
        {
            stackCity.Visibility = Visibility.Collapsed;
            stackCourses.Visibility = Visibility.Visible;
            stackAdvice.Visibility = Visibility.Collapsed;
            coursesCombo.SelectedIndex = -1;
            txt2.Text = "";
            txt1.Text = "";
            txt2.Header = "";
            txt1.Header = "";
        }

      
    }
}
