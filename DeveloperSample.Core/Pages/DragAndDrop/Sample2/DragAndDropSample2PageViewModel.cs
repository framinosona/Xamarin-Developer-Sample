using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample2
{
    public class DragAndDropSample2PageViewModel : BaseViewModel
    {
        public DragAndDropSample2PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sample 2";
        }
    }
}