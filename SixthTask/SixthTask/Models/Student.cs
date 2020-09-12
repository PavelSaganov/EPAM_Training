using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Student : IComparable<Student>
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public int GroupId { get; set; }
        public DateTime BirthDay { get; set; }

        public Student()
        { }

        public Student(object[] properties)
        {
            StudentId = Convert.ToInt32(properties[0]);
            GroupId = Convert.ToInt32(properties[1]);
            FirstName = (string)properties[2];
            Surname = (string)properties[3];
            SecondName = (string)properties[4];
            BirthDay = (DateTime)properties[5];
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Student m = obj as Student; // возвращает null если объект нельзя привести к типу Money
            if (m as Student == null)
                return false;

            return m.GroupId == GroupId && m.FirstName == FirstName && m.BirthDay == BirthDay && m.Surname == Surname && m.SecondName == SecondName;
        }

        public override int GetHashCode()
        {
            return GroupId.GetHashCode() * SecondName.GetHashCode() * FirstName.GetHashCode() + Surname.GetHashCode() * BirthDay.GetHashCode();
        }

        int IComparable<Student>.CompareTo(Student other)
        {
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
