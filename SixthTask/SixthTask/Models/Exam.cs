using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SixthTask.Models
{
    public class Exam : IComparable<Exam>
    {
        public int ExamId { get; set; }
        public DateTime Date { get; set; }
        public int SessionId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        public Exam()
        { }

        public Exam(params object[] properties)
        {
            ExamId =  Convert.ToInt32(properties[0]);
            SessionId =  Convert.ToInt32(properties[1]);
            Date = (DateTime)properties[2];
            Name = (string)properties[3];
            GroupId = Convert.ToInt32(properties[4]);
        }

        public override string ToString()
        {
            return $"{ ExamId }, { SessionId }, '{ Date }', '{ Name }'";
        }

        int IComparable<Exam>.CompareTo(Exam other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
