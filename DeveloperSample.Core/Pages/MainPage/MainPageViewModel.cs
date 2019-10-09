using System.Windows.Input;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using DeveloperSample.Core.Pages.Colors.Sample1;
using DeveloperSample.Core.Pages.DragAndDrop.Sample1;
using DeveloperSample.Core.Pages.DragAndDrop.Sample2;
using DeveloperSample.Core.Pages.DragAndDrop.Sample3;
using DeveloperSample.Core.Pages.Logging;
using DeveloperSample.Core.Pages.StatusBar;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
        }

        public ICommand NavigateToDragAndDropSample1 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(DragAndDropSample1Page)}"));
        public ICommand NavigateToDragAndDropSample2 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(DragAndDropSample2Page)}"));
        public ICommand NavigateToDragAndDropSample3 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(DragAndDropSample3Page)}"));
        public ICommand NavigateToColorSample1 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(ColorSample1Page)}"));
        public ICommand NavigateToLoggingSample =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(LoggingSamplePage)}"));
        public ICommand NavigateToStatusBarSample =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(StatusBarSamplePage)}"));
    }
}
