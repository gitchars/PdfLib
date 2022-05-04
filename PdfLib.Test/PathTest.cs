using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PdfLib.Test
{
    [TestClass]
    public class PathTest
    {
        #region Path Creation 

        [TestMethod]
        public void Path_ContentEmpty_Create()
        {
            // Arrange
            string contentExpected = string.Empty;
            Path myPath = new Path();
            // Action
            // Assert
            Assert.AreEqual(myPath.Content, contentExpected);
        }

        [TestMethod]
        public void Path_BeginClosed_Create()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            // Assert
            Assert.IsTrue(myPath.Closed);
        }

        [TestMethod]
        public void Path_currentPointIsnull_Create()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            // Assert
            Assert.IsNull(myPath.CurrenPointPath);
        }

        #endregion


        #region Path.MoveTo

        [TestMethod]
        public void MoveTo_ValidCurrentPoint()
        {
            // Arrange
            Point currentPointExpected = new Point(300.5, 500.5);
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300.5, 500.5);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);

        }

        [TestMethod]
        public void MoveTo_FirstPointIsEqualToCurrentPoint()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300.5, 500.5);
            // Assert
            Assert.AreEqual(myPath.FirstPointPath.X, myPath.CurrenPointPath.X);
            Assert.AreEqual(myPath.FirstPointPath.Y, myPath.CurrenPointPath.Y);
        }

        [TestMethod]
        public void MoveTo_ClosedIsFalse()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300.5, 500.5);
            // Assert
            Assert.IsFalse(myPath.Closed);
        }

        [TestMethod]
        public void Path_ContentValid_MoveTo()
        {
            // Arrange
            string contentExpected = "300.5 500.5 m\n";
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300.5, 500.5);
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }


        #endregion


        #region Path.LineTo

        [TestMethod]
        public void LineTo_CurrentPointNotDefined_Throw()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            // Assert
            Assert.ThrowsException <System.Exception> (() => myPath.LineTo(300.5, 500.5));
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "A path must start with the m or re operator.")]
        public void LineTo_CurrentPointNotDefined_ThrowMessage()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.LineTo(300.5, 500.5);
        }
        [TestMethod]
        public void Path_ContentValid_LineTo()
        {
            // Arrange
            string contentExpected = "150 250 m\n150 350 l\n";
            Path myPath = new Path();
            // Action
            myPath.MoveTo(150, 250);
            myPath.LineTo(150, 350);
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_currentPointValid_LineTo()
        {
            // Arrange
            Point currentPointExpected = new Point(150, 350);
            Path myPath = new Path();
            // Action
            myPath.MoveTo(150, 250);
            myPath.LineTo(150, 350);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);
        }

        #endregion


        #region Path.CurveC
        [TestMethod]
        public void CurveC_CurrentPointNotDefined_Throw()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            // Assert
            Assert.ThrowsException<System.Exception>(() => myPath.CurveC(300, 400, 400, 400, 400, 250));
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "A path must start with the m or re operator.")]
        public void CurveC_CurrentPointNotDefined_ThrowMessage()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.CurveC(300, 400, 400, 400, 400, 250);
        }

        [TestMethod]
        public void Path_ContentValid_CurveC()
        {
            // Arrange
            string contentExpected = "300 300 m\n300 400 400 400 400 250 c\n";
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveC(300, 400, 400, 400, 400, 250);
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_currentPointValid_CurveC()
        {
            // Arrange
            Point currentPointExpected = new Point(400, 250);
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveC(300, 400, 400, 400, 400, 250);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);
        }
        #endregion


        #region Path.CurveV

        [TestMethod]
        public void CurveV_CurrentPointNotDefined_Throw()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            // Assert
            Assert.ThrowsException<System.Exception>(() => myPath.CurveV(400, 400, 400, 250));
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "A path must start with the m or re operator.")]
        public void CurveV_CurrentPointNotDefined_ThrowMessage()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.CurveV(400, 400, 400, 250);
        }

        [TestMethod]
        public void Path_ContentValid_CurveV()
        {
            // Arrange
            string contentExpected = "300 300 m\n400 400 400 250 v\n";
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveV(400, 400, 400, 250);
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_currentPointValid_CurveV()
        {
            // Arrange
            Point currentPointExpected = new Point(400, 250);
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveV(400, 400, 400, 250);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);
        }

        #endregion


        #region Path.CurveY

        [TestMethod]
        public void CurveY_CurrentPointNotDefined_Throw()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            // Assert
            Assert.ThrowsException<System.Exception>(() => myPath.CurveY(400, 400, 400, 250));
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "A path must start with the m or re operator.")]
        public void CurveY_CurrentPointNotDefined_ThrowMessage()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.CurveY(400, 400, 400, 250);
        }

        [TestMethod]
        public void Path_ContentValid_CurveY()
        {
            // Arrange
            string contentExpected = "300 300 m\n400 400 400 250 y\n";
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveY(400, 400, 400, 250);
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_currentPointValid_CurveY()
        {
            // Arrange
            Point currentPointExpected = new Point(400, 250);
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveY(400, 400, 400, 250);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);
        }


        #endregion


        #region Path.ClosePath

        [TestMethod]
        public void Path_PathIsClosedDoNothing_ClosePath()
        {
            // Arrange
            string contentExpected = string.Empty;
            Path myPath = new Path();
            // Action
            myPath.ClosePath();
            // Assert
            Assert.IsTrue(myPath.Closed);
            Assert.AreEqual(myPath.Content, contentExpected);
        }

        [TestMethod]
        public void Path_AppendStraightLine_ClosePath()
        {
            // Arrange
            string contentExpected = "300 300 m\n400 400 400 250 y\nh";
            Point currentPointExpected = new Point(300, 300);
            Point firstPointExpected = new Point(300, 300);
            Path myPath = new Path();

            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveY(400, 400, 400, 250);
            myPath.ClosePath();
            
            // Assert            
            Assert.IsTrue(myPath.Closed);          
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);      // currentPoint 300, 300
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);

            Assert.AreEqual(myPath.FirstPointPath.X, firstPointExpected.X);      // firstPointExpected 300, 300
            Assert.AreEqual(myPath.FirstPointPath.Y, firstPointExpected.Y);

            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        #endregion


        #region Path.Rectangule


        [TestMethod]
        public void Path_ContentValid_Rectangle()
        {
            // Arrange
            string contentExpected = "200 300 50 75 re\n";
            Path myPath = new Path();
            // Action
            myPath.Rectangle(200, 300, 50, 75);
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_currentPointValid_Rectangle()
        {
            // Arrange
            Point currentPointExpected = new Point(200, 300);
            Path myPath = new Path();
            // Action
            myPath.Rectangle(200, 300, 50, 75);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, currentPointExpected.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, currentPointExpected.Y);
        }

        [TestMethod]
        public void Path_firstPointEqualToCurrentPoint_Rectangle()
        {
            // Arrange
            Point currentPointExpected = new Point(200, 300);
            Path myPath = new Path();
            // Action
            myPath.Rectangle(200, 300, 50, 75);
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, myPath.FirstPointPath.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, myPath.FirstPointPath.Y);
        }

        [TestMethod]
        public void Path_pathClosedIstrue_Rectangle()
        {
            // Arrange
             Path myPath = new Path();
            // Action
            myPath.Rectangle(200, 300, 50, 75);
            // Assert
            Assert.IsTrue(myPath.Closed);
        }

        #endregion

        #region Path.Stroke

        [TestMethod]
        public void Path_ContentValid_Stroke()
        {
            // Arrange
            string contentExpected = "4 w\nS\n";
            Path myPath = new Path();
            // Action
            myPath.LineWidth = 4;
            myPath.Stroke();
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        #endregion

        #region Path.ClosePathAndStroke

        [TestMethod]
        public void Path_ContentValidIsClosed_ClosePathAndStroke()
        {
            // Arrange
            string contentExpected = "4 w\ns\n";
            Path myPath = new Path();
            // Action
            myPath.LineWidth = 4;
            myPath.ClosePathAndStroke();
            // Assert
            Assert.AreEqual(myPath.LineWidth, 4);
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }
        #endregion


        #region Path.Fill
        
        [TestMethod]
        public void Path_ContentValid_Fill_UsingNZWN()
        {
            // Arrange
            string contentExpected = "f\n";
            Path myPath = new Path();
            // Action
            myPath.Fill_UsingNZWN();
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }
        
                
        [TestMethod]
        public void Path_ContentValid_Fill_UsingEOR()
        {
            // Arrange
            string contentExpected = "f*\n";
            Path myPath = new Path();
            // Action
            myPath.Fill_UsingEOR();
            // Assert
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_ContentValid_FillAndStroke_UsingNZWN()
        {
            // Arrange
            string contentExpected = "4 w\nB\n";
            Path myPath = new Path();
            // Action
            myPath.LineWidth = 4;
            myPath.FillAndStroke_UsingNZWN();
            // Assert
            Assert.AreEqual(myPath.LineWidth, 4);
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }


        [TestMethod]
        public void Path_ContentValid_FillAndStroke_UsingEOR()
        {
            // Arrange
            string contentExpected = "4 w\nB*\n";
            Path myPath = new Path();
            // Action
            myPath.LineWidth = 4;
            myPath.FillAndStroke_UsingEOR();
            // Assert
            Assert.AreEqual(myPath.LineWidth, 4);
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }


        [TestMethod]
        public void Path_ContentValid_CloseFillAndStroke_UsingNZWN()
        {
            // Arrange
            string contentExpected = "4 w\nb\n";
            Path myPath = new Path();
            // Action
            myPath.LineWidth = 4;
            myPath.CloseFillAndStroke_UsingNZWN();
            // Assert
            Assert.AreEqual(myPath.LineWidth, 4);
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }

        [TestMethod]
        public void Path_firstPointEqualToCurrentPoint_CloseFillAndStroke_UsingNZWN()
        {
            // Arrange
            Path myPath = new Path();
            // Action
            myPath.MoveTo(300, 300);
            myPath.CurveY(400, 400, 400, 250);
            myPath.CloseFillAndStroke_UsingNZWN();
            // Assert
            Assert.AreEqual(myPath.CurrenPointPath.X, myPath.FirstPointPath.X);
            Assert.AreEqual(myPath.CurrenPointPath.Y, myPath.FirstPointPath.Y);
        }


        [TestMethod]
        public void Path_ContentValid_CloseFillAndStroke_UsingEOR()
        {
            // Arrange
            string contentExpected = "4 w\nb*\n";
            Path myPath = new Path();
            // Action
            myPath.LineWidth = 4;
            myPath.CloseFillAndStroke_UsingEOR();
            // Assert
            Assert.AreEqual(myPath.LineWidth, 4);
            Assert.AreEqual(myPath.Content.Replace("\n", ""), contentExpected.Replace("\n", ""));
        }


        #endregion

    }
}
