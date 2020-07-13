﻿using System;

namespace Figures
{
    public abstract class Figure
    {
        public abstract double Perimeter { get; }
        public abstract double Square { get; }

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}
