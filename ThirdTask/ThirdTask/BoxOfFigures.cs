using Enumerables;
using Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ThirdTask.Materials;

namespace ThirdTask
{
    class BoxOfFigures
    {
        private Figure[] Figures { get; set; } = new Figure[20];

        /// <summary>
        /// При извлечении фигуры, она удаляется из коробки
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Figure this[int i]
        {
            get 
            {
                var elementAt = Figures[i];
                Figures.ToList().Remove(elementAt);
                Figures.ToArray();
                return elementAt;
            }
            set => Figures[i] = value;
        }

        /// <summary>
        /// Просмотреть фигуру в коробке
        /// </summary>
        /// <param name="i">Индекс фигуры</param>
        /// <returns>Метод ToString(), примененный к фигуре</returns>
        public string Look(int i) => Figures[i].ToString();

        public void Add(Figure figure)
        {
            if (!Figures.Contains(figure))
            {
                Figures.ToList().Add(figure);
                Figures.ToArray();
            }
            else
                throw new Exception("Нельзя добавлять фигуру дважды!");
        }

        /// <summary>
        /// Поиск эквивалентной фигуры
        /// </summary>
        /// <param name="figure">Фигура, эквивалент которой ищем</param>
        /// <returns>Фигура, эквивалентная заданой</returns>
        public Figure GetSimilarFigure(Figure figure)
        {
            return Figures.Where(f => f.Equals(figure)).FirstOrDefault();
        }

        public int Count => Figures.Length;
        public double GetTotalSquare => Figures.Sum(f => f.Square);
        public double GetTotalPerimeter => Figures.Sum(f => f.Perimeter);

        public List<Circle> GetCircles()
        {
            return (List<Circle>)Figures.Where(f => f is Circle);
        }

        public List<ICelluloseTape> GetCelluloseTapes()
        {
            return (List<ICelluloseTape>)Figures.Where(f => f is ICelluloseTape);
        }


    }
}
