using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.Colors.Sample1;
using DeveloperSample.Core.Pages.DragAndDrop.Sample1;
using DeveloperSample.Core.Pages.DragAndDrop.Sample2;
using DeveloperSample.Core.Pages.DragAndDrop.Sample3;
using DeveloperSample.Core.Pages.Logging;
using DeveloperSample.Core.Pages.MainPage;
using DeveloperSample.Core.Pages.StatusBar;
using DeveloperSample.Core.Pages.StatusBar.Cases;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace DeveloperSample.Core
{
    public partial class App
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=7123acdf-b4c7-494a-8652-7839fed1ddbb;" +
                            "android=ee1dbbe2-a7f6-4905-9b29-46f2b088359d;",
                typeof(Analytics), typeof(Crashes));
            // Handle when your app starts
            this.Trace();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            this.Trace();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.Trace();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<DragAndDropSample1Page>();
            containerRegistry.RegisterForNavigation<DragAndDropSample2Page>();
            containerRegistry.RegisterForNavigation<DragAndDropSample3Page>();
            containerRegistry.RegisterForNavigation<ColorSample1Page>();
            containerRegistry.RegisterForNavigation<LoggingSamplePage>();
            containerRegistry.RegisterForNavigation<StatusBarSamplePage>();
            containerRegistry.RegisterForNavigation<StatusBarDarkBackgroundPage, BaseStatusBarPageViewModel>();
            containerRegistry.RegisterForNavigation<StatusBarLightBackgroundPage, BaseStatusBarPageViewModel>();
            containerRegistry.RegisterForNavigation<StatusBarVideoBackgroundPage, BaseStatusBarPageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            this.Trace();

            await NavigationService.TryNavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            this.Trace();
        }
    }
}