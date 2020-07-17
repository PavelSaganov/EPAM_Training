using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Exercise_3__Products_.Comparers
{
    /// <summary>
    /// Класс необходимый для корректных тестов
    /// </summary>
    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals([AllowNull] Product x, [AllowNull] Product y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.Type == y.Type && x.Name == y.Name && x.Cost == y.Cost)
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Cost.GetHashCode() + obj.Name.GetHashCode() + obj.Cost.GetHashCode();
        }
    }
}
