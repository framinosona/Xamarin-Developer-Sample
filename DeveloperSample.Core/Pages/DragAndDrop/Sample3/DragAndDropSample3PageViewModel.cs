using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3
{
    public class DragAndDropSample3PageViewModel : BaseViewModel
    {
        public DragAndDropSample3PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sample 3";
        }
    }
}