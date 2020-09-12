using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class PartialCreditResult : IComparable<PartialCreditResult>
    {
        public int PartialCreditResultId { get; set; }
        public bool IsPassed { get; set; }
        public int PartialCreditId { get; set; }
        public int StudentId { get; set; }

        public PartialCreditResult()
        { }

        public PartialCreditResult(params object[] properties)
        {
            PartialCreditResultId =  Convert.ToInt32(properties[0]);
            PartialCreditId =  Convert.ToInt32(properties[1]);
            StudentId =  Convert.ToInt32(properties[2]);
            IsPassed = (bool)properties[3];
        }

        public override string ToString()
        {
            return $"{ PartialCreditResultId }, { PartialCreditId }, { StudentId }, '{ IsPassed }'";
        }

        int IComparable<PartialCreditResult>.CompareTo(PartialCreditResult other)
        {
            return IsPassed.CompareTo(other.IsPassed);
        }
    }
}
