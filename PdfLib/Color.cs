using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLib
{
    public enum AvailableColors
    {
        Red,
        Green,
        Blue,
        LightBlue,
        Yellow,
        White,
        Black
    }
    public static class ColorsPatterns
    {
        public static string GetPattern(this AvailableColors me)
        {
            switch (me)
            {
                case AvailableColors.Red:
                    return "1.0 0.0 0.0";
                case AvailableColors.Green:
                    return "0.0 1.0 0.0";
                case AvailableColors.Blue:
                    return "0.0 0.0 1.0";
                case AvailableColors.LightBlue:
                    return "1.0 0.75 1.0";
                case AvailableColors.Yellow:
                    return "1.0 1.0 0.0";
                case AvailableColors.White:
                    return "1.0 1.0 1.0";
                case AvailableColors.Black:
                    return "0.0 0.0 0.0";
                default:
                    return "NO VALUE GIVEN";
            }
        }
    }
}
