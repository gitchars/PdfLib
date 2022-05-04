using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLib
{
    public class Path : IPath
    {
        private Point currenPoint;
        private Point firstPoint;
        private bool closed = false;
        private string content = string.Empty;

        public Point CurrenPointPath
        {
            get { return currenPoint; }
        }
        public Point FirstPointPath
        {
            get { return firstPoint; }
        }
        public bool Closed
        {
            get { return closed; }
        }
        public double LineWidth { get; set; }


        public void MoveTo(double x, double y)
        {
            this.content += $"{x}, {y} " + Operators.BeginPath + Operators.EndOfLine;
            currenPoint = new Point(x, y);
            firstPoint = currenPoint;
            this.closed = false;
        }
        public void LineTo(double x, double y)
        {
            if (this.currenPoint == null)
            {
                throw new Exception("A path must start with the m or re operator.");
            }
            this.content += $"{x}, {y} " + Operators.Straightline + Operators.EndOfLine;
            currenPoint = new Point(x, y); ;
        }

        public void CurveC(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            if (this.currenPoint == null)
            {
                throw new Exception("A path must start with the m or re operator.");
            }
            this.content += $"{x1}, {y1}, {x2}, {y2}, {x3}, {y3} " + Operators.CurveC + Operators.EndOfLine;
            currenPoint = new Point(x3, y3);
        }

        private void Curve(double x, double y, double x3, double y3, string oper)
        {
            if (this.currenPoint == null)
            {
                throw new Exception("A path must start with the m or re operator.");
            }
            this.content += $"{x}, {y}, {x3}, {y3} " + oper + Operators.EndOfLine;
            currenPoint = new Point(x3, y3);
        }

        public void CurveV(double x2, double y2, double x3, double y3)
        {
            this.Curve(x2, y2, x3, y3, Operators.CurveV);
        }

        public void CurveY(double x1, double y1, double x3, double y3)
        {
            this.Curve(x1, y1, x3, y3, Operators.CurveY);
        }

        public void ClosePath()
        {
            if (!this.closed)
            {
                this.LineTo(firstPoint.X, firstPoint.Y);
                currenPoint = firstPoint;
                this.closed = true;
            }
        }

        public void Rectangle(double x, double y, double width, double height)
        {
            this.content += $"{x}, {y}, {width}, {height} " + Operators.Rectangle + Operators.EndOfLine;
            currenPoint = new Point(x, y);
            firstPoint = currenPoint;
            this.closed = true;
        }


        // --- Path-painting operators
        public void Stroke()
        {
            // todo: Add Line width
            // todo: Add Line color
            // todo: Add Line Dash Pattern
            this.content += Operators.StrokePath + "\n";
        }

        public void ClosePathAndStroke()
        {
            this.ClosePath();
            this.Stroke();
        }
        public void Fill_UsingNZWN()
        {
            // todo: Add Backcolor
            this.content += Operators.FillPath_usingNZWN + Operators.EndOfLine;
        }
        public void Fill_UsingEOR()
        {
            // todo: Add Backcolor
            this.content += Operators.FillPath_usingEOR + Operators.EndOfLine;
        }

        public void FillAndStroke_UsingNZWN()
        {
            // todo: Add Line width
            // todo: Add Line color
            // todo: Add Line Dash Pattern
            // todo: Add Backcolor
            this.content += Operators.FillAndStroke_usingNZWN + "\n";
        }
        public void FillAndStroke_UsingEOR()
        {
            // todo: Add Line width
            // todo: Add Line color
            // todo: Add Line Dash Pattern
            // todo: Add Backcolor
            this.content += Operators.FillAndStroke_usingEOR + "\n";
        }

        public void CloseFillAndStroke_UsingNZWN()
        {
            this.ClosePath();
            this.FillAndStroke_UsingNZWN();
        }
        public void CloseFillAndStroke_UsingEOR()
        {
            this.ClosePath();
            this.FillAndStroke_UsingEOR();
        }


    }
}