using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Group : IComparable<Group>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group()
        { }

        public Group(params object[] properties)
        {
            Id = Convert.ToInt32(properties[0]);
            Name = (string)properties[1];
        }

        public override string ToString()
        {
            return $"{ Id }, '{ Name }'";
        }

        int IComparable<Group>.CompareTo(Group other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
