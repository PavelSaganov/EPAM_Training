using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Hight { get; set; }

        public override double Perimeter { get => 2 * Width + 2 * Hight; }
        public override double Square { get => Width * Hight; }

        public Rectangle(double Width, double Hight)
        {
            this.Width = Width;
            this.Hight = Hight;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Rectangle r = obj as Rectangle;
            if (r == null)
                return false;
            return r.Width == Width && r.Hight == Hight;
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() + Hight.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ GetType().Name }, { Width }, { Hight }";
        }
    }
}
