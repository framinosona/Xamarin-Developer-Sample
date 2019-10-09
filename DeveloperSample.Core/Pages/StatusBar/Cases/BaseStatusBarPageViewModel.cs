using System.Windows.Input;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.StatusBar.Cases
{
    public class BaseStatusBarPageViewModel : BaseViewModel
    {

        public BaseStatusBarPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public ICommand NavigateBack =>
            new Command(async () =>
                await NavigationService.TryNavigateBackAsync());
    }
}