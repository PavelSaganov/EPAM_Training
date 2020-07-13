using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public class WorkWithFigures
    {
        public static Figure[] FindEqualFigureInArray(Figure figure, Figure[] figures)
        {
            List<Figure> result = new List<Figure>();

            foreach (Figure f in figures)
            {
                if (f.Equals(figure))
                    result.Add(f);
            }
            return result.ToArray();
        }
    }
}
