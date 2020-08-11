using Ex2.Interfaces;
using Ex2.Static_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Ex2
{
    [Serializable]
    public class MyGenericCollection<T> : ICollection<T>
    {
        public ICollection<T> List { get; private set; }

        public int Count => ((ICollection<T>)List).Count;

        public bool IsReadOnly => ((ICollection<T>)List).IsReadOnly;

        /// <summary>
        /// Adds new item to collection if it implement ISerialize
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (item is ISerialize)
            ((ICollection<T>)List).Add(item);
            else throw new Exception("This object not implement ISerialize");
        }

        public void Clear()
        {
            ((ICollection<T>)List).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)List).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)List).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)List).GetEnumerator();
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)List).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)List).GetEnumerator();
        }

        public void XmlSerialize(string path, ICollection list)
        {
            WorkWithFile.XmlSerialize(path, List);
        }

        public void XmlDeserialize(string path)
        {
            List = WorkWithFile.XmlDeserialize<T>(path);
        }

        public void BinSerialize(string path)
        {
            WorkWithFile.BinSerialize(path, List);
        }

        public void BinDeserialize(string path)
        {
            List = WorkWithFile.BinDeserialize<T>(path);

        }

        public void JsonSerialize(string path, ICollection list)
        {
            WorkWithFile.JsonSerialize(path, List);
        }

        public void JsonDeserialize(string path)
        {
            List = WorkWithFile.JsonDeserialize<T>(path);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this == null)
                return false;
            MyGenericCollection<T> st = obj as MyGenericCollection<T>;
            if (st == null)
                return false;

            for (int i = 0; i < List.Count; i++)
            {
                if (!st.ElementAt(i).Equals(List.ElementAt(i)))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return List.GetHashCode() * List.FirstOrDefault().GetHashCode();
        }
    }
}
