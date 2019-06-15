using Xamarin.Forms;

namespace DeveloperSample.Core.Controls
{
    public partial class ManikinListItem : ContentView
    {
        public ManikinListItem()
        {
            InitializeComponent();
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
