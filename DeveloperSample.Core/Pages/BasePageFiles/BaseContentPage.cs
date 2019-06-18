using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.BasePageFiles
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is BaseViewModel viewModelBase)
                Title = viewModelBase.Title;
        }
    }
}