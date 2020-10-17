using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Figures
{
    /// <summary>
    /// Designed for creating figures
    /// </summary>
    
    public class FigureProduction
    {
        /// <summary>
        /// Validates and instantiates figures
        /// </summary>
        /// <param name="figureData">Entered figure data</param>
        /// <returns>List of figures</returns>
        public static List<Figure> GetFigures(List<string> figureData)
        {
            Dictionary<string, int> figureTypes = new Dictionary<string, int>
            {
                ["circle"] = 1,
                ["triangle"] = 2,
                ["quadrate"] = 3,
                ["rectangle"] = 4,
                ["rhombus"] = 5,
                ["trapeze"] = 6
            };
            List<Figure> figures = new List<Figure>();
            foreach (string data in figureData)
            {
                string figureType = Regex.Replace(data, "[^a-zA-Z]", " ").Trim().ToLower();
                string[] values = data.Split(' ');
                int key;
                figureTypes.TryGetValue(figureType, out key);
                int[] points;
                switch (key)
                {
                    case 1:
                        points = ParsePoints(values);
                        if (Circle.IsThisFigure(points))
                            figures.Add(new Circle(points, figureType));
                        break;
                    case 2:
                        points = ParsePoints(values);
                        if (Triangle.IsThisFigure(points))
                            figures.Add(new Triangle(points, figureType));
                        break;
                    case 3:
                        points = ParsePoints(values);
                        if (Quadrate.IsThisFigure(points))
                            figures.Add(new Quadrate(points, figureType));
                        break;
                    case 4:
                        points = ParsePoints(values);
                        if (Rectangle.IsThisFigure(points))
                            figures.Add(new Rectangle(points, figureType));
                        break;
                    case 5:
                        points = ParsePoints(values);
                        if (Rhombus.IsThisFigure(points))
                            figures.Add(new Rhombus(points, figureType));
                        break;
                    case 6:
                        points = ParsePoints(values);
                        if (Trapeze.IsThisFigure(points))
                            figures.Add(new Trapeze(points, figureType));
                        break;
                }
            }
            return figures;
        }

        /// <summary>
        /// Parses the coordinates of the points of the figure from a strings
        /// </summary>
        /// <param name="values">Initial data</param>
        /// <returns>Array of coordinates</returns>
        static int[] ParsePoints(string[] values)
        {
            List<int> pointsList = new List<int>();
            int numberOfPoints = 0;
            foreach (string value in values)
            {
                int coodrdinate;
                if (int.TryParse(value, out coodrdinate))
                {
                    pointsList.Add(coodrdinate);
                    numberOfPoints++;
                }
            }
            int[] points = new int[numberOfPoints];
            pointsList.CopyTo(points);
            return points;
        }

        /// <summary>
        /// Forms a list of figures of the specified type
        /// </summary>
        /// <param name="figureType">Given figure type</param>
        /// <param name="figures">Initial list of figures</param>
        /// <returns>List of figures of the cpecified type</returns>
        public static List<Figure> GetSelectedFigures(string figureType,List<Figure> figures)
        {
            List<Figure> necessaryFigures = new List<Figure>();
            foreach (Figure figure in figures)
            {
                if (string.Compare(figureType,figure.FigureType)==0)
                    necessaryFigures.Add(figure);
            }
            return necessaryFigures;
        }
    }
}
