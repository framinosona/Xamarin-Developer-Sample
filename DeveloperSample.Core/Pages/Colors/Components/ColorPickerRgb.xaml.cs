using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.Colors.Sample1;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Colors.Components
{
    public partial class ColorPickerRgb
    {
        public ColorPickerRgb()
        {
            InitializeComponent();
        }

        private void RedValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithRed(Red.Value);
        }

        private void GreenValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithGreen(Green.Value);
        }

        private void BlueValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithBlue(Blue.Value);
        }
    }
}