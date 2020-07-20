using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Figures
{
    static public class WorkWithFile
    {
        /// <summary>
        /// Метод для чтения txt файла фигур
        /// </summary>
        /// <param name="path">Путь к txt файлу</param>
        /// <returns></returns>
        static public Figure[] ReadFiguresFromTxt(string path)
        {
            // Инициализируем массив, который будем заполнять
            Figure[] figures = new Figure[File.ReadAllLines(path).Length];
            string line;
            string[] splittedLine;

            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    splittedLine = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Figure addedFigure = DetermineFigure(splittedLine);
                    figures[i] = addedFigure;
                }
            }

            return figures;
        }

        /// <summary>
        /// Определение, что эта за фигура
        /// </summary>
        /// <param name="splittedLine">Строка, разбитая по словам</param>
        /// <returns></returns>
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
