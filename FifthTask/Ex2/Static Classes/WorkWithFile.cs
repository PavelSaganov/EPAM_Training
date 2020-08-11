using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Ex2.Static_Classes
{
    public static class WorkWithFile
    {
        /// <summary>
        /// Creates a new xml file and writes list to it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <param name="list">List of objects that should be writed</param>
        public static void XmlSerialize<T>(string path, ICollection<T> list)
        {
            if (File.Exists(path))
                File.Delete(path);
            var formatter = new DataContractSerializer(typeof(ICollection<T>));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.WriteObject(fs, list);
            }
        }

        /// <summary>
        /// Reads collection from xml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <returns>Collection that was write to xml file</returns>
        public static ICollection<T> XmlDeserialize<T>(string path)
        {
            ICollection<T> list;
            var formatter = new DataContractSerializer(typeof(ICollection<T>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                list = (ICollection<T>)formatter.ReadObject(fs);
            }

            return list;
        }

        /// <summary>
        /// Creates a new bin file and writes list to it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <param name="list">List of objects that should be writed</param>
        public static void BinSerialize<T>(string path, ICollection<T> list)
        {
            var formatter = new BinaryFormatter();

            if (File.Exists(path))
                File.Delete(path);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }

        /// <summary>
        /// Reads collection from bin file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <returns>Collection that was write to bin file</returns>
        public static ICollection<T> BinDeserialize<T>(string path)
        {
            var formatter = new BinaryFormatter();
            ICollection<T> list;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                list = (ICollection<T>)formatter.Deserialize(fs);
            }

            return list;
        }

        /// <summary>
        /// Creates a new json file and writes list to it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <param name="list">List of objects that should be writed</param>
        public static void JsonSerialize<T>(string path, ICollection<T> list)
        {
            if (File.Exists(path))
                File.Delete(path);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, list);
            }
        }

        /// <summary>
        /// Reads collection from json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to file</param>
        /// <returns>Collection that was write to json file</returns>
        public static ICollection<T> JsonDeserialize<T>(string path)
        {
            ICollection<T> list;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string json = Encoding.UTF8.GetString(array);
                list = JsonSerializer.Deserialize<ICollection<T>>(json);
            }

            return list;
        }
    }
}