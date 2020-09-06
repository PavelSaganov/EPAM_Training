using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
    }
}
