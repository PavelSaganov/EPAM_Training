using Enumerables;
using Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ThirdTask
{
    class BoxOfFigures
    {
        private Figure[] Figures { get; set; } = new Figure[20];

        public Figure this[int i]
        {
            get => Figures.ElementAt(i);
            set => Figures[i] = value;
        }

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
    }
}
