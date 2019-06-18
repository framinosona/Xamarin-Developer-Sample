using Xamarin.Forms;

namespace DeveloperSample.Core.Helpers
{
    public static class ColorExtensions
    {
        public static Color WithR(this Color baseColor, double newR)
        {
            return Color.FromRgba(newR, baseColor.G, baseColor.B, baseColor.A);
        }

        public static Color WithG(this Color baseColor, double newG)
        {
            return Color.FromRgba(baseColor.R, newG, baseColor.B, baseColor.A);
        }

        public static Color WithB(this Color baseColor, double newB)
        {
            return Color.FromRgba(baseColor.R, baseColor.G, newB, baseColor.A);
        }

        public static Color WithA(this Color baseColor, double newA)
        {
            return Color.FromRgba(baseColor.R, baseColor.G, baseColor.B, newA);
        }

        public static Color Inverse(this Color baseColor)
        {
            return Color.FromRgba(255 - baseColor.R, 255 - baseColor.G, 255 - baseColor.B, 255 - baseColor.A);
        }

        public static Color ToGrayScale(this Color baseColor)
        {
            return baseColor.WithSaturation(0);
        }

        public static Color ToBlackOrWhite(this Color baseColor)
        {
            return baseColor.R + baseColor.G + baseColor.B <= 127 ? Color.White : Color.Black;
        }

        public static Color ToBlackOrWhiteForText(this Color baseColor)
        {
            return baseColor.R * 0.299 + baseColor.G * 0.587 + baseColor.B * 0.114 <= 186 ? Color.White : Color.Black;
        }
    }
}