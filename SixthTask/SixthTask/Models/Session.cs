using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Models
{
    public class Session : IComparable<Session>
    {
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Session()
        { }

        public Session(params object[] properties)
        {
            SessionId =  Convert.ToInt32(properties[0]);
            StartDate = (DateTime)properties[1];
            EndDate = (DateTime)properties[2];
        }

        int IComparable<Session>.CompareTo(Session other)
        {
            return StartDate.CompareTo(other.StartDate);
        }
    }
}
