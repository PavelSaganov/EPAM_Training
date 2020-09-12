using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "Groups")]
    public class Group : IComparable<Group>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long GroupId { get; set; }
        [Column]
        public string GroupName { get; set; }
        [Column]
        public long SpecialityId { get; set; }

        int IComparable<Group>.CompareTo(Group other)
        {
            return GroupName.CompareTo(other.GroupName);
        }
    }
}
