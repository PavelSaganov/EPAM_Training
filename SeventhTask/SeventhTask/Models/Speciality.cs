using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace SeventhTask.Models
{
    [Table(Name = "Specialties")]
    public class Speciality : IComparable<Speciality>
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long SpecialityId { get; set; }
        [Column]
        public string SpecialityName { get; set; }

        int IComparable<Speciality>.CompareTo(Speciality other)
        {
            return SpecialityName.CompareTo(other.SpecialityName);
        }
    }
}
