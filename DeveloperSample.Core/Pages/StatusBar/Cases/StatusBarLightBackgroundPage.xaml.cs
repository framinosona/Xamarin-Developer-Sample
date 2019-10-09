using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSample.Core.Pages.StatusBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusBarLightBackgroundPage : ContentPage
    {
        public StatusBarLightBackgroundPage()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}