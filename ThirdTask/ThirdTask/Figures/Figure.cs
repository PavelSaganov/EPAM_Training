using Enumerables;

namespace Figures
{
    public abstract class Figure
    {
        public abstract double Perimeter { get; }
        public abstract double Square { get; }
        public Colors Color { get; set; }

        /// <summary>
        /// Конструктор, определяющий материал, из которого сделана фигура
        /// </summary>
        /// <param name="material">Материал, из которого сделана фигура</param>
        public Figure(Materials material)
        {
            if (material == Materials.CelluloseTape)
                Color = Colors.WithoutColor;
        }

        public Figure(Colors color)
        {
            Color = color;
        }

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}
