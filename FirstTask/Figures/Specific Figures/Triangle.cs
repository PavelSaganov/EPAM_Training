using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Figures
{
    public class Triangle : Figure
    {
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public Point ThirdPoint { get; set; }

        private double FirstSide { get => GetSide(FirstPoint, SecondPoint); }
        private double SecondSide { get => GetSide(SecondPoint, ThirdPoint); }
        private double ThirdSide { get => GetSide(FirstPoint, ThirdPoint); }

        public override double Perimeter => FirstSide + SecondSide + ThirdSide;

        public override double Square
        {
            get
            {
                double p = 0.5 * Perimeter;

                // По формуле Герона
                return Math.Sqrt(Math.Abs(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide)));
            }
        }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            FirstPoint = new Point(x1, y1);
            SecondPoint = new Point(x2, y2);
            ThirdPoint = new Point(x3, y3);
        }

        private double GetSide(Point FirstPoint, Point SecondPoint)
        {
            return Math.Abs(Math.Pow((FirstPoint.X - SecondPoint.X), 2) + Math.Pow((FirstPoint.Y - SecondPoint.Y), 2));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Triangle t = obj as Triangle;
            if (t == null)
                return false;
            return t.FirstPoint == FirstPoint && t.SecondPoint == t.SecondPoint && t.ThirdPoint == ThirdPoint;
        }

        public override int GetHashCode()
        {
            return FirstPoint.GetHashCode() + SecondPoint.GetHashCode() + ThirdPoint.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ GetType().Name }, { FirstPoint.X }, { FirstPoint.Y }, { SecondPoint.X }, { SecondPoint.Y }, { ThirdPoint.X }, { ThirdPoint.Y }";
        }
    }
}
