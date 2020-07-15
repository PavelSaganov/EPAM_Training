using Exercise_3__Products_.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3__Products_
{
    public class Bread : Product
    {
        public Bread(string Type, string Name, double Cost) : base(Type, Name, Cost) { }

        public static implicit operator Bread(Cheese cheese)
        {
            return new Bread (cheese.Type, cheese.Name, cheese.Cost);
        }
    }
}
