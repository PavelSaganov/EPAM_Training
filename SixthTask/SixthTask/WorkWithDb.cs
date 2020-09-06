using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace SixthTask
{
    public static class WorkWithDb
    {
        static DbConnection DbConnection = ConnectionToDB.GetConnection();

        public static void Create<T>(T model)
        {
            string sqlExpression = "INSERT INTO " + DefineTableName(model.GetType()) + " VALUES " + model.ToString();

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            command.ExecuteNonQuery();

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        switch (models.GetType().Name)
            //        {
            //            case ("Exam"):
            //                (models as List<Exam>).Add(new Exam { Id = (int)reader.GetInt64(0), Name = reader.GetString(1), SessionId = (int)reader.GetInt64(2) });
            //                break;
            //            case ("ExamResult"):
            //                (models as List<ExamResult>).Add(new ExamResult { Id = (int)reader.GetInt64(0), Name = reader.GetString(1), SessionId = (int)reader.GetInt64(2) });
            //                break;
            //            case ("Group"):
            //                return "Groups";
            //            case ("PartialCredit"):
            //                return "PartialCredits";
            //            case ("PartialCreditResult"):
            //                return "PartialCreditResults";
            //            case ("Student"):
            //                return "Students";
            //            default:
            //                throw new Exception("This model is not provided");
            //        }
            //        //models.Add();
            //    }
            //}
        }

        public static List<T> Read<T>()
        {
            string sqlExpression = "SELECT * FROM " + DefineTableName(typeof(T));
            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<T> models = new List<T>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    switch (typeof(T).Name)
                    {
                        case ("Exam"):
                            (models as List<Exam>).Add(new Exam
                            {
                                Id = (int)reader.GetInt64(0),
                                Name = reader.GetString(1),
                                SessionId = (int)reader.GetInt64(2)
                            });
                            break;
                        case ("ExamResult"):
                            (models as List<ExamResult>).Add(new ExamResult
                            {
                                Id = (int)reader.GetInt64(0),
                                ExamId = (int)reader.GetInt64(1),
                                StudentId = (int)reader.GetInt64(2),
                                Mark = (int)reader.GetInt64(3)
                            });
                            break;
                        case ("Group"):
                            (models as List<Group>).Add(new Group { Id = (int)reader.GetInt64(0), Name = reader.GetString(1) });
                            break;
                        case ("PartialCredit"):
                            (models as List<PartialCredit>).Add(new PartialCredit
                            {
                                Id = (int)reader.GetInt64(0),
                                SessionId = (int)reader.GetInt64(1),
                                Date = reader.GetDateTime(2),
                                Name = reader.GetString(3)
                            });
                            break;
                        case ("PartialCreditResult"):
                            (models as List<PartialCreditResult>).Add(new PartialCreditResult { Id = (int)reader.GetInt64(0), PartialCreditId = (int)reader.GetInt64(1), StudentId = (int)reader.GetInt64(2), IsPassed = reader.GetBoolean(3) });
                            break;
                        case ("Student"):
                            (models as List<Student>).Add(new Student
                            {
                                Id = (int)reader.GetInt64(0),
                                GroupId = (int)reader.GetInt64(1),
                                FirstName = reader.GetString(2),
                                Surname = reader.GetString(3),
                                SecondName = reader.GetString(4),
                                BirthDay = reader.GetDateTime(5)
                            });
                            break;
                        case ("Session"):
                            (models as List<Session>).Add(new Session
                            {
                                Id = (int)reader.GetInt64(0),
                                GroupId = (int)reader.GetInt64(1),
                                StartDate = reader.GetDateTime(2),
                                EndDate = reader.GetDateTime(3)
                            });
                            break;
                        default:
                            throw new Exception("This model is not provided");
                    }
                }
            }
            return models;
        }

        public static void Update()
        {

        }

        public static void Delete()
        {

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
                    return "PartialCreditResults";
                case ("Student"):
                    return "Students";
                case ("Session"):
                    return "StudySessions";
                default:
                    throw new Exception("This model is not provided");
            }
        }
    }
}
