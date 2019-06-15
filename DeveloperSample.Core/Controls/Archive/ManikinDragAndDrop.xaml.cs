using DeveloperSample.Core.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSample.Core.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManikinDragAndDrop : ViewCell
    {
        public ManikinDragAndDrop()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.Trace();
        }
    }
}
