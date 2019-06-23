using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.Colors.Sample1;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Colors.Components
{
    public partial class ColorPickerRGB : ContentView
    {
        private void RedValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithR(Red.Value);
        }

        private void GreenValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithG(Green.Value);
        }

        private void BlueValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithB(Blue.Value);
        }

        public ColorPickerRGB()
        {
            InitializeComponent();
        }
    }
}