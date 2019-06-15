using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.MainPage;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DeveloperSample.Core.Pages.Sample1;
using DeveloperSample.Core.Pages.Sample2;
using DeveloperSample.Core.Pages.Sample3;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeveloperSample.Core
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
        }

        protected override void OnStart()
        {
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
            containerRegistry.RegisterForNavigation<Sample1Page>();
            containerRegistry.RegisterForNavigation<Sample2Page>();
            containerRegistry.RegisterForNavigation<Sample3Page>();
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