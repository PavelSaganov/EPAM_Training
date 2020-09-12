using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "PartialCredits")]
    public class PartialCredit : IComparable<PartialCredit>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long PartialCreditId { get; set; }
        [Column]
        public DateTime PartialCreditDate { get; set; }
        [Column]
        public string PartialCreditName { get; set; }
        [Column]
        public long SessionId { get; set; }
        [Column]
        public long GroupId { get; set; }
        [Column]
        public long ExaminerId { get; set; }

        int IComparable<PartialCredit>.CompareTo(PartialCredit other)
        {
            return PartialCreditName.CompareTo(other.PartialCreditName);
        }
    }
}
