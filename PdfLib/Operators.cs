using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLib
{
    static class Operators
    {
        public const string BeginPath = "m";
        public const string Straightline = "l";
        public const string CurveC = "c";
        public const string CurveV = "v";
        public const string CurveY = "y";
        public const string ClosePath = "h";
        public const string Rectangle = "re";

        public const string StrokePath = "S";
        public const string CloseStrokePath = "s";
        
        public const string FillPath_usingNZWN = "f";
        public const string FillPath_usingeor = "f*";
        
        public const string FillAndStroke_usingNZWN = "B";
        public const string FillAndStroke_usingeor = "B*";

        public const string CloseFillAndStroke_usingNZWN = "b";
        public const string CloseFillAndStroke_usingeor = "b*";

    }
}
