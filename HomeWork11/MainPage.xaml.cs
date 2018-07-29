using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using HomeWork11.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HomeWork11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnStewardesses_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(StewardessesView));
        }

        private void BtnDepartures_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(DeparturesView));
        }

        private void BtnCrews_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPilots_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlaneTypes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPlanes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFlights_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTickets_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
