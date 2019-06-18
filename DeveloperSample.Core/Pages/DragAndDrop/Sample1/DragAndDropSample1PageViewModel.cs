using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample1
{
    public class DragAndDropSample1PageViewModel : BaseViewModel
    {
        public DragAndDropSample1PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sample 1";
        }
    }
}