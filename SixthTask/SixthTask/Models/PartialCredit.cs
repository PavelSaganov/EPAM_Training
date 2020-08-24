using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class PartialCredit
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public Student Student { get; set; }
    }
}
