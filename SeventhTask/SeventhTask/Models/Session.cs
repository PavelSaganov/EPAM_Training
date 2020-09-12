using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "StudySessions")]
    public class Session : IComparable<Session>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long SessionId { get; set; }
        [Column]
        public DateTime StartDate { get; set; }
        [Column]
        public DateTime EndDate { get; set; }

        int IComparable<Session>.CompareTo(Session other)
        {
            return StartDate.CompareTo(other.StartDate);
        }
    }
}
