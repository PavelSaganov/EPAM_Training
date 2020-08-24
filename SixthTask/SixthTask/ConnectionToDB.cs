using System;
using System.Data.SqlClient;

namespace SixthTask
{
    public class ConnectionToDB
    {
        //private static string connectionString;
        private static readonly ConnectionToDB instance = new ConnectionToDB();
        public static readonly SqlConnection connection = new SqlConnection();

        public static void Connect(string str)
        {
            connection.ConnectionString = str;
            //connectionString = str;
            connection.Open();
        }

        public static ConnectionToDB GetInstance()
        {
            return instance;
        }

        public static SqlConnection GetConnection()
        {
            return connection;
        }

        public static void Close()
        {
            connection.Close();
        }
    }
}
