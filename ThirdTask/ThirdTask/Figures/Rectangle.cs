using Enumerables;

namespace Figures
{
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Hight { get; set; }

        public override double Perimeter { get => 2 * Width + 2 * Hight; }
        public override double Square { get => Width * Hight; }

        public Rectangle(double Width, double Hight, Materials material) : base(material)
        {
            this.Width = Width;
            this.Hight = Hight;
        }

        public Rectangle(double Width, double Hight, Colors color) : base(color)
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
            return (Width * Hight * Hight).GetHashCode() + (Hight * Width * Width).GetHashCode();
        }

        public override string ToString()
        {
            return $"{ GetType().Name }, { Width }, { Hight }, { Color }";
        }
    }
}
