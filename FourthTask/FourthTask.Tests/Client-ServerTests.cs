using Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FourthTask.Tests
{
    public class Client_Server_Tests
    {
        [Fact]
        public void SendingMessageFromClientToServer1()
        {
            Server.Server server = new Server.Server();
            server.Start(555);

            Client.Client client = new Client.Client();
            Translater subscriber = new Translater();
            client.AddSubscriberMethod(subscriber.Translate);

            client.Connect(Dns.GetHostName(), 555);
            client.SendMessage("привет, сервачок");
            
            while(subscriber.TranslateResult == null) { }
            Assert.Equal("server polychil soobshchenie: privet, servuchok", subscriber.TranslateResult);
        }

        [Fact]
        public void SendingMessageFromClientToServer2()
        {
            Server.Server server = new Server.Server();
            server.Start(111);

            Client.Client client = new Client.Client();
            Translater subscriber = new Translater();
            client.AddSubscriberMethod(subscriber.Translate);

            client.Connect(Dns.GetHostName(), 111);
            client.SendMessage("сееееервеееер, ответь");

            while (subscriber.TranslateResult == null) { }
            Assert.Equal("server polychil soobshchenie: seeeeerveeeer, otvet", subscriber.TranslateResult);
        }
    }
}
