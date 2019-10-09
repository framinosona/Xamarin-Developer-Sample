
using DeveloperSample.Core.Pages.StatusBar;
using DeveloperSample.iOS.Helpers.StatusBar;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;


[assembly: ExportRenderer(typeof(ContentPage), typeof(StatusBarNavigationRendrerer))]
namespace DeveloperSample.iOS.Helpers.StatusBar
{
    public class StatusBarNavigationRendrerer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            DependencyService.Get<IStatusBarRenderer>()?.SetStatusBarStyle(Core.Pages.StatusBar.StatusBar.GetStatusBarStyle(Element));
        }
    }
}