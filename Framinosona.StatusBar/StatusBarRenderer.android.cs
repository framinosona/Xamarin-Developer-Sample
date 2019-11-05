
using System;
using Android.App;
using Android.Content;
using Android.Views;
using Framinosona.StatusBar;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Page), typeof(StatusBarRenderer))]
namespace Framinosona.StatusBar
{
    public class StatusBarRenderer : PageRenderer
    {
        public StatusBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            SetStatusBarStyle(StatusBar.GetStatusBarStyle(Element));
        }
        
        
        private void SetStatusBarStyle(StatusBarStyle statusBarStyle)
        {
            var activity = GetCurrentActivity();
            switch (statusBarStyle)
            {
                case StatusBarStyle.DarkText:
                    activity.Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Black);
                    break;
                case StatusBarStyle.WhiteText:
                    activity.Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                    activity.Window.SetStatusBarColor(Android.Graphics.Color.White);
                    break;
                case StatusBarStyle.Hidden:
                    activity.Window.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
                    break;
                case StatusBarStyle.Default:
                default:
                    activity.Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                    break;
            }
        }
        
        Activity GetCurrentActivity()
        {
            try
            {
                return this.Context as Activity;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}