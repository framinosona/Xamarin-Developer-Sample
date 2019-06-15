using System;
using DeveloperSample.Core.Pages.BasePageFiles;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.Sample3
{
    public class Sample3PageViewModel : BaseViewModel
    {
        public Sample3PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sample 3";
        }
    }
}
