using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace SixthTask
{
    public static class CRUD
    {
        static DbConnection DbConnection = ConnectionToDB.GetConnection();

        public static void Create(string tableName, string propertyNames, string values)
        {
            string sqlExpression = $"INSERT INTO { tableName } ({ propertyNames })  VALUES ({ values });";

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Reads data from database
        /// </summary>
        /// <param name="tableName">Name of table in database</param>
        /// <returns></returns>
        public static DbDataReader Read(string tableName)
        {
            string sqlExpression = "SELECT * FROM " + tableName;
            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            SqlDataReader reader = command.ExecuteReader();
            
            return reader;
        }

        /// <summary>
        /// Updates data in database
        /// </summary>
        /// <param name="tableName">Name of updated table</param>
        /// <param name="attributes">Attributes of updated table</param>
        /// <param name="condition">Condtions to update table</param>
        public static void Update(string tableName, string attributes, string condition)
        {
            string sqlExpression = "UPDATE " + tableName + " SET " + attributes + " WHERE " + condition + ";";

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes data from database
        /// </summary>
        /// <param name="tableName">Name of table where is deleted model</param>
        /// <param name="condition">Conditions of deleting</param>
        public static void Delete(string tableName, string condition)
        {
            string sqlExpression = "DELETE FROM " + tableName + " WHERE " + condition + ";";

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            command.ExecuteNonQuery();
        }
    }
}
