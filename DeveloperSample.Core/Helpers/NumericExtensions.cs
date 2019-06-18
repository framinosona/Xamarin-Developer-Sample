using System;

namespace DeveloperSample.Core.Helpers
{
    public static class NumericExtensions
    {
        public static byte EnsureByte(double input)
        {
            if (input < 0) return 0;
            if (input > 255) return 255;
            return (byte) Math.Floor(input);
        }
    }
}