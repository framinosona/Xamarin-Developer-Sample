using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.Sample2
{
    public class Sample2PageViewModel : BaseViewModel
    {
        public Sample2PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sample 2";
        }
    }
}
