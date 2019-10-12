using System;
using DeveloperSample.Core.Pages.StatusBar;
using DeveloperSample.iOS.Helpers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Page), typeof(StatusBarRenderer))]

namespace DeveloperSample.iOS.Helpers
{
    public class StatusBarRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            SetStatusBarStyle(StatusBar.GetStatusBarStyle(Element));
        }

        private void SetStatusBarStyle(StatusBarStyle statusBarStyle)
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

            SetNeedsStatusBarAppearanceUpdate();
        }
    }
}