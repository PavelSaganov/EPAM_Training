using Enumerables;
using System;

namespace Figures
{
    public abstract class Figure
    {
        public abstract double Perimeter { get; }
        public abstract double Square { get; }
        private Colors color;

        /// <summary>
        /// Свойство, запрещающее окрашивать фигуру, не обладающую цветом или уже окрашенную
        /// </summary>
        public Colors Color
        {
            get => color;
            set
            {
                if (color == Colors.Colorless)
                    throw new Exception("Нельзя окрасить этот материал!");
                else if (color != Colors.Uncolored)
                    throw new Exception("Фигуру можно окрашивать лишь раз");
                else
                    color = value;
            }
        }

        /// <summary>
        /// Конструктор, определяющий материал, из которого сделана фигура
        /// </summary>
        /// <param name="material">Материал, из которого сделана фигура</param>
        public Figure(Materials material)
        {
            if (material == Materials.CelluloseTape)
                Color = Colors.Colorless;
        }

        public Figure(Colors color)
        {
            Color = color;
        }

        public Figure() { }

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
    }
}
