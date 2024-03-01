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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       public  Service1Client client1 = new Service1Client();
        List<ServiceReference4.Customers> customersList = null;
        List<ServiceReference4.PersonalMeeting> personalMeetingsList = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void customerPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Customers));

        }

        private void registrationPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registration));
        }

        private void coursePage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Course));

        }

        private void personalMeetingPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PersonalMeeting));

        }

        private void Setting(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Setting));
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            customersList = await client1.GetCustomersListAsync();
            personalMeetingsList = await client1.GetPersonalMeetingListAsync();
          

        }

        private void Calender(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calender));
        }
    }
}
