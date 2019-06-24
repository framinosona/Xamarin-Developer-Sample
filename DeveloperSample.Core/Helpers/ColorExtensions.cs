using System;
using Xamarin.Forms;

namespace DeveloperSample.Core.Helpers
{
    public static class ColorExtensions
    {
        #region ToString

        public static string ToRgbString(this Color c)
        {
            return $"RGB({c.GetByteRed()},{c.GetByteGreen()},{c.GetByteBlue()})";
        }

        public static string ToRgbaString(this Color c)
        {
            return $"RGBA({c.GetByteRed()}, {c.GetByteGreen()}, {c.GetByteBlue()}, {c.GetByteAlpha()})";
        }

        public static string ToHexRgbString(this Color c)
        {
            return $"#{c.GetHexR():X2}{c.GetHexG():X2}{c.GetHexB():X2}";
        }

        public static string ToHexRgbaString(this Color c)
        {
            return $"#{c.GetHexR():X2}{c.GetHexG():X2}{c.GetHexB():X2}{c.GetHexA():X2}";
        }

        public static string ToCmyString(this Color c)
        {
            return $"CMYK({c.GetCyan():P},{c.GetMagenta():P},{c.GetYellow():P})";
        }

        public static string ToCmykString(this Color c)
        {
            return $"CMYK({c.GetCyan():P},{c.GetMagenta():P},{c.GetYellow():P},{c.GetBlackKey():P})";
        }

        #endregion

        #region Setters

        public static Color WithRed(this Color baseColor, double newR)
        {
            return Color.FromRgba(newR, baseColor.G, baseColor.B, baseColor.A);
        }

        public static Color WithGreen(this Color baseColor, double newG)
        {
            return Color.FromRgba(baseColor.R, newG, baseColor.B, baseColor.A);
        }

        public static Color WithBlue(this Color baseColor, double newB)
        {
            return Color.FromRgba(baseColor.R, baseColor.G, newB, baseColor.A);
        }

        public static Color WithAlpha(this Color baseColor, double newA)
        {
            return Color.FromRgba(baseColor.R, baseColor.G, baseColor.B, newA);
        }

        public static Color WithCyan(this Color baseColor, double newC)
        {
            return Color.FromRgba(
                (1 - newC) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetMagenta()) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetYellow()) * (1 - baseColor.GetBlackKey()),
                baseColor.A);
        }

        public static Color WithMagenta(this Color baseColor, double newM)
        {
            return Color.FromRgba(
                (1 - baseColor.GetCyan()) * (1 - baseColor.GetBlackKey()),
                (1 - newM) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetYellow()) * (1 - baseColor.GetBlackKey()),
                baseColor.A);
        }

        public static Color WithYellow(this Color baseColor, double newY)
        {
            return Color.FromRgba(
                (1 - baseColor.GetCyan()) * (1 - baseColor.GetBlackKey()),
                (1 - baseColor.GetMagenta()) * (1 - baseColor.GetBlackKey()),
                (1 - newY) * (1 - baseColor.GetBlackKey()),
                baseColor.A);
        }

        #endregion

        #region Getters Byte

        public static byte GetByteRed(this Color c)
        {
            return NumericExtensions.EnsureByte(c.R * 255);
        }

        public static byte GetByteGreen(this Color c)
        {
            return NumericExtensions.EnsureByte(c.G * 255);
        }

        public static byte GetByteBlue(this Color c)
        {
            return NumericExtensions.EnsureByte(c.B * 255);
        }

        public static byte GetByteAlpha(this Color c)
        {
            return NumericExtensions.EnsureByte(c.A * 255);
        }

        public static byte GetByteCyan(this Color c)
        {
            return NumericExtensions.EnsureByte((1 - c.R) * 255);
        }

        public static byte GetByteMagenta(this Color c)
        {
            return NumericExtensions.EnsureByte((1 - c.G) * 255);
        }

        public static byte GetByteYellow(this Color c)
        {
            return NumericExtensions.EnsureByte((1 - c.B) * 255);
        }

        #endregion

        #region Getters Hex

        public static int GetHexR(this Color c)
        {
            return c.GetByteRed();
        }

        public static int GetHexG(this Color c)
        {
            return c.GetByteGreen();
        }

        public static int GetHexB(this Color c)
        {
            return c.GetByteBlue();
        }

        public static int GetHexA(this Color c)
        {
            return c.GetByteAlpha();
        }

        #endregion

        #region Getters double

        public static double GetBlackKey(this Color c)
        {
            return 1 - Math.Max(Math.Max(c.R, c.G), c.B);
        }

        public static double GetCyan(this Color c)
        {
            return (1 - c.R - c.GetBlackKey()) / (1 - c.GetBlackKey());
        }

        public static double GetMagenta(this Color c)
        {
            return (1 - c.G - c.GetBlackKey()) / (1 - c.GetBlackKey());
        }

        public static double GetYellow(this Color c)
        {
            return (1 - c.B - c.GetBlackKey()) / (1 - c.GetBlackKey());
        }

        #endregion

        #region Converters

        public static Color Inverse(this Color baseColor)
        {
            return Color.FromRgb(1 - baseColor.R, 1 - baseColor.G, 1 - baseColor.B);
        }

        public static Color ToBlackOrWhite(this Color baseColor)
        {
            return baseColor.IsDark() ? Color.Black : Color.White;
        }

        public static Color ToBlackOrWhiteForText(this Color baseColor)
        {
            return baseColor.IsDarkForTheEye() ? Color.White : Color.Black;
        }

        public static Color ToGrayScale(this Color baseColor)
        {
            var avg = (baseColor.R + baseColor.B + baseColor.G) / 3;
            return Color.FromRgb(avg, avg, avg);
        }

        #endregion

        #region Booleans

        public static bool IsDarkForTheEye(this Color c)
        {
            return c.GetHexR() * 0.299 + c.GetHexG() * 0.587 + c.GetHexB() * 0.114 <= 186;
        }

        public static bool IsDark(this Color c)
        {
            return c.GetHexR() + c.GetHexG() + c.GetHexB() <= 127 * 3;
        }

        #endregion
    }
}