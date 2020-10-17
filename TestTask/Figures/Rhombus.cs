using System;

namespace Figures
{
    /// <summary>
    /// Represents a rhombus
    /// </summary>
    
    public class Rhombus : Figure
    {
        /// <summary>
        /// Designed to create an instance of the Rhombus class
        /// </summary>
        /// <param name="points"></param>
        /// <param name="figureType"></param>
        
        public Rhombus(int[] points,string figureType) : base(points, figureType)
        {
        }

        /// <summary>
        /// Checks the figure for this type
        /// </summary>
        /// <param name="points">Figure coordinates</param>
        /// <returns>True if the figure is of this type; otherwide, false</returns>
        
        public static bool IsThisFigure(int[] points)
        {
            bool IsFigure = false;
            if (points.Length == 8)
            {
                double[] sides = CalculateSides(points);
                if (sides[0] != 0 && sides[0] == sides[1] && sides[0] == sides[2] && sides[0] == sides[3] && sides[4] != sides[5])
                {
                    IsFigure = true;
                }

            }
            return IsFigure;
        }

        /// <summary>
        /// Calculates the square of a figure
        /// </summary>
        /// <returns>Figure square</returns>
        
        public override double CalculateSquare()
        {
            double[] sides = CalculateSides(points);
            return 0.5 * sides[4] * sides[5];
        }

        /// <summary>
        /// Calculates the perimeter of a figure
        /// </summary>
        /// <returns>Figure perimeter</returns>
        
        public override double CalculatePerimeter()
        {
            double[] sides = CalculateSides(points);
            return 4 * sides[0];
        }

        /// <summary>
        /// Calculates the lengths of the sides of a figure
        /// </summary>
        /// <returns>Lengths of the sides</returns>
        
        static double[] CalculateSides(int[] points)
        {
            double[] sides = new double[6];
            sides[0] = Math.Sqrt(Math.Pow(points[0] - points[2], 2) + Math.Pow(points[1] - points[3], 2));
            sides[1] = Math.Sqrt(Math.Pow(points[2] - points[4], 2) + Math.Pow(points[3] - points[5], 2));
            sides[2] = Math.Sqrt(Math.Pow(points[4] - points[6], 2) + Math.Pow(points[5] - points[7], 2));
            sides[3] = Math.Sqrt(Math.Pow(points[6] - points[0], 2) + Math.Pow(points[7] - points[1], 2));
            sides[4] = Math.Sqrt(Math.Pow(points[0] - points[4], 2) + Math.Pow(points[1] - points[5], 2));
            sides[5] = Math.Sqrt(Math.Pow(points[2] - points[6], 2) + Math.Pow(points[3] - points[7], 2));
            return sides;
        }
    }
}
