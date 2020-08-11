using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1
{
    public class Student
    {
        public string Name { get; set; }
        public StudentTest Test { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || this == null)
                return false;
            Student st = obj as Student;
            if (st == null)
                return false;

            return st.Name == Name && st.Test.Name == Test.Name && st.Test.Mark == Test.Mark && st.Test.Date == Test.Date;
        }

        public override int GetHashCode()
        { 
            return (Name.GetHashCode() + Test.Name.GetHashCode()) * 
                Test.Mark.GetHashCode() * Test.Date.GetHashCode(); 
        }
    }
}
