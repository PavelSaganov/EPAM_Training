using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Ex1
{
    public static class WorkWithFile
    {
        public static void XmlSerialize<T>(string path, List<BinaryTree<T>> binaryTrees)
        {
            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(List<BinaryTree<T>>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, binaryTrees);

                // Console.WriteLine("Объект сериализован");
            }
        }

        private static List<BinaryTree<T>> XmlDeserialize<T>(string path, List<BinaryTree<T>> binaryTrees)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<BinaryTree<T>>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                binaryTrees = (List<BinaryTree<T>>)formatter.Deserialize(fs);

                //Console.WriteLine("Объект десериализован");
                //Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            }

            return binaryTrees;
        }
    }
}
