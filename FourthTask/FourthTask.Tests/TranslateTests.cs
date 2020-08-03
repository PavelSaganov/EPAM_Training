using Client;
using Client.Enumerables;
using Server;
using System;
using System.Net;
using System.Threading;
using Xunit;

namespace FourthTask.Tests
{
    public class TranslateTests
    {
        [Fact]
        //[TestCaseOrderer("Миша", Language.Russian ExpectedResult = "misha")]
        //[TestCaseOrderer("Natalia", Language.English, ExpectedResult = "наталиа")]
        //[TestCaseOrderer("Давай что-то посложнее", Language.Russian, ExpectedResult = "davai chto-to poslojnee")]
        public void Translate_Rus_To_Eng(/*string message, Language translatedLang, Language LangResult*/)
        {
            Client.Client client = new Client.Client();
            Server.Server server= new Server.Server();
            server.NumbOfListeners = 5;

            //Thread thread = new Thread(new ThreadStart(server.Start));

            Subscriber subscriber = new Subscriber();
            client.AddSubscriberMethod(subscriber.Translate);

            subscriber.Translate("Привет, черепаха!", Language.Russian, Language.English);

            client.Connect(Dns.GetHostName(), 1100);
            client.SendMessage("Привет, сервачок");


            //Thread thread = new Thread(new ThreadStart(Server.main));
            //Thread thread2 =new Thread(new ThreadStart(Client.main));
            //Server.output();
            //Client.main();
        }
    }
}
