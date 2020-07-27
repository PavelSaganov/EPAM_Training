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

        /// <summary>
        /// Вырезание из одной фигуры другую, меньшей площади
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
        public Circle(int x, int y, double radius, Figure figure) : base(figure.Color)
        {
            Center = new Point(x, y);
            Radius = radius;
            if (figure.Square < Square)
                throw new Exception("Невозможно вырезать из меньшей фигуры большую!");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Circle c = obj as Circle;
            if (c == null)
                return false;
            return c.Radius == Radius && c.Center == Center && c.Color == Color;
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode() + Center.GetHashCode() * Center.X.GetHashCode() * Center.Y.GetHashCode() + Color.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ GetType().Name }, { Center.X }, { Center.Y }, { Radius }, { Color }";
        }
    }
}
