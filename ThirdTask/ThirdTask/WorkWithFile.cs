using Enumerables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Figures
{
    static public class WorkWithFile
    {
        /// <summary>
        /// Чтение xml файла с помощью StreamReader
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Массив фигур, считанных с файла</returns>
        static public Figure[] ReadXmlFileByStreamReader(string path)
        {
            List<Figure> figures = new List<Figure>();
            string line;

            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = line.Replace("\"", "");

                    Regex regex = new Regex("=(\\w*)");
                    MatchCollection matches = regex.Matches(line);
                    string[] attributes = new string[matches.Count];

                    // Выделение атрибутов в строке
                    for (int i = 0; i < matches.Count; i++)
                    {
                        attributes[i] = matches.ElementAt(i).ToString().Substring(1);
                    }

                    // Получение типа фигуры
                    string typeName = line.Split()[0].Substring(1);

                    Figure addedFigure = CreateAddedFigure(typeName, attributes);
                    if (addedFigure != null)
                        figures.Add(addedFigure);
                }
            }

            return figures.ToArray();

            /// <summary>
            /// Создание фигуры
            /// </summary>
            /// <param name="typeName">Название класса</param>
            /// <param name="attributes">Массив строк атрибутов фигуры</param>
            /// <returns>Инициализированная фигура</returns>
            Figure CreateAddedFigure(string typeName, string[] attributes)
            {
                Figure addedFigure;
                switch (typeName)
                {
                    #region CreatingTriangle
                    case "Triangle":
                        addedFigure = new Triangle(int.Parse(attributes[0]), int.Parse(attributes[1]),
                            int.Parse(attributes[2]), int.Parse(attributes[3]),
                            int.Parse(attributes[4]), int.Parse(attributes[5]), Enum.Parse<Colors>(attributes[6]));
                        break;
                    #endregion

                    #region CreatingCircle
                    case "Circle":
                        addedFigure = new Circle(int.Parse(attributes[0]), int.Parse(attributes[1]), double.Parse(attributes[2]), Enum.Parse<Colors>(attributes[3]));
                        break;
                    #endregion

                    #region CreatingRectangle
                    case "Rectangle":
                        addedFigure = new Rectangle(double.Parse(attributes[0]), double.Parse(attributes[1]), Enum.Parse<Colors>(attributes[2]));
                        break;
                    #endregion

                    default:
                        addedFigure = null;
                        break;
                }

                return addedFigure;
            }
        }

        /// <summary>
        /// Запись xml файла с помощью StreamWriter
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="figures">Массив фигур, которые необходимо записать</param>
        static public void WriteXmlFileByStreamWriter(string path, Figure[] figures)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                streamWriter.WriteLine("<Figures>");

                foreach (var f in figures)
                {
                    streamWriter.Write("<");

                    string figureName = f.GetType().Name;

                    streamWriter.Write($"{ figureName } ");

                    #region AdditingFigure
                    switch (figureName)
                    {
                        case "Circle":
                            Circle c = f as Circle;
                            streamWriter.Write($"CenterX=\"{ c.Center.X }\" CenterY=\"{ c.Center.Y }\" Radius=\"{ c.Radius }\" ");
                            break;
                        case "Rectangle":
                            Rectangle r = f as Rectangle;
                            streamWriter.Write($"Width=\"{ r.Width }\" Hight=\"{ r.Hight }\" ");
                            break;
                        case "Triangle":
                            Triangle t = f as Triangle;
                            streamWriter.Write($"FirstPointX=\"{ t.FirstPoint.X }\" FirstPointY=\"{ t.FirstPoint.Y }\" " +
                                $"SecondPointX=\"{ t.SecondPoint.X }\" SecondPointY=\"{ t.SecondPoint.Y }\" " +
                                $"ThirdPointX=\"{ t.ThirdPoint.X }\" ThirdPointY=\"{ t.ThirdPoint.Y }\" ");
                            break;
                    }
                    #endregion

                    streamWriter.Write($"Color=\"{ f.Color }\" ");
                    streamWriter.WriteLine("/>");
                }
                streamWriter.Write("</Figures>");
            }
        }


        /// <summary>
        /// Чтение xml файла с помощью XmlReader
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Массив фигур, считанных из файла</returns>
        static public Figure[] ReadXmlFileByXmlReader(string path)
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

        /// <summary>
        /// Запись в xml файл массива, с помощью XmlWriter
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="figures">Массив фигур, который необходимо записать</param>
        static public void WriteXmlFileByXmlWriter(string path, Figure[] figures)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(path))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Figures");

                foreach (var f in figures)
                {
                    xmlWriter.WriteString("\n");
                    WriteFigure(xmlWriter, f);
                }
                xmlWriter.WriteString("\n");
                xmlWriter.WriteEndDocument();

                /// <summary>
                /// Определение и запись фигуры в xml файл
                /// </summary>
                /// <param name="xmlWriter"></param>
                /// <param name="f">Фигура, которую необходимо записать</param>
                void WriteFigure(XmlWriter xmlWriter, Figure f)
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
            }
        }
    }
}

