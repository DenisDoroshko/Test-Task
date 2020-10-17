using System;

namespace Figures
{
    /// <summary>
    /// Represents a triangle
    /// </summary>
    
    public class Triangle : Figure
    {
        /// <summary>
        /// Designed to create an instance of the Triangle class
        /// </summary>
        /// <param name="points"></param>
        /// <param name="figureType"></param>
        
        public Triangle(int[] points, string figureType) : base(points, figureType)
        {
        }

        /// <summary>
        /// Checks the figure for this type
        /// </summary>
        /// <param name="points">Figure coordinates</param>
        /// <returns>True if the figure is of this type; otherwide, false</returns>

        public static bool IsThisFigure(int[] points)
        {
            bool isFigure = false;
            if (points.Length == 6)
            {
                double[] sides = CalculateSides(points);
                double semiPerimeter = (sides[0] + sides[1] + sides[2]) / 2;
                double square = Math.Sqrt(semiPerimeter * (semiPerimeter - sides[0]) * (semiPerimeter - sides[1]) * (semiPerimeter - sides[2]));
                if (square != 0)
                {
                    isFigure = true;
                }
            }
            return isFigure;
        }

        /// <summary>
        /// Calculates the square of a figure
        /// </summary>
        /// <returns>Figure square</returns>

        public override double CalculateSquare()
        {
            double[] sides = CalculateSides(points);
            double semiPerimeter = (sides[0] + sides[1] + sides[2]) / 2;
            return Math.Sqrt(semiPerimeter*(semiPerimeter-sides[0])*(semiPerimeter-sides[1])*(semiPerimeter-sides[2]));
        }

        /// <summary>
        /// Calculates the perimeter of a figure
        /// </summary>
        /// <returns>Figure perimeter</returns>
        
        public override double CalculatePerimeter()
        {
            double[] sides = CalculateSides(points);
            return sides[0]+sides[1]+sides[2];
        }

        /// <summary>
        /// Calculates the lengths of the sides of a figure
        /// </summary>
        /// <returns>Lengths of the sides</returns>

        static double[] CalculateSides(int[] points)
        {
            double[] sides = new double[3];
            sides[0] = Math.Sqrt(Math.Pow(points[0] - points[2], 2) + Math.Pow(points[1] - points[3], 2));
            sides[1] = Math.Sqrt(Math.Pow(points[0] - points[4], 2) + Math.Pow(points[1] - points[5], 2));
            sides[2] = Math.Sqrt(Math.Pow(points[2] - points[4], 2) + Math.Pow(points[3] - points[5], 2));
            return sides;
        }
    }
}
