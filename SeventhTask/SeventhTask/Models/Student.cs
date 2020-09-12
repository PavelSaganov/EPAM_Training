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

        public override bool Equals(object obj)
        {
            Student st = obj as Student;
            if (st == null)
                return false;
            return FirstName == st.FirstName && SecondName == st.SecondName && GroupId == st.GroupId && BirthDay == st.BirthDay;
        }

        public override int GetHashCode()
        {
            return Surname.GetHashCode() + FirstName.GetHashCode() * BirthDay.GetHashCode();
        }
    }
}
