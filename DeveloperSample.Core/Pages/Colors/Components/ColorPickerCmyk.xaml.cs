using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.Colors.Sample1;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Colors.Components
{
    public partial class ColorPickerCmyk
    {
        public ColorPickerCmyk()
        {
            InitializeComponent();
        }

        private void CyanValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithCyan(Cyan.Value);
        }

        private void MagentaValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithMagenta(Magenta.Value);
        }

        private void YellowValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is ColorSample1PageViewModel viewModel)
                viewModel.DisplayedColor = viewModel.DisplayedColor.WithYellow(Yellow.Value);
        }
    }
}