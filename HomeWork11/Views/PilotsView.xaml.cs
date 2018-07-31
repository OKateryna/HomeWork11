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
using HomeWork11.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HomeWork11.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PilotsView : Page
    {
        public PilotsView()
        {
            this.InitializeComponent();
            this.ViewModel = new PilotViewModel();
        }

        private async void PilotsView_OnLoading(FrameworkElement sender, object args)
        {
            await ViewModel.Initialization;
        }

        public PilotViewModel ViewModel { get; set; }
    }
}
