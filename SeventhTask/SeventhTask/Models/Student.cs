using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "Students")]
    public class Student : IComparable<Student>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long StudentId { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string Surname { get; set; }
        [Column]
        public string SecondName { get; set; }
        [Column]
        public long GroupId { get; set; }
        [Column]
        public DateTime BirthDay { get; set; }

        int IComparable<Student>.CompareTo(Student other)
        {
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
