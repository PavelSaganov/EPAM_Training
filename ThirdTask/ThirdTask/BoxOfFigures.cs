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
            var a = Figures.ToList();
            a.RemoveAt(i);
            Figures = a.ToArray();
            return returnedFigure;
        }

        public BoxOfFigures(Figure[] Figures) => this.Figures = Figures;

        public BoxOfFigures() { }

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

        /// <summary>
        /// Получение кругов из коробки
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetCircles()
        {
            return Figures.Where(f => f is Circle).ToList();
        }

        /// <summary>
        /// Получение пленочных фигур
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetCelluloseFigures()
        {
            return Figures.Where(f => f.Color == Colors.Colorless).ToList();
        }


        /// <summary>
        /// Чтение фигур с помощью XmlReader
        /// </summary>
        /// <param name="path"></param>
        public void ReadFiguresByXmlReader(string path)
        {
            Figures = WorkWithFile.ReadXmlFileByXmlReader(path);
        }

        /// <summary>
        /// Запись фигур с помощью XmlWriter
        /// </summary>
        /// <param name="path"></param>
        public void WriteCelluloseFiguresByXmlWriter(string path)
        {
            WorkWithFile.WriteXmlFileByXmlWriter(path, Figures);
        }

        /// <summary>
        /// Запись фигур с помощью XmlWriter, которые сделаны из бумаги или пленки
        /// </summary>
        /// <param name="path"></param>
        public void WriteFiguresMadeFromMaterialByXmlWriter(string path, Materials material)
        {
            if (material == Materials.CelluloseTape)
                WorkWithFile.WriteXmlFileByXmlWriter(path, Figures.Where(f => f.Color == Colors.Colorless).ToArray());
            if (material == Materials.Paper)
                WorkWithFile.WriteXmlFileByXmlWriter(path, Figures.Where(f => f.Color != Colors.Colorless).ToArray());
        }


        /// <summary>
        /// Чтение фигур из xml файла с помощью StreamReader
        /// </summary>
        /// <param name="path">Путь к файлу/param>
        public void ReadFiguresByStreamReader(string path)
        {
            Figures = WorkWithFile.ReadXmlFileByStreamReader(path);
        }

        /// <summary>
        /// Чтение фигур из xml файла с помощью StreamWriter
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void ReadFiguresByStreamWriter(string path)
        {
            WorkWithFile.WriteXmlFileByStreamWriter(path, Figures);
        }

        /// <summary>
        /// Запись фигур с помощью StreamWriter, которые сделаны из бумаги или пленки
        /// </summary>
        /// <param name="path">Путь к файлу/param>
        public void WriteFiguresMadeFromMaterialByStreamWriter(string path, Materials material)
        {
             if (material == Materials.CelluloseTape)
                WorkWithFile.WriteXmlFileByStreamWriter(path, Figures.Where(f => f.Color == Colors.Colorless).ToArray());
            if (material == Materials.Paper)
                WorkWithFile.WriteXmlFileByStreamWriter(path, Figures.Where(f => f.Color != Colors.Colorless).ToArray());
        }
    }
}
