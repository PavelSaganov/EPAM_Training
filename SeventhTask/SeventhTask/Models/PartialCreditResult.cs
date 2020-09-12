using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "PartialCreditResult")]
    public class PartialCreditResult : IComparable<PartialCreditResult>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long PartialCreditResultId { get; set; }
        [Column(Name = "Pass")]
        public bool IsPassed { get; set; }
        [Column]
        public long PartialCreditId { get; set; }
        [Column]
        public long StudentId { get; set; }

        int IComparable<PartialCreditResult>.CompareTo(PartialCreditResult other)
        {
            return IsPassed.CompareTo(other.IsPassed);
        }
    }
}
