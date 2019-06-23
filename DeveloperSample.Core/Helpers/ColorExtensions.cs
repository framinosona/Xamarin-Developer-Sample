using Xamarin.Forms;

namespace DeveloperSample.Core.Helpers
{
    public static class ColorExtensions
    {
        #region ToString
        public static string ToRgbString(this Color c) => $"RGB({c.GetByteR()}, {c.GetByteG()}, {c.GetByteB()})";
        public static string ToRgbaString(this Color c) => $"RGBA({c.GetByteR()}, {c.GetByteG()}, {c.GetByteB()}, {c.GetByteA()})";
        public static string ToHexRgbString(this Color c) => $"#{c.GetHexR():X2}{c.GetHexG():X2}{c.GetHexB():X2}";
        public static string ToHexRgbaString(this Color c) => $"#{c.GetHexR():X2}{c.GetHexG():X2}{c.GetHexB():X2}{c.GetHexA():X2}";
        #endregion

        #region Setters
        public static Color WithR(this Color baseColor, double newR) => Color.FromRgba(newR, baseColor.G, baseColor.B, baseColor.A);
        public static Color WithG(this Color baseColor, double newG) => Color.FromRgba(baseColor.R, newG, baseColor.B, baseColor.A);
        public static Color WithB(this Color baseColor, double newB) => Color.FromRgba(baseColor.R, baseColor.G, newB, baseColor.A);
        public static Color WithA(this Color baseColor, double newA) => Color.FromRgba(baseColor.R, baseColor.G, baseColor.B, newA);
        #endregion

        #region Getters Byte
        public static byte GetByteR(this Color c) => NumericExtensions.EnsureByte(c.R * 255);
        public static byte GetByteG(this Color c) => NumericExtensions.EnsureByte(c.G * 255);
        public static byte GetByteB(this Color c) => NumericExtensions.EnsureByte(c.B * 255);
        public static byte GetByteA(this Color c) => NumericExtensions.EnsureByte(c.A * 255);
        #endregion

        #region Getters Hex
        public static int GetHexR(this Color c) => c.GetByteR();
        public static int GetHexG(this Color c) => c.GetByteG();
        public static int GetHexB(this Color c) => c.GetByteB();
        public static int GetHexA(this Color c) => c.GetByteA();
        #endregion

        #region Converters
        public static Color Inverse(this Color baseColor) => Color.FromRgb(1 - baseColor.R, 1 - baseColor.G, 1 - baseColor.B);
        public static Color ToBlackOrWhite(this Color baseColor) => baseColor.IsDark() ? Color.Black : Color.White;
        public static Color ToBlackOrWhiteForText(this Color baseColor) => baseColor.IsDarkForTheEye() ? Color.White : Color.Black;

        public static Color ToGrayScale(this Color baseColor)
        {
            double avg = (baseColor.R + baseColor.B + baseColor.G) / 3;
            return Color.FromRgb(avg, avg, avg);
        }
        #endregion

        #region Booleans
        public static bool IsDarkForTheEye(this Color c) => c.GetHexR() * 0.299 + c.GetHexG() * 0.587 + c.GetHexB() * 0.114 <= 186;
        public static bool IsDark(this Color c) => c.GetHexR() + c.GetHexG() + c.GetHexB() <= 127 * 3;
        #endregion
    }
}