using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Text;

namespace SeventhTask.Models
{
    [Table(Name = "Examiners")]
    public class Examiner : IComparable<Examiner>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long ExaminerId { get; set; }
        [Column]
        public string ExaminerName { get; set; }

        int IComparable<Examiner>.CompareTo(Examiner other)
        {
            return ExaminerName.CompareTo(other.ExaminerName);
        }
    }
}
