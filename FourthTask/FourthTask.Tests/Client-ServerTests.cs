using Client;
using System;
using System.Net;
using System.Threading;
using Xunit;

namespace FourthTask.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void SendingMessageFromClientToServer()
        {
            Client.Client client = new Client.Client();
            Subscriber subscriber = new Subscriber();
            // client.AddSubscriberMethod(subscriber.Translate);

            client.Connect(Dns.GetHostName(), 1100);
            client.SendMessage("Привет, сервачок");
            

            //Thread thread =new Thread(new ThreadStart(Server.main));
            //Thread thread2 =new Thread(new ThreadStart(Client.main));
            //Server.output();
            //Client.main();
        }
    }
}
