using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FourthTask.Tests
{
    public class MessageKeeperTests
    {
        [Fact]
        public void TryToSave1Message()
        {
            Server.Server server = new Server.Server();
            MessageKeeper messageKeeper = new MessageKeeper();

            server.AddSubscriberMethod(messageKeeper.Add);
            server.Start(101);

            Client.Client client = new Client.Client();
            client.Connect(Dns.GetHostName(), 101);
            client.SendMessage("привет, сервачок!");

            Thread.Sleep(500);
            Assert.True
                (messageKeeper.ClientsMessages.ElementAt(0).MessagesFromClient.ElementAt(0) == "привет, сервачок!");
        }
    }
}
