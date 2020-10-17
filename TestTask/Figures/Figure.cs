using System;

namespace Figures
{
    /// <summary>
    /// A class intended to be used as a base class for figures
    /// </summary>
    abstract public class Figure
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="points">A set of coordinates</param>
        /// <param name="figureType">Type of figure</param>
        
        public Figure(int[] points,string figureType)
        {
            this.points = points;
            this.figureType = figureType;
        }
        protected int[] points;
        protected string figureType;
        /// <summary>
        /// Type of figure
        /// </summary>
        public string FigureType { get { return figureType; } }

        /// <summary>
        /// Figure area
        /// </summary>
        
        public double Square { get { return CalculateSquare(); } }

        /// <summary>
        /// Figure perimeter
        /// </summary>
        
        public double Perimeter { get { return CalculatePerimeter(); } }

        /// <summary>
        /// Calculates the square of a figure
        /// </summary>
        /// <returns>Figure square</returns>
        
        abstract public double CalculateSquare();

        /// <summary>
        /// Calculates the perimeter of a figure
        /// </summary>
        /// <returns>Figure perimeter</returns>
        
        abstract public double CalculatePerimeter();
    }
}
