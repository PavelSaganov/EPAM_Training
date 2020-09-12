using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SixthTask
{
    public static class CRUD
    {
        static DbConnection DbConnection = ConnectionToDB.GetConnection();

        /// <summary>
        /// Creates new data in database
        /// </summary>
        /// <param name="tableName">Name of table where you want to create new model</param>
        /// <param name="propertiesName">Property names string of new model</param>
        /// <param name="values">Values of properties</param>
        public static void Create(string tableName, string propertiesName, string values)
        {
            string sqlExpression = $"INSERT INTO { tableName } ({ propertiesName }) VALUES ( ";
            var valuesArr = values.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < valuesArr.Length; i++)
            {
                if (i != valuesArr.Length - 1)
                    sqlExpression += $"@v{i}, ";
                else sqlExpression += $"@v{i});";
            }

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);

            for (int i = 0; i < valuesArr.Length; i++)
                command.Parameters.AddWithValue($"@v{i}", valuesArr[i]);
            
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Reads data from database
        /// </summary>
        /// <param name="tableName">Name of table in database</param>
        /// <returns></returns>
        public static DbDataReader Read(string tableName)
        {
            string sqlExpression = $"SELECT * FROM {tableName}";
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
            var str = condition.Split(" = ");
            string sqlExpression = $"UPDATE {tableName} SET {attributes} WHERE ";
            for (int i = 1; i < str.Length; i += 2)
                sqlExpression += $"{str[i - 1]} = @{i}";
            sqlExpression += ";";

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);
            for (int i = 1; i < str.Length; i += 2)
                command.Parameters.AddWithValue($"@{i}", str[i]);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes data from database
        /// </summary>
        /// <param name="tableName">Name of table where is deleted model</param>
        /// <param name="condition">Conditions of deleting</param>
        public static void Delete(string tableName, string condition)
        {
            var str = condition.Split(" = ");
            string sqlExpression = $"DELETE FROM {tableName} WHERE ";
            for (int i = 1; i < str.Length; i += 2)
                sqlExpression += $"{str[i - 1]} = @{i}";
            sqlExpression += ";";

            SqlCommand command = new SqlCommand(sqlExpression, (SqlConnection)DbConnection);

            for (int i = 1; i < str.Length; i += 2)
                command.Parameters.AddWithValue($"@{i}", str[i]);

            command.ExecuteNonQuery();
        }
    }
}
