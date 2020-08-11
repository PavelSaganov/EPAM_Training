using Ex2.Enumerables;
using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Ex2
{
    [Serializable]
    public class Animal : ISerialize
    {
        public string Name { get; set; }
        public uint YearsOld { get; set; }
        public double Height { get; set; }
        public Gender Gender { get; set; }

        public Animal() { }
        public Animal(string Name, uint YearsOld, double Height, Gender Gender)
        {
            this.Name = Name;
            this.YearsOld = YearsOld;
            this.Height = Height;
            this.Gender = Gender;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this == null)
                return false;
            Animal animal = obj as Animal;
            if (animal == null)
                return false;

            return animal.Name == Name && animal.YearsOld == YearsOld && animal.Height == Height && animal.Gender == Gender;
        }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() + YearsOld.GetHashCode() + Height.GetHashCode()) * Gender.GetHashCode();
        }
    }
}
