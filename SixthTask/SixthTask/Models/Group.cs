using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Group
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
