using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class PartialCredit : IComparable<PartialCredit>
    {
        public int PartialCreditId { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int SessionId { get; set; }
        public int GroupId { get; set; }

        public PartialCredit()
        { }

        public PartialCredit(params object[] properties)
        {
            PartialCreditId =  Convert.ToInt32(properties[0]);
            SessionId =  Convert.ToInt32(properties[1]);
            Date = (DateTime)properties[2];
            GroupId =  Convert.ToInt32(properties[3]);
        }

        public override string ToString()
        {
            return $"{ PartialCreditId }, { SessionId }, '{ Date }'";
        }

        int IComparable<PartialCredit>.CompareTo(PartialCredit other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
