using Xamarin.Forms;

namespace DeveloperSample.Core.Controls.Archive
{
    public partial class CustomSlider : ContentView
    {
        #region Value

        public int Value
        {
            get => (int) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(ValueProperty),
            typeof(int),
            typeof(CustomSlider),
            0);
        #endregion

        #region Maximum

        public int Maximum
        {
            get => (int) GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(
            nameof(MaximumProperty),
            typeof(int),
            typeof(CustomSlider),
            10);
        #endregion

        #region Minimum

        public int Minimum
        {
            get => (int) GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(
            nameof(MinimumProperty),
            typeof(int),
            typeof(CustomSlider),
            0);
        #endregion

        #region Orientation

        public StackOrientation Orientation
        {
            get => (StackOrientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
            nameof(OrientationProperty),
            typeof(StackOrientation),
            typeof(CustomSlider),
            StackOrientation.Horizontal);

        #endregion

        public CustomSlider()
        {
            InitializeComponent();

        }

        private void RepositionBackgroundFrame()
        {

        }
    }
}
