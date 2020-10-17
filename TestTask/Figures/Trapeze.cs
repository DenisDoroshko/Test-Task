using System;

namespace Figures
{
    /// <summary>
    /// Represents a trapeze
    /// </summary>
    public class Trapeze : Figure
    {
        /// <summary>
        /// Designed to create an instance of the Trapeze class
        /// </summary>
        /// <param name="points"></param>
        /// <param name="figureType"></param>
        
        public Trapeze(int[] points, string figureType) : base(points, figureType)
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
                bool nullSide = false;
                for (int i = 0; i < sides.Length; i++)
                {
                    if (sides[i] == 0)
                    {
                        nullSide = true;
                    }
                }
                if (!nullSide)
                {
                    if ((points[0] - points[2]) * (points[5] - points[7]) == (points[1] - points[3]) * (points[4] - points[6]) ||
                            (points[0] - points[6]) * (points[3] - points[5]) == (points[1] - points[7]) * (points[2] - points[4]))
                    {
                        isFigure = true;
                    }
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
            double firstBase = 0;
            double secondBase = 0;
            double thirdSide = 0;
            double fourthSide = 0;
            if ((points[0] - points[2]) * (points[5] - points[7]) == (points[1] - points[3]) * (points[4] - points[6]))
            {
                firstBase = sides[0];
                secondBase = sides[2];
                thirdSide = sides[1];
                fourthSide = sides[3];
            }
            if((points[0] - points[6]) * (points[3] - points[5]) == (points[1] - points[7]) * (points[2] - points[4]))
            {
                firstBase = sides[1];
                secondBase = sides[0];
                thirdSide = sides[3];
                fourthSide = sides[2];
            }
            double semiPerimeter = (firstBase + secondBase + thirdSide + fourthSide)/2;
            double square = (firstBase + secondBase) / Math.Abs(secondBase - firstBase) * Math.Sqrt((semiPerimeter - secondBase) 
                * (semiPerimeter - firstBase) * (semiPerimeter - secondBase - thirdSide) * (semiPerimeter - secondBase - fourthSide));
            return square;
        }

        /// <summary>
        /// Calculates the perimeter of a figure
        /// </summary>
        /// <returns>Figure perimeter</returns>
        

        public override double CalculatePerimeter()
        {
            double[] sides = CalculateSides(points);
            return sides[0]+sides[1]+sides[2]+sides[3];
        }

        /// <summary>
        /// Calculates the lengths of the sides of a figure
        /// </summary>
        /// <returns>Lengths of the sides</returns>

        static double[] CalculateSides(int[] points)
        {
            double[] sides = new double[4];
            sides[0] = Math.Sqrt(Math.Pow(points[0] - points[2], 2) + Math.Pow(points[1] - points[3], 2));
            sides[1] = Math.Sqrt(Math.Pow(points[2] - points[4], 2) + Math.Pow(points[3] - points[5], 2));
            sides[2] = Math.Sqrt(Math.Pow(points[4] - points[6], 2) + Math.Pow(points[5] - points[7], 2));
            sides[3] = Math.Sqrt(Math.Pow(points[6] - points[0], 2) + Math.Pow(points[7] - points[1], 2));
            return sides;
        }
    }
}