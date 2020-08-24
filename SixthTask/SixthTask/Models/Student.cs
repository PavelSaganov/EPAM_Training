using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Exam> Exams { get; set; }
        public List<PartialCredit> PartialCredits { get; set; }
    }
}
