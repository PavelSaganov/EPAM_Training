using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ExamResult Result { get; set; }
    }
}
