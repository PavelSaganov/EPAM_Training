using Server;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace FourthTask.Tests
{
    public class MessageKeeperTests
    {
        [Fact]
        public void Test()
        {
            Server.Server server = new Server.Server();
            server.Start(555);

            Client.Client client = new Client.Client();
            MessageKeeper messageKeeper = new MessageKeeper();
            server.AddSubscriberMethod(messageKeeper.Add);

            client.Connect(Dns.GetHostName(), 555);
            client.SendMessage("привет, сервачок");
        }
    }
}
