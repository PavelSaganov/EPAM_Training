using Enumerables;
using System;
using System.Drawing;

namespace Figures
{
    public class Circle : Figure
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public override double Perimeter { get => Math.PI * 2 * Radius; }
        public override double Square { get => Math.PI * Radius * Radius; }

        public Circle(int x, int y, double radius, Materials material) : base(material)
        {
            Center = new Point(x, y);
            Radius = radius;
        }

        public Circle(int x, int y, double radius, Colors color) : base(color)
        {
            Center = new Point(x, y);
            Radius = radius;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Circle c = obj as Circle;
            if (c == null)
                return false;
            return c.Radius == Radius && c.Center == Center;
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode() + Center.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ GetType().Name }, { Center.X }, { Center.Y }, { Radius }, { Color }";
        }
    }
}
