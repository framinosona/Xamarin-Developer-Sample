using System.Windows.Input;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using DeveloperSample.Core.Pages.StatusBar.Cases;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.StatusBar
{
    public class StatusBarSamplePageViewModel : BaseViewModel
    {
        public StatusBarSamplePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "StatusBar Sample";
        }

        public ICommand NavigateToStatusBarDarkBackgroundPage =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(StatusBarDarkBackgroundPage)}"));

        public ICommand NavigateToStatusBarLightBackgroundPage =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(StatusBarLightBackgroundPage)}"));

        public ICommand NavigateToStatusBarVideoBackgroundPage =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(StatusBarVideoBackgroundPage)}"));
    }
}