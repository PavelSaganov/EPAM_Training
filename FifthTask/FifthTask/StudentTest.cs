using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1
{
    public class StudentTest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public uint Mark { get; set; }

        #region Operator overriding
        public static bool operator <(StudentTest st1, StudentTest st2)
        {
            return st1.Mark < st2.Mark;
        }

        public static bool operator >(StudentTest st1, StudentTest st2)
        {
            return st1.Mark > st2.Mark;
        }

        public static bool operator <=(StudentTest st1, StudentTest st2)
        {
            return st1.Mark <= st2.Mark;
        }

        public static bool operator >=(StudentTest st1, StudentTest st2)
        {
            return st1.Mark >= st2.Mark;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null || this == null)
                return false;
            StudentTest st = obj as StudentTest;
            if (st == null)
                return false;

            return st.Name == Name && st.Mark == Mark && st.Date == Date;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * Mark.GetHashCode() * Date.GetHashCode();
        }
    }
}
