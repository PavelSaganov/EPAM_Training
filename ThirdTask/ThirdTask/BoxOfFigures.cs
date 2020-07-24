using Enumerables;
using Figures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdTask
{
    public class BoxOfFigures
    {
        private Figure[] Figures { get; set; } = new Figure[20];

        /// <summary>
        /// Просмотреть фигуру по номеру
        /// </summary>
        /// <param name="i">Номер фигуры</param>
        /// <returns>Метод ToString, примененный фигуре</returns>
        public string this[int i]
        {
            get => Figures[i].ToString();
        }

        /// <summary>
        /// Извлечение фигуры и удаление ее из коробки
        /// </summary>
        /// <param name="i">Индекс фигуры</param>
        /// <returns>Фигура, которая находится в коробке по индексу i</returns>
        public Figure GetFigure(int i)
        {
            var returnedFigure = Figures[i];
            Figures.ToList().Remove(returnedFigure);
            return returnedFigure;
        }

        public BoxOfFigures(Figure[] Figures) => this.Figures = Figures;

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
        /// <param name="figure"></param>
        /// <returns>Эквивалентную фигуру или null если ее нет</returns>
        public Figure GetSimilarFigure(Figure figure)
        {
            try
            { 
                return Figures.Where(f => f.Equals(figure)).First(); 
            }
            catch (ArgumentNullException)
            { return null; }
        }

        public int Count => Figures.Length;
        public double GetTotalSquare => Figures.Sum(f => f.Square);
        public double GetTotalPerimeter => Figures.Sum(f => f.Perimeter);

        public List<Circle> GetCircles()
        {
            return (List<Circle>)Figures.Where(f => f is Circle);
        }

        /// <summary>
        /// Получение пленочных фигур
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetCelluloseFigures()
        {
            // Если фигура бесцветная, то это пленочная фигура, т.к. бумага не может быть бесцветной
            return Figures.Where(f => f.Color == Colors.WithoutColor).ToList();
        }

        /// <summary>
        /// Чтение фигур с помощью XmlReader
        /// </summary>
        /// <param name="path"></param>
        public void ReadFiguresByXmlReader(string path)
        {
            Figures = WorkWithFile.ReadXmlFile(path);
        }

        /// <summary>
        /// Запись фигур с помощью XmlWriter
        /// </summary>
        /// <param name="path"></param>
        public void WriteFiguresByXmlReader(string path, Materials material)
        {
            WorkWithFile.WriteToXmlFile(path, Figures.Where(f => f.Color == Colors.WithoutColor).ToArray());
        }
    }
}
