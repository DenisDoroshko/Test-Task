using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FigureTests
{
    [TestClass]
    public class QuadrateTest
    {
        [TestMethod]
        public void IsThisFigureRightData()
        {
            //Arange
            bool expected = true;
            int[] points = new int[8] { 1, 1, 4, 1, 4, 4, 1, 4 };
            //Act
            bool result = Quadrate.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsThisFigureWrongData()
        {
            //Arange
            bool expected = false;
            int[] points = new int[8] { 0, 1, 4, 1, 4, 4, 1, 4 };
            //Act
            bool result = Quadrate.IsThisFigure(points);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculateSquare()
        {
            //Arange
            double expected = 9;
            int[] points = new int[8] { 1, 1, 4, 1, 4, 4, 1, 4 };
            //Act
            Quadrate quadrate = new Quadrate(points, "quadrate");
            double result = Math.Round(quadrate.CalculateSquare(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CalculatePerimeter()
        {
            //Arange
            double expected = 12;
            int[] points = new int[8] { 1,1,4,1,4,4,1,4 };
            //Act
            Quadrate quadrate = new Quadrate(points, "quadrate");
            double result = Math.Round(quadrate.CalculatePerimeter(), 2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}