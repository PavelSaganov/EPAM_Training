using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "Exams")]
    public class Exam : IComparable<Exam>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long ExamId { get; set; }
        [Column]
        public DateTime ExamDate { get; set; }
        [Column]
        public long SessionId { get; set; }
        [Column]
        public string ExamName { get; set; }
        [Column]
        public long GroupId { get; set; }
        [Column]
        public long ExaminerId { get; set; }

        int IComparable<Exam>.CompareTo(Exam other)
        {
            return ExamName.CompareTo(other.ExamName);
        }
    }
}
