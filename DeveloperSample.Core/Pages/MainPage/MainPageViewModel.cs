using System.Windows.Input;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using DeveloperSample.Core.Pages.Sample1;
using DeveloperSample.Core.Pages.Sample2;
using DeveloperSample.Core.Pages.Sample3;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateToSample1 => new Command(async () => await NavigationService.TryNavigateAsync($"{nameof(Sample1Page)}"));
        public ICommand NavigateToSample2 => new Command(async () => await NavigationService.TryNavigateAsync($"{nameof(Sample2Page)}"));
        public ICommand NavigateToSample3 => new Command(async () => await NavigationService.TryNavigateAsync($"{nameof(Sample3Page)}"));

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}