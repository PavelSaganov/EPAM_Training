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
            Server.Server server = new Server.Server();
            server.Start(555);

            Client.Client client = new Client.Client();
            Translater subscriber = new Translater();
            client.AddSubscriberMethod(subscriber.Translate);

            client.Connect(Dns.GetHostName(), 555);
            client.SendMessage("привет, сервачок");
            

            //Thread thread =new Thread(new ThreadStart(Server.main));
            //Thread thread2 =new Thread(new ThreadStart(Client.main));
            //Server.output();
            //Client.main();
            while(subscriber.TranslateResult == null)
            {

            }
            string result = subscriber.TranslateResult;
        }
    }
}
