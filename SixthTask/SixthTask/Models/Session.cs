using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GroupId { get; set; }
    }
}
