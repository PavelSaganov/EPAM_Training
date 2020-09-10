using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SixthTask.Models
{
    public class ExamResult : IComparable<ExamResult>
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }

        public ExamResult()
        { }

        public ExamResult(params object[] properties)
        {
            Id =  Convert.ToInt32(properties[0]);
            ExamId =  Convert.ToInt32(properties[1]);
            StudentId =  Convert.ToInt32(properties[2]);
            Mark =  Convert.ToInt32(properties[3]);
        }
        public override string ToString()
        {
            return $"{ Id } { ExamId } { StudentId } { Mark }";
        }

        int IComparable<ExamResult>.CompareTo(ExamResult other)
        {
            return Mark.CompareTo(other.Mark);
        }
    }
}
