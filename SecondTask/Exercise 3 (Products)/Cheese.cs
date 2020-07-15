using Exercise_3__Products_.Abstract_Classes;
using System;

namespace Exercise_3__Products_
{
    public class Cheese : Product
    {
        public Cheese(string Type, string Name, double Cost) : base(Type, Name, Cost) { }

        public static explicit operator Cheese(Bread product)
        {
            return new Cheese(product.Type, product.Name, product.Cost);
        }
    }
}
