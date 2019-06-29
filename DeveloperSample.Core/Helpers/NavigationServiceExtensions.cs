using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Helpers
{
    public static class NavigationServiceExtensions
    {
        public static async Task TryNavigateAsync(this INavigationService navigationService, Uri uri,
            INavigationParameters parameters = null)
        {
            var result = await navigationService.NavigateAsync(uri, parameters);
            HandleNavigationResult(result);
        }

        public static async Task TryNavigateModallyAsync(this INavigationService navigationService, Uri uri,
            INavigationParameters parameters = null)
        {
            var result = await navigationService.NavigateAsync(uri, parameters, true);
            HandleNavigationResult(result);
        }

        public static async Task TryNavigateAsync(this INavigationService navigationService, string path,
            INavigationParameters parameters = null)
        {
            var result = await navigationService.NavigateAsync(path, parameters);
            HandleNavigationResult(result);
        }

        public static async Task TryNavigateModallyAsync(this INavigationService navigationService, string path,
            INavigationParameters parameters = null)
        {
            var result = await navigationService.NavigateAsync(path, parameters, true);
            HandleNavigationResult(result);
        }

        public static async Task TryNavigateBackAsync(this INavigationService navigationService,
            INavigationParameters parameters = null)
        {
            var result = await navigationService.GoBackAsync(parameters);
            HandleNavigationResult(result);
        }

        private static void HandleNavigationResult(INavigationResult navigationResult)
        {
            if (!navigationResult.Success)
            {
                Exception ex = new InvalidNavigationException();
                if (navigationResult.Exception != null)
                    ex = navigationResult.Exception;
                SetMainPageFromException(ex);
            }
        }

        private static void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            PrismApplicationBase.Current.MainPage = new ContentPage
            {
                Content = layout
            };
        }
    }
}