using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Comparers
{
    /// <summary>
    /// Компаратор, для сравнения коллекций фигур
    /// </summary>
    public class FigureEqualityComparer : IEqualityComparer<Figure>
    {
        public bool Equals(Figure x, Figure y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Figure obj)
        {
            return obj.GetHashCode();
        }
    }
}
