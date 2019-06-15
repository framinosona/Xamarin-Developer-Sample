using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSample.Core.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultResourceDictionary : ResourceDictionary
    {
        public DefaultResourceDictionary()
        {
            InitializeComponent();
        }
    }
}