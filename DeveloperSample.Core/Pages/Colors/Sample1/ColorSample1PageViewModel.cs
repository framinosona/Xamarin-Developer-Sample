using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Colors.Sample1
{
    public class ColorSample1PageViewModel : BaseViewModel
    {
        private Color _displayedColor = Color.White;

        public ColorSample1PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Color Sample 1";
        }

        public Color DisplayedColor
        {
            get => _displayedColor;
            set => SetProperty(ref _displayedColor, value);
        }
    }
}