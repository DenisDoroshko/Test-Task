using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void IsThisFigureRightData()
        {
            //Arange
            bool expected = true;
            int[] points = new int[6] { 1,1,3,3,1,3};
            //Act
            bool result = Triangle.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsThisFigureWrongData()
        {
            //Arange
            bool expected = false;
            int[] points = new int[6] { 1,1,2,2,3,3 };
            //Act
            bool result = Triangle.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculateSquare()
        {
            //Arange
            double expected = 6;
            int[] points = new int[6] {-2,-2,0,0,-4,2};
            //Act
            Triangle triangle = new Triangle(points, "triangle");
            double result = Math.Round(triangle.CalculateSquare(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculatePerimeter()
        {
            //Arange
            double expected = 16.17;
            int[] points = new int[6] { 1, 1, 6, 6, 1, 5 };
            //Act
            Triangle triangle = new Triangle(points, "triangle");
            double result = Math.Round(triangle.CalculatePerimeter(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
