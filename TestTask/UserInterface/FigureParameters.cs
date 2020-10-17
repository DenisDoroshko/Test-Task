using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    /// <summary>
    /// Designed to store type parameters
    /// </summary>
    
    public struct FigureParameters
    {
        public double averagePerimeter;
        public double averageSquare;
        public double largestSquare;
        public string figureType;
        public FigureParameters(double averagePerimeter, double averageSquare,double largestSquare,string figureType)
        {
            this.averagePerimeter = averagePerimeter;
            this.averageSquare = averageSquare;
            this.largestSquare = largestSquare;
            this.figureType = figureType;
        }
    }
}
