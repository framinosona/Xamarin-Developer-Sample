using System;

namespace Framinosona.Color.Extensions
{
    public static class ColorExtensions
    {
        #region ToString

        public static string ToRgbString(this Xamarin.Forms.Color c)
        {
            return $"RGB({c.GetByteRed()},{c.GetByteGreen()},{c.GetByteBlue()})";
        }

        public static string ToRgbaString(this Xamarin.Forms.Color c)
        {
            return $"RGBA({c.GetByteRed()}, {c.GetByteGreen()}, {c.GetByteBlue()}, {c.GetByteAlpha()})";
        }

        public static string ToHexRgbString(this Xamarin.Forms.Color c)
        {
            return $"#{c.GetHexR():X2}{c.GetHexG():X2}{c.GetHexB():X2}";
        }

        public static string ToHexRgbaString(this Xamarin.Forms.Color c)
        {
            return $"#{c.GetHexR():X2}{c.GetHexG():X2}{c.GetHexB():X2}{c.GetHexA():X2}";
        }

        public static string ToCmyString(this Xamarin.Forms.Color c)
        {
            return $"CMYK({c.GetCyan():P},{c.GetMagenta():P},{c.GetYellow():P})";
        }

        public static string ToCmykString(this Xamarin.Forms.Color c)
        {
            return $"CMYK({c.GetCyan():P},{c.GetMagenta():P},{c.GetYellow():P},{c.GetBlackKey():P})";
        }

        #endregion

        #region Setters

        public static Xamarin.Forms.Color WithRed(this Xamarin.Forms.Color baseColor, double newR)
        {
            return Xamarin.Forms.Color.FromRgba(newR, baseColor.G, baseColor.B, baseColor.A);
        }

        public static Xamarin.Forms.Color WithGreen(this Xamarin.Forms.Color baseColor, double newG)
        {
            return Xamarin.Forms.Color.FromRgba(baseColor.R, newG, baseColor.B, baseColor.A);
        }

        public static Xamarin.Forms.Color WithBlue(this Xamarin.Forms.Color baseColor, double newB)
        {
            return Xamarin.Forms.Color.FromRgba(baseColor.R, baseColor.G, newB, baseColor.A);
        }

        public static Xamarin.Forms.Color WithAlpha(this Xamarin.Forms.Color baseColor, double newA)
        {
            return Xamarin.Forms.Color.FromRgba(baseColor.R, baseColor.G, baseColor.B, newA);
        }

        public static Xamarin.Forms.Color WithCyan(this Xamarin.Forms.Color baseColor, double newC)
        {
            return Xamarin.Forms.Color.FromRgba(
                (1 - newC) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetMagenta()) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetYellow()) * (1 - baseColor.GetBlackKey()),
                baseColor.A);
        }

        public static Xamarin.Forms.Color WithMagenta(this Xamarin.Forms.Color baseColor, double newM)
        {
            return Xamarin.Forms.Color.FromRgba(
                (1 - baseColor.GetCyan()) * (1 - baseColor.GetBlackKey()),
                (1 - newM) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetYellow()) * (1 - baseColor.GetBlackKey()),
                baseColor.A);
        }

        public static Xamarin.Forms.Color WithYellow(this Xamarin.Forms.Color baseColor, double newY)
        {
            return Xamarin.Forms.Color.FromRgba(
                (1 - baseColor.GetCyan()) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetMagenta()) * (1 - baseColor.GetBlackKey()),
                (1 - newY) * (1 - baseColor.GetBlackKey()),
                baseColor.A);
        }

        #endregion

        #region Getters Byte

        public static byte GetByteRed(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte(c.R * 255);
        }

        public static byte GetByteGreen(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte(c.G * 255);
        }

        public static byte GetByteBlue(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte(c.B * 255);
        }

        public static byte GetByteAlpha(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte(c.A * 255);
        }

        public static byte GetByteCyan(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte((1 - c.R) * 255);
        }

        public static byte GetByteMagenta(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte((1 - c.G) * 255);
        }

        public static byte GetByteYellow(this Xamarin.Forms.Color c)
        {
            return NumericExtensions.EnsureByte((1 - c.B) * 255);
        }

        #endregion

        #region Getters Hex

        public static int GetHexR(this Xamarin.Forms.Color c)
        {
            return c.GetByteRed();
        }

        public static int GetHexG(this Xamarin.Forms.Color c)
        {
            return c.GetByteGreen();
        }

        public static int GetHexB(this Xamarin.Forms.Color c)
        {
            return c.GetByteBlue();
        }

        public static int GetHexA(this Xamarin.Forms.Color c)
        {
            return c.GetByteAlpha();
        }

        #endregion

        #region Getters double

        public static double GetBlackKey(this Xamarin.Forms.Color c)
        {
            return 1 - Math.Max(Math.Max(c.R, c.G), c.B);
        }

        public static double GetCyan(this Xamarin.Forms.Color c)
        {
            return (1 - c.R - c.GetBlackKey()) / (1 - c.GetBlackKey());
        }

        public static double GetMagenta(this Xamarin.Forms.Color c)
        {
            return (1 - c.G - c.GetBlackKey()) / (1 - c.GetBlackKey());
        }

        public static double GetYellow(this Xamarin.Forms.Color c)
        {
            return (1 - c.B - c.GetBlackKey()) / (1 - c.GetBlackKey());
        }

        #endregion

        #region Converters

        public static Xamarin.Forms.Color Inverse(this Xamarin.Forms.Color baseColor)
        {
            return Xamarin.Forms.Color.FromRgb(1 - baseColor.R, 1 - baseColor.G, 1 - baseColor.B);
        }

        public static Xamarin.Forms.Color ToBlackOrWhite(this Xamarin.Forms.Color baseColor)
        {
            return baseColor.IsDark() ? Xamarin.Forms.Color.Black : Xamarin.Forms.Color.White;
        }

        public static Xamarin.Forms.Color ToBlackOrWhiteForText(this Xamarin.Forms.Color baseColor)
        {
            return baseColor.IsDarkForTheEye() ? Xamarin.Forms.Color.White : Xamarin.Forms.Color.Black;
        }

        public static Xamarin.Forms.Color ToGrayScale(this Xamarin.Forms.Color baseColor)
        {
            var avg = (baseColor.R + baseColor.B + baseColor.G) / 3;
            return Xamarin.Forms.Color.FromRgb(avg, avg, avg);
        }

        #endregion

        #region Booleans

        public static bool IsDarkForTheEye(this Xamarin.Forms.Color c)
        {
            return c.GetHexR() * 0.299 + c.GetHexG() * 0.587 + c.GetHexB() * 0.114 <= 186;
        }

        public static bool IsDark(this Xamarin.Forms.Color c)
        {
            return c.GetHexR() + c.GetHexG() + c.GetHexB() <= 127 * 3;
        }

        #endregion
    }
}