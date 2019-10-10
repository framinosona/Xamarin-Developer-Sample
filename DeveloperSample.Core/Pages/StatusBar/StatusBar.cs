using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Page = Xamarin.Forms.Page;

namespace DeveloperSample.Core.Pages.StatusBar
{
    public enum StatusBarStyle
    {
        Default,
        // Will behave as normal. 
        // White text on black NavigationBar/in Dark iOS theme and 
        // Black text on white NavigationBar/in Light mode
        DarkText,
        // Will switch the color of content of StatusBar to black. 
        WhiteText,
        // Will switch the color of content of StatusBar to white. 
        Hidden
        // Will hide the StatusBar
    }

    public static class StatusBar
    {
        public static readonly BindableProperty StatusBarStyleProperty = BindableProperty.CreateAttached(
            "StatusBarStyle",
            typeof(StatusBarStyle),
            typeof(Page),
            StatusBarStyle.Default);

        public static void SetStatusBarStyle(BindableObject page, StatusBarStyle value) => page.SetValue(StatusBarStyleProperty, value);
        public static StatusBarStyle GetStatusBarStyle(BindableObject page) => (StatusBarStyle) page.GetValue(StatusBarStyleProperty);

        public static StatusBarStyle GetStatusBarStyle(this IPlatformElementConfiguration<iOS, Page> config)
        {
            return GetStatusBarStyle(config.Element);
        }

        public static IPlatformElementConfiguration<iOS, Page> SetStatusBarStyle(this IPlatformElementConfiguration<iOS, Page> config, StatusBarStyle value)
        {
            SetStatusBarStyle(config.Element, value);
            return config;
        }
    }
}