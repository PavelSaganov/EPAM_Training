using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Exercise_2__Polynomial_.Comparers
{
    /// <summary>
    /// Класс необходимый для корректных тестов
    /// </summary>
    public class PolynomialEqualityComparer : IEqualityComparer<Polynomial>
    {
        public bool Equals([AllowNull] Polynomial x, [AllowNull] Polynomial y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.coefficients.ToString() == y.coefficients.ToString())
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] Polynomial obj)
        {
            return obj.coefficients.GetHashCode() + 10;
        }
    }
}
