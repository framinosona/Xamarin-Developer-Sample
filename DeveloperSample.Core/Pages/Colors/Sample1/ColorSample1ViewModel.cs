using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.Colors.Sample1
{
    public class ColorSample1ViewModel : BaseViewModel
    {
        public ColorSample1ViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Color Sample 1";
        }
    }
}