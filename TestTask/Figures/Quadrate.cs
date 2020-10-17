using System;

namespace Figures
{
    /// <summary>
    /// Represents a quadrate
    /// </summary>
    
    public class Quadrate : Figure
    {
        /// <summary>
        /// Designed to create an instance of the Quadrate class
        /// </summary>
        /// <param name="points"></param>
        /// <param name="figureType"></param>
        
        public Quadrate(int[] points,string figureType) : base(points, figureType)
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
            if (points.Length == 8)
            {
                double[] sides = CalculateSides(points);
                if (sides[0] != 0 && sides[0] == sides[1] && sides[0] == sides[2] && sides[0] == sides[3] && sides[4] == sides[5])
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
            return Math.Pow(sides[0],2);
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
            sides[1] = Math.Sqrt(Math.Pow(points[0] - points[4], 2) + Math.Pow(points[1] - points[5], 2));
            sides[2] = Math.Sqrt(Math.Pow(points[0] - points[6], 2) + Math.Pow(points[1] - points[7], 2));
            sides[3] = Math.Sqrt(Math.Pow(points[2] - points[4], 2) + Math.Pow(points[3] - points[5], 2));
            sides[4] = Math.Sqrt(Math.Pow(points[2] - points[6], 2) + Math.Pow(points[3] - points[7], 2));
            sides[5] = Math.Sqrt(Math.Pow(points[4] - points[6], 2) + Math.Pow(points[5] - points[7], 2));
            SortSides(ref sides);
            return sides;
        }

        /// <summary>
        /// Sorts side lengths in ascendinf order
        /// </summary>
        /// <param name="sides">Lengths of sides</param>
        
        static void SortSides(ref double[] sides)
        {
            double tempVariable;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    if (sides[j + 1] < sides[j])
                    {
                        tempVariable = sides[j + 1];
                        sides[j + 1] = sides[j];
                        sides[j] = tempVariable;
                    }
                }
            }
        }
    }
}
