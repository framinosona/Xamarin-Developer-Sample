using System;
using DeveloperSample.Core.Pages.StatusBar;
using DeveloperSample.iOS.Helpers.StatusBar;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBarRenderer))]
namespace DeveloperSample.iOS.Helpers.StatusBar
{
    public class StatusBarRenderer : IStatusBarRenderer
    {
        public void SetStatusBarStyle(StatusBarStyle statusBarStyle)
        {
            switch (statusBarStyle)
            {
                case StatusBarStyle.DarkText:
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.DarkContent, true);
                    UIApplication.SharedApplication.SetStatusBarHidden(false, true);
                    break;
                case StatusBarStyle.WhiteText:
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
                    UIApplication.SharedApplication.SetStatusBarHidden(false, true);
                    break;
                case StatusBarStyle.Hidden:
                    UIApplication.SharedApplication.SetStatusBarHidden(true, true);
                    break;
                case StatusBarStyle.Default:
                default:
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, true);
                    UIApplication.SharedApplication.SetStatusBarHidden(false, true);
                    break;
            }

            GetCurrentViewController()?.SetNeedsStatusBarAppearanceUpdate();
        }
        
        UIViewController GetCurrentViewController()
        {
            try
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                    vc = vc.PresentedViewController;
                return vc;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}