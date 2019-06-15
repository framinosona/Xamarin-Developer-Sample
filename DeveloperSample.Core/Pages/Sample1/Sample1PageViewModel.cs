using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.Sample1
{
    public class Sample1PageViewModel : BaseViewModel
    {
        public Sample1PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sample 1";
        }
    }
}
