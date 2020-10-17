using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Figures;

namespace UserInterface
{
    /// <summary>
    /// Designed for processinf figures and displaying results
    /// </summary>
    class FigureProcessing
    {
        /// <summary>
        /// Depending on the user's choice, call the methods
        /// </summary>
        
        public static void StartProcessing()
        {
            const int exit = 3;
            int choice = 0;
            List <Figure> figures = new List<Figure>();
            bool figuresInput = false;
            while(choice != exit)
            {
                choice = GetChoice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        figuresInput = InputFigures(ref figures);
                        break;
                    case 2:
                        if(figuresInput)
                            CalculateResults(figures);
                        else
                            Console.WriteLine("Create the figures first!");
                        break;
                    default:
                        Console.WriteLine("Input error");
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the user's choice
        /// </summary>
        /// <returns>User's choice</returns>
        
        static int GetChoice()
        {
            Console.WriteLine("Select:\n1.Create figures\n2.Display results\n3.Exit");
            string input = Console.ReadLine();
            int choice;
            int.TryParse(input, out choice);
            return choice;
        }
        /// <summary>
        /// Adds figures
        /// </summary>
        /// <param name="figures"></param>
        /// <returns></returns>
        
        public static bool InputFigures(ref List<Figure> figures)
        {
            Console.WriteLine("Select:\n1.Input figures\n2.Get from file");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            List<string> figureData = new List<string>();
            bool noError = true;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("How many figures to create?");
                    int number;
                    int.TryParse(Console.ReadLine(), out number);
                    Console.WriteLine("Input format: \"figure type\" \"coordinates of points (for circle radius)\" for example: triangle 1 1 2 2 3 3");
                    Console.WriteLine("Available figure types: circle, triangle, quadrate, rectangle, rhombus, trapeze");
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Enter: ");
                        figureData.Add(Console.ReadLine());
                    }
                    break;
                case 2:
                    figureData = DataExtractor.GetData();
                    break;
                default:
                    Console.WriteLine("Input error");
                    noError = false;
                    break;
            }
            figures = FigureProduction.GetFigures(figureData);
            return noError;
        }

        /// <summary>
        /// Calculates and displays results
        /// </summary>
        /// <param name="figures">List of figures</param>

        public static void CalculateResults(List<Figure> figures)
        {
            int goodFigures = figures.Count;
            List<Figure> circles = FigureProduction.GetSelectedFigures("circle",figures);
            List<Figure> triangles = FigureProduction.GetSelectedFigures("triangle", figures);
            List<Figure> quadrates = FigureProduction.GetSelectedFigures("quadrate", figures);
            List<Figure> rectangles = FigureProduction.GetSelectedFigures("rectangle", figures);
            List<Figure> rhombuses = FigureProduction.GetSelectedFigures("rhombus", figures);
            List<Figure> trapezes = FigureProduction.GetSelectedFigures("trapeze", figures);
            List <FigureParameters> results = new List<FigureParameters>();
            if (circles.Count != 0)
                results.Add(CalculateFigureParameters(circles));
            if (triangles.Count != 0)
                results.Add(CalculateFigureParameters(triangles));
            if (quadrates.Count != 0)
                results.Add(CalculateFigureParameters(quadrates));
            if (rectangles.Count != 0)
                results.Add(CalculateFigureParameters(rectangles));
            if (rhombuses.Count != 0)
                results.Add(CalculateFigureParameters(rhombuses));
            if (trapezes.Count != 0)
                results.Add(CalculateFigureParameters(trapezes));

            if (results.Count != 0)
            {
                Console.WriteLine($"Number of figures that have passed validation: {goodFigures}");
                Console.WriteLine("Average perimeters of figures:");
                foreach (FigureParameters result in results)
                {
                    Console.WriteLine($" {result.figureType}: {result.averagePerimeter}");
                }
                Console.WriteLine("Average squares of figures:");
                foreach (FigureParameters result in results)
                {
                    Console.WriteLine($" {result.figureType}: {result.averageSquare}");
                }
                string typeOfMaxSquare = GetMaxSquare(results);
                Console.WriteLine($"Figure type with the largest square:{typeOfMaxSquare}");
                string typeOfMaxAveragePerimeter = GetMaxAveragePerimeter(results);
                Console.WriteLine($"Figure type with the largest average perimeter:{typeOfMaxAveragePerimeter}");
            }
            else
                Console.WriteLine("Figures not found");
        }

        /// <summary>
        /// Calculates the largest average perimeter
        /// </summary>
        /// <param name="results">List of parameters of types</param>
        /// <returns>Figure type with the largest average perimeter</returns>
        
        static string GetMaxAveragePerimeter(List<FigureParameters> results)
        {
            double maxSquare = results[0].averagePerimeter;
            string figureType = results[0].figureType;
            for (int i = 1; i < results.Count; i++)
            {
                if (maxSquare < results[i].averagePerimeter)
                {
                    maxSquare = results[i].averagePerimeter;
                    figureType = results[i].figureType;
                }
            }
            return figureType;
        }

        /// <summary>
        /// Calculates the largest square
        /// </summary>
        /// <param name="results">List of parameters of types</param>
        /// <returns>Figure type with the largest square</returns>

        static string GetMaxSquare(List<FigureParameters> results)
        {
            double maxSquare = results[0].largestSquare;
            string figureType = results[0].figureType;
            for (int i = 1; i < results.Count; i++)
            {
                if (maxSquare < results[i].largestSquare)
                {
                    maxSquare = results[i].largestSquare;
                    figureType = results[i].figureType;
                }
            }
            return figureType;
        }

        /// <summary>
        /// Calculates the parameters of figures
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <returns>Class that stores the parametes of the figure type</returns>

        static FigureParameters CalculateFigureParameters(List<Figure> figures)
        {
            double averagePerimeter = GetAveragePerimeter(figures);
            double averageSquare = GetAverageSquare(figures);
            double largestSuare = GetLargestSquare(figures);
            string figureType;
            if (figures.Count != 0)
                figureType = figures[0].FigureType;
            else
                figureType = "None";
            return new FigureParameters(averagePerimeter, averageSquare, largestSuare,figureType);
        }

        /// <summary>
        /// Calculates the average perimeter among a figure type
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <returns>The average perimeter</returns>

        public static double GetAveragePerimeter(List<Figure> figures)
        {
            double sumOfPerimeters = 0;
            foreach (Figure figure in figures)
            {
                sumOfPerimeters += figure.Perimeter;
            }
            double averagePerimeter = sumOfPerimeters / figures.Count;
            return averagePerimeter;
        }

        /// <summary>
        /// Calculates the average square among a figure type
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <returns>The average perimeter</returns>

        public static double GetAverageSquare(List<Figure> figures)
        {
            double sumOfSquare = 0;
            foreach (Figure figure in figures)
            {
                sumOfSquare += figure.Square;
            }
            double averageSquare = sumOfSquare / figures.Count;
            return averageSquare;
        }

        /// <summary>
        /// Calculates the largest square among a figure type
        /// </summary>
        /// <param name="figures">List of figures</param>
        /// <returns>The average perimeter</returns>
        
        public static double GetLargestSquare(List<Figure> figures)
        {
            double largestSquare = figures[0].Square;
            for(int i=1; i<figures.Count;i++)
            {
                if (largestSquare < figures[i].Square)
                    largestSquare = figures[i].Square;
            }
            return largestSquare;
        }
    }
}
