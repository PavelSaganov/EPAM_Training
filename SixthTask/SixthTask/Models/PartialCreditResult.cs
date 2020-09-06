using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class PartialCreditResult
    {
        public int Id { get; set; }
        public bool IsPassed { get; set; }
        public int PartialCreditId { get; set; }
        public int StudentId { get; set; }
    }
}
