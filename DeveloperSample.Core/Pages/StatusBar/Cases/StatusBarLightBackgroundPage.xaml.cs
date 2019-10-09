using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSample.Core.Pages.StatusBar.Cases
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