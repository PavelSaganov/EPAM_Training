﻿using Enumerables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace Figures
{
    static public class WorkWithFile
    {
        static public Figure[] ReadXmlFile(string path)
        {
            List<Figure> figures = new List<Figure>();

            using (XmlReader xmlReader = XmlReader.Create(path))
            {
                for (int i = 0; xmlReader.Read(); i++)
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        Colors color;
                        switch (xmlReader.Name)
                        {
                            case ("Circle"):
                                int x = int.Parse(xmlReader.GetAttribute(0));
                                int y = int.Parse(xmlReader.GetAttribute(1));
                                double radius = double.Parse(xmlReader.GetAttribute(2));
                                color = Enum.Parse<Colors>(xmlReader.GetAttribute(3));

                                figures.Add(new Circle(x, y, radius, color));
                                break;
                            case ("Triangle"):
                                int x1 = int.Parse(xmlReader.GetAttribute(0));
                                int y1 = int.Parse(xmlReader.GetAttribute(1));
                                int x2 = int.Parse(xmlReader.GetAttribute(2));
                                int y2 = int.Parse(xmlReader.GetAttribute(3));
                                int x3 = int.Parse(xmlReader.GetAttribute(4));
                                int y3 = int.Parse(xmlReader.GetAttribute(5));
                                color = Enum.Parse<Colors>(xmlReader.GetAttribute(6));

                                figures.Add(new Triangle(x1, y1, x2, y2, x3, y3, color));
                                break;
                            case ("Rectangle"):
                                double width = double.Parse(xmlReader.GetAttribute(0));
                                double higth = double.Parse(xmlReader.GetAttribute(1));
                                color = Enum.Parse<Colors>(xmlReader.GetAttribute(2));

                                figures.Add(new Rectangle(width, higth, color));
                                break;
                        }
                    }
                }
            }
            return figures.ToArray();
        }

        //static public Figure[] ReadXmlFileByStreamReader(string path)
        //{
        //    List<Figure> figures = new List<Figure>();

        //    using(StreamReader streamReader = new StreamReader(path, )


        //    XmlReader xmlReader = XmlReader.Create(path);

        //    for (int i = 0; xmlReader.Read(); i++)
        //    {
        //        if (xmlReader.NodeType == XmlNodeType.Element)
        //        {
        //            Colors color;
        //            switch (xmlReader.Name)
        //            {
        //                case ("Circle"):
        //                    int x = int.Parse(xmlReader.GetAttribute(0));
        //                    int y = int.Parse(xmlReader.GetAttribute(1));
        //                    double radius = double.Parse(xmlReader.GetAttribute(2));
        //                    color = Enum.Parse<Colors>(xmlReader.GetAttribute(3));

        //                    figures.Add(new Circle(x, y, radius, color));
        //                    break;
        //                case ("Triangle"):
        //                    int x1 = int.Parse(xmlReader.GetAttribute(0));
        //                    int y1 = int.Parse(xmlReader.GetAttribute(1));
        //                    int x2 = int.Parse(xmlReader.GetAttribute(2));
        //                    int y2 = int.Parse(xmlReader.GetAttribute(3));
        //                    int x3 = int.Parse(xmlReader.GetAttribute(4));
        //                    int y3 = int.Parse(xmlReader.GetAttribute(5));
        //                    color = Enum.Parse<Colors>(xmlReader.GetAttribute(6));

        //                    figures.Add(new Triangle(x1, y1, x2, y2, x3, y3, color));
        //                    break;
        //                case ("Rectangle"):
        //                    double width = double.Parse(xmlReader.GetAttribute(0));
        //                    double higth = double.Parse(xmlReader.GetAttribute(1));
        //                    color = Enum.Parse<Colors>(xmlReader.GetAttribute(2));

        //                    figures.Add(new Rectangle(width, higth, color));
        //                    break;
        //            }
        //        }
        //    }

        //    return figures.ToArray();
        //}

        static public void WriteToXmlFile(string path, Figure[] figures)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(path))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Figures");

                foreach (var f in figures)
                {
                    WriteFigure(xmlWriter, f);
                }
                xmlWriter.WriteEndDocument();
            }
        }

        /// <summary>
        /// Определение и запись фигуры в xml файл
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="f">Фигура, которую необходимо записать</param>
        private static void WriteFigure(XmlWriter xmlWriter, Figure f)
        {
            string[] splittedLine = f.ToString().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            xmlWriter.WriteStartElement(f.GetType().Name);

            if (f is Circle)
            {
                xmlWriter.WriteAttributeString("CenterX", splittedLine[1]);
                xmlWriter.WriteAttributeString("CenterY", splittedLine[2]);
                xmlWriter.WriteAttributeString("Radius", splittedLine[3]);
                xmlWriter.WriteAttributeString("Color", splittedLine[4]);

            }
            else if (f is Rectangle)
            {
                xmlWriter.WriteAttributeString("Width", splittedLine[1]);
                xmlWriter.WriteAttributeString("Hight", splittedLine[2]);
                xmlWriter.WriteAttributeString("Color", splittedLine[3]);
            }
            else if (f is Triangle)
            {
                xmlWriter.WriteAttributeString("FirstPointX", splittedLine[1]);
                xmlWriter.WriteAttributeString("FirstPointY", splittedLine[2]);
                xmlWriter.WriteAttributeString("SecondPointX", splittedLine[3]);
                xmlWriter.WriteAttributeString("SecondPointY", splittedLine[4]);
                xmlWriter.WriteAttributeString("ThirdPointX", splittedLine[5]);
                xmlWriter.WriteAttributeString("ThirdPointY", splittedLine[6]);
                xmlWriter.WriteAttributeString("Color", splittedLine[7]);
            }
            else throw new Exception("Такая фигура не предусмотрена!");

            xmlWriter.WriteEndElement();
        }

        static public Figure[] ReadFiguresFromTxt(string path)
        {
            // Инициализируем массив, который будем заполнять
            List<Figure> figures = new List<Figure>();
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

        /// <summary>
        /// Определение типа и создание фигуры, на основе передаваемого массива строк 
        /// </summary>
        /// <param name="splittedLine">Массив строк, каждый элемент которого передается в конструктор фигуры</param>
        /// <returns>Новая фигура, созданная на основе splittedLine</returns>
        private static Figure DetermineFigure(string[] splittedLine)
        {
            Figure addedFigure;

            switch (splittedLine[0])
            {
                case "Triangle":
                    addedFigure = new Triangle(int.Parse(splittedLine[1]), int.Parse(splittedLine[2]),
                        int.Parse(splittedLine[3]), int.Parse(splittedLine[4]),
                        int.Parse(splittedLine[5]), int.Parse(splittedLine[6]), Enum.Parse<Colors>(splittedLine[7]));
                    break;
                case "Circle":
                    addedFigure = new Circle(int.Parse(splittedLine[1]), int.Parse(splittedLine[2]), double.Parse(splittedLine[3]), Enum.Parse<Colors>(splittedLine[7]));
                    break;
                case "Rectangle":
                    addedFigure = new Rectangle(double.Parse(splittedLine[1]), double.Parse(splittedLine[2]), Enum.Parse<Colors>(splittedLine[7]));
                    break;
                default:
                    throw new Exception("Такая фигура не предусмотрена");
            }
            return addedFigure;
        }
    }
}

