using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "ExamResults")]
    public class ExamResult : IComparable<ExamResult>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long ExamResultId { get; set; }
        [Column]
        public int Mark { get; set; }
        [Column]
        public long ExamId { get; set; }
        [Column]
        public long StudentId { get; set; }

        int IComparable<ExamResult>.CompareTo(ExamResult other)
        {
            return Mark.CompareTo(other.Mark);
        }
    }
}
