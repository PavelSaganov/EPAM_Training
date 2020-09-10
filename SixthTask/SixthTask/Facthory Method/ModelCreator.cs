using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Facthory_Method
{
    public class ModelCreator
    {
        Type Type { get; set; }

        public ModelCreator(Type type)
        {
            Type = type;
        }

        public object Create(object[] properties)
        {
            switch (Type.Name)
            {
                case "Exam": return new Exam(properties);
                case "ExamResult": return new ExamResult(properties);
                case ("Group"): return new Group(properties);
                case ("PartialCredit"): return new PartialCredit(properties);
                case ("PartialCreditResult"): return new PartialCreditResult(properties);
                case ("Student"): return new Student(properties);
                case ("Session"): return new Session(properties);
                default:
                    throw new Exception("This model is not provided");
            }
        }
    }
}
