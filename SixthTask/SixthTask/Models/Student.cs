using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Student : IComparable<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public int GroupId { get; set; }
        public DateTime BirthDay { get; set; }

        public Student()
        { }

        public Student(object[] properties)
        {
            Id = Convert.ToInt32(properties[0]);
            GroupId = Convert.ToInt32(properties[1]);
            FirstName = (string)properties[2];
            Surname = (string)properties[3];
            SecondName = (string)properties[4];
            BirthDay = (DateTime)properties[5];
        }

        public override string ToString()
        {
            return $"{ Id }, { GroupId }, '{ FirstName }', '{ Surname }', '{ SecondName }', '{ BirthDay }'";
        }

        int IComparable<Student>.CompareTo(Student other)
        {
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
