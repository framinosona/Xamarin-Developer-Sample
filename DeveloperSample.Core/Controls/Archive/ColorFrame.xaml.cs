using Xamarin.Forms;
using System.ComponentModel;

namespace DeveloperSample.Core.Controls
{
    [DesignTimeVisible(true)]
    public partial class ColorFrame : ContentView
    {

        #region Color

        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public string ColorToString => $"Color R:{Color.R}, G:{Color.G}, B:{Color.B}, A:{Color.A}";


        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            nameof(ColorProperty),
            typeof(Color),
            typeof(ColorFrame),
            Color.White,
            propertyChanged: OnColorChanged);

        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ColorFrame colorFrame)
                colorFrame.OnPropertyChanged(nameof(ColorToString));
        }

        #endregion

        #region TextColor

        public Color TextColor
        {
            get => (Color) GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public string TextColorToString => $"TextColor R:{TextColor.R}, G:{TextColor.G}, B:{TextColor.B}, A:{TextColor.A}";

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColorProperty),
            typeof(Color),
            typeof(ColorFrame),
            Color.Black,
            propertyChanged: OnTextColorChanged);

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ColorFrame colorFrame)
                colorFrame.OnPropertyChanged(nameof(TextColorToString));
        }

        #endregion

        #region Title

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(TitleProperty),
            typeof(string),
            typeof(ColorFrame),
            "Color");

        #endregion

        public ColorFrame()
        {
            InitializeComponent();
        }
    }
}
