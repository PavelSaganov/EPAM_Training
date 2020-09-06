using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SixthTask.Tests
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public void OpenAndCloseConnection()
        {
            ConnectionToDB connection = new ConnectionToDB(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=University; Integrated Security=True");

            connection.Open();
            connection.Close();
        }
    }
}
