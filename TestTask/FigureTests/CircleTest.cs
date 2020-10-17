using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void IsThisFigureRightData()
        {
            //Arange
            bool expected = true;
            int[] points = new int[1] { 4 };
            //Act
            bool result = Circle.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsThisFigureWrongData()
        {
            //Arange
            bool expected = false;
            int[] points = new int[2] { 4 ,2};
            //Act
            bool result = Circle.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculateSquare()
        {
            //Arange
            double expected = 50.27;
            int[] points = new int[1] { 4 };
            //Act
            Circle circle = new Circle(points, "circle");
            double result = Math.Round(circle.CalculateSquare(),2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculatePerimeter()
        {
            //Arange
            double expected = 25.13;
            int[] points = new int[1] { 4 };
            //Act
            Circle circle = new Circle(points, "circle");
            double result = Math.Round(circle.CalculatePerimeter(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
