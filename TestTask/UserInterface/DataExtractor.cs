using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserInterface
{
    class DataExtractor
    {
        public static List<string> GetData()
        {
            List<string> figuresDate = new List<string>();
            using (var sr = new StreamReader("figures.txt"))
            {
                while (!sr.EndOfStream)
                {
                    figuresDate.Add(sr.ReadLine());
                }
            }
            return figuresDate;
        }

    }
}
