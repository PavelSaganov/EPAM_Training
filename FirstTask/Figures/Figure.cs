using System;
using ThirdTask.Materials;

namespace Figures
{
    public abstract class Figure : IPaper, ICelluloseTape
    {
        public abstract double Perimeter { get; }
        public abstract double Square { get; }

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}
