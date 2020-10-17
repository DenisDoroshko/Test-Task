using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class TrapezeTest
    {
        [TestMethod]
        public void IsThisFigureRightData()
        {
            //Arange
            bool expected = true;
            int[] points = new int[8] { 0, -1, 3, 2, 1, 2, 0, 1 };
            //Act
            bool result = Trapeze.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsThisFigureWrongData()
        {
            //Arange
            bool expected = false;
            int[] points = new int[8] { -2, 1, 1, 3, -1, 4, -2, 3 };
            //Act
            bool result = Trapeze.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculateSquare()
        {
            //Arange
            double expected = 4;
            int[] points = new int[8] { 0, -1, 3, 2, 1, 2, 0, 1 };
            //Act
            Trapeze trapeze = new Trapeze(points, "trapeze");
            double result = Math.Round(trapeze.CalculateSquare(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculatePerimeter()
        {
            //Arange
            double expected = 9.66;
            int[] points = new int[8] { 0, -1, 3, 2, 1, 2, 0, 1 };
            //Act
            Trapeze trapeze = new Trapeze(points, "trapeze");
            double result = Math.Round(trapeze.CalculatePerimeter(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
