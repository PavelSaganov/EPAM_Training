using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SixthTask
{
    public class ConnectionToDB
    {
        private static DbConnection connection;

        /// <summary>
        /// Singleton realization of connection
        /// </summary>
        public ConnectionToDB()
        {
            if (connection == null)
                connection = new SqlConnection();
        }

        /// <summary>
        /// Singleton realization of connection
        /// </summary>
        /// <param name="connectionString">The connection used to open the SQL Server database</param>
        public ConnectionToDB(string connectionString)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Open connection
        /// </summary>
        public void Open() => connection.Open();

        /// <summary>
        /// Set connection path
        /// </summary>
        /// <param name="str"></param>
        public void SetPath(string str) => connection.ConnectionString = str;

        /// <summary>
        /// Returns current connection
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetConnection() => connection;

        /// <summary>
        /// Close current connection
        /// </summary>
        public void Close() => connection.Close();

        //// Получение экземпляра PrepareStatement
        //public PreparedStatement getPrepareStatement(String sql)
        //{
        //    PreparedStatement ps = null;
        //    try
        //    {
        //        ps = connection.prepareStatement(sql);
        //    }
        //    catch (SQLException e)
        //    {
        //        e.printStackTrace();
        //    }

        //    return ps;
        //}
    }
}
