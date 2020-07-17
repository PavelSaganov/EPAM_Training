using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Exercise_1__Vectors_.Comparers
{
    /// <summary>
    /// Класс необходимый для корректных тестов
    /// </summary>
    public class VectorEqualityComparer : IEqualityComparer<Vector>
    {
        public bool Equals([AllowNull] Vector x, [AllowNull] Vector y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x[0] == y[0] && x[1] == y[1] && x[2] == y[2])
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] Vector obj)
        {
            return obj.Length.GetHashCode();
        }
    }
}
