using DeveloperSample.Core.Pages.Colors.Sample1;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Colors.Components
{
    public partial class ColorPickerHsl
    {
        public ColorPickerHsl()
        {
            InitializeComponent();
        }

        private void HueValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithHue(Hue.Value);
            UpdateThumbColors();
        }

        private void SatValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithSaturation(Sat.Value);
            UpdateThumbColors();
        }

        private void LumValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithLuminosity(Lum.Value);
            UpdateThumbColors();
        }

        private void UpdateThumbColors()
        {
            if (!(BindingContext is ColorSample1PageViewModel viewModel)) return;
            Hue.ThumbColor = viewModel.DisplayedColor.WithSaturation(1.0).WithLuminosity(0.5);
            Sat.ThumbColor = viewModel.DisplayedColor.WithLuminosity(0.5);
            Lum.ThumbColor = viewModel.DisplayedColor.WithSaturation(1.0);
        }
    }
}