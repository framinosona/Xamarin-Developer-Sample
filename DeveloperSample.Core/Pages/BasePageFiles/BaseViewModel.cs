using DeveloperSample.Core.Helpers;
using Prism.Mvvm;
using Prism.Navigation;

namespace DeveloperSample.Core.Pages.BasePageFiles
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        private string _title;

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        protected INavigationService NavigationService { get; }

        public virtual void Destroy()
        {
            this.Trace();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            this.Trace();
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            this.Trace();
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            this.Trace();
        }
    }
}