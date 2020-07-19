using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Figures
{
    static public class WorkWithFile
    {
        static public Figure[] ReadFiguresFromTxt(string path)
        {
            // Инициализируем массив, который будем заполнять
            List<Figure> figures = new  List<Figure>();
            string line;
            string[] splittedLine;

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    splittedLine = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Figure addedFigure = DetermineFigure(splittedLine);
                    figures.Add(addedFigure);
                }
            }

            return figures.ToArray();
        }

        // Определение, что это за фигура
        private static Figure DetermineFigure(string[] splittedLine)
        {
            Figure addedFigure;

            switch (splittedLine[0])
            {
                case "Triangle":
                    addedFigure = new Triangle(int.Parse(splittedLine[1]), int.Parse(splittedLine[2]),
                        int.Parse(splittedLine[3]), int.Parse(splittedLine[4]),
                        int.Parse(splittedLine[5]), int.Parse(splittedLine[6]));
                    break;
                case "Circle":
                    addedFigure = new Circle(int.Parse(splittedLine[1]), int.Parse(splittedLine[2]), double.Parse(splittedLine[3]));
                    break;
                case "Rectangle":
                    addedFigure = new Rectangle(double.Parse(splittedLine[1]), double.Parse(splittedLine[2]));
                    break;
                default:
                    throw new Exception("Такая фигура не предусмотрена");
            }
            return addedFigure;
        }
    }
}
