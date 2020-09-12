using SixthTask.Facthory_Method;
using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SixthTask.WorkWithDB
{
    public static class ORM
    {
        /// <summary>
        /// Puts an object into the database
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="model">Object that you want to put</param>
        public static void Create<T>(T model)
        {
            string propertyName = "";
            string values = "";
            var properties = typeof(T).GetProperties();
            var idProp = properties.FirstOrDefault(p => p.Name.Contains("Id"));

            foreach (var item in properties.SkipWhile(p => p == idProp))
            {
                propertyName += item.Name;
                if (properties.Last() != item)
                    propertyName += ", ";
                values += $"{item.GetValue(model)}, ";
            }

            values = values.Remove(values.Length - 2, 1);
            CRUD.Create(DefineTableName(model.GetType()), propertyName, values);
        }

        /// <summary>
        /// Reads an object of type T from the database
        /// </summary>
        /// <typeparam name="T">Type of read object</typeparam>
        /// <returns></returns>
        public static List<T> Read<T>()
        {
            SqlDataReader reader = (SqlDataReader)CRUD.Read(DefineTableName(typeof(T)));
            List<T> models = new List<T>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    List<object> properties = new List<object>();
                    for (int i = 0; i < typeof(T).GetProperties().Length; i++)
                    {
                        var val = reader.GetValue(i);
                        if (val.GetType() == typeof(string))
                            val = (val as string).Trim();
                        properties.Add(val);
                    }

                    ModelCreator modelCreator = new ModelCreator(typeof(T));
                    models.Add((T)modelCreator.Create(properties.ToArray()));
                }
            }

            reader.Close();
            return models;
        }

        /// <summary>
        /// Replaced a model in database
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <param name="oldModel">Replaced model</param>
        /// <param name="newModel">New model</param>
        public static void Update<T>(T oldModel, T newModel)
        {
            string attributies = "";
            string condition = "";
            var properties = typeof(T).GetProperties();
            var idProp = properties.FirstOrDefault(p => p.Name.Contains("Id"));

            condition += $"{idProp.Name} = { idProp.GetValue(oldModel) }";

            foreach (var item in properties.SkipWhile(p => p == idProp))
            {
                item.SetValue(oldModel, item.GetValue(newModel));
                if (item.PropertyType == typeof(int))
                    attributies += $"{ item.Name } = { item.GetValue(oldModel) }";
                else
                    attributies += $"{ item.Name } = '{ item.GetValue(oldModel) }'";

                if (properties.Last() != item)
                    attributies += ", ";
            }

            CRUD.Update(DefineTableName(typeof(T)), attributies, condition);
        }

        /// <summary>
        /// Deletes a list of models in the database
        /// </summary>
        /// <typeparam name="T">Type of deleted models</typeparam>
        /// <param name="models">Models that you want to delete</param>
        public static void Delete<T>(T model)
        {
            var properties = typeof(T).GetProperties();
            var idProp = properties.FirstOrDefault(p => p.Name.Contains("Id"));

            CRUD.Delete(DefineTableName(typeof(T)), $"{idProp.Name} = {idProp.GetValue(model)}");

        }

        public static List<Student> CreateExpulsionList(Group group)
        {
            List<Student> students = Read<Student>().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = Read<ExamResult>();
            List<Student> result = new List<Student>();

            foreach (var st in students)
            {
                if (examResults.Where(e => e.StudentId == st.StudentId).Count(e => e.Mark < 4) >= 3)
                    result.Add(st);
            }
            return result;
        }

        public static string DefineTableName(Type model)
        {
            switch (model.Name)
            {
                case ("Exam"):
                    return "Exams";
                case ("ExamResult"):
                    return "ExamResults";
                case ("Group"):
                    return "Groups";
                case ("PartialCredit"):
                    return "PartialCredits";
                case ("PartialCreditResult"):
                    return "PartialCreditResult";
                case ("Student"):
                    return "Students";
                case ("Session"):
                    return "StudySessions";

                case ("Exams"):
                    return "Exam";
                case ("ExamResults"):
                    return "ExamResult";
                case ("Groups"):
                    return "Group";
                case ("PartialCredits"):
                    return "PartialCredit";
                case ("Students"):
                    return "Student";
                case ("StudySessions"):
                    return "StudySession";
                default:
                    throw new Exception("This model is not provided");
            }
        }
    }
}
