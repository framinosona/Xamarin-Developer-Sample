using System.Windows.Input;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateToDragAndDropSample1 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(DragAndDrop.Sample1.DragAndDropSample1Page)}"));
        public ICommand NavigateToDragAndDropSample2 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(DragAndDrop.Sample2.DragAndDropSample2Page)}"));
        public ICommand NavigateToDragAndDropSample3 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(DragAndDrop.Sample3.DragAndDropSample3Page)}"));
        public ICommand NavigateToColorSample1 =>
            new Command(async () =>
                await NavigationService.TryNavigateAsync($"{nameof(Colors.Sample1.ColorSample1Page)}"));

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}