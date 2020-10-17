using System;

namespace Figures
{
    /// <summary>
    /// Represents a circle
    /// </summary>
    
    public class Circle : Figure
    {
        /// <summary>
        /// Designed to create an instance of the Circle class
        /// </summary>
        /// <param name="points"></param>
        /// <param name="figureType"></param>
        
        public Circle(int[] points,string figureType) : base(points,figureType)
        {
        }

        /// <summary>
        /// Checks the figure for this type
        /// </summary>
        /// <param name="points">Figure coordinates</param>
        /// <returns>True if the figure is of this type; otherwide, false</returns>
        
        public static bool IsThisFigure(int[] points)
        {
            return points.Length == 1;
        }

        /// <summary>
        /// Calculates the square of a figure
        /// </summary>
        /// <returns>Figure square</returns>
        
        public override double CalculateSquare()
        {
            return Math.PI * Math.Pow(points[0], 2);
        }

        /// <summary>
        /// Calculates the perimeter of a figure
        /// </summary>
        /// <returns>Figure perimeter</returns>
        
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * points[0];
        }

    }
}
