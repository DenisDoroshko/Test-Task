using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void IsThisFigureRightData()
        {
            //Arange
            bool expected = true;
            int[] points = new int[8] { 1,-1,1,1,-2,1,-2,-1 };
            //Act
            bool result = Rectangle.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsThisFigureWrongData()
        {
            //Arange
            bool expected = false;
            int[] points = new int[8] { 1, -1, 1, 1, -2, 1, -2, -2 };
            //Act
            bool result = Rectangle.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculateSquare()
        {
            //Arange
            double expected = 6;
            int[] points = new int[8] { 1, -1, 1, 1, -2, 1, -2, -1};
            //Act
            Rectangle rectangle = new Rectangle(points, "rectangle");
            double result = Math.Round(rectangle.CalculateSquare(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculatePerimeter()
        {
            //Arange
            double expected = 10;
            int[] points = new int[8] { 1, -1, 1, 1, -2, 1, -2, -1 };
            //Act
            Rectangle rectangle = new Rectangle(points, "rectangle");
            double result = Math.Round(rectangle.CalculatePerimeter(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
