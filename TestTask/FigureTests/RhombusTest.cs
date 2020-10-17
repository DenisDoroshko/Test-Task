using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class RhombusTest
    {
        [TestMethod]
        public void IsThisFigureRightData()
        {
            //Arange
            bool expected = true;
            int[] points = new int[8] { 0,-2, 1, 0, 0, 2, -1, 0 };
            //Act
            bool result = Rhombus.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsThisFigureWrongData()
        {
            //Arange
            bool expected = false;
            int[] points = new int[8] { 0, -2, 1, 0, 0, 2, -2, 0 };
            //Act
            bool result = Rhombus.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculateSquare()
        {
            //Arange
            double expected = 4;
            int[] points = new int[8] { 2, 0, 3, 2, 2, 4, 1, 2 };
            //Act
            Rhombus rhombus = new Rhombus(points, "rhombus");
            double result = Math.Round(rhombus.CalculateSquare(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculatePerimeter()
        {
            //Arange
            double expected = 8.94;
            int[] points = new int[8] { 2, 0, 3, 2, 2, 4, 1, 2 };
            //Act
            Rhombus rhombus = new Rhombus(points, "rhombus");
            double result = Math.Round(rhombus.CalculatePerimeter(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
