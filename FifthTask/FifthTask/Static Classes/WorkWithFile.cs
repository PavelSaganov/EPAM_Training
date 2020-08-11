using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Ex1
{
    public static class WorkWithFile
    {
        public static void XmlSerialize<T>(string path, List<T> binaryTrees)
        {
            var formatter = new DataContractSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, binaryTrees);
            }
        }

        public static List<T> XmlDeserialize<T>(string path, List<T> binaryTrees)
        {
            var formatter = new DataContractSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                binaryTrees = (List<T>)formatter.ReadObject(fs);
            }

            return binaryTrees;
        }
    }
}
