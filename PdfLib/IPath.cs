using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLib
{
    public interface IPath
    {
        Point CurrenPointPath { get; }
        Point FirstPointPath { get; }
        bool Closed { get; }
        double LineWidth { get; set; }

        void MoveTo(double x, double y);

        void LineTo(double x, double y);

        void CurveC(double x1, double y1, double x2, double y2, double x3, double y3);

        void CurveV(double x2, double y2, double x3, double y3);

        void CurveY(double x1, double y1, double x3, double y3);

        void ClosePath();
        
        void Rectangle(double x, double y, double width, double height);


        // --- Path-painting operators
        void Stroke();
        void ClosePathAndStroke();
        
        void Fill_UsingNZWN();
        void Fill_UsingEOR();

        void FillAndStroke_UsingNZWN();
        void FillAndStroke_UsingEOR();

        void CloseFillAndStroke_UsingNZWN();
        void CloseFillAndStroke_UsingEOR();

    }
}
