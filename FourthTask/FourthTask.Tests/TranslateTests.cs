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

            MessageKeeper subscriber = new MessageKeeper();
            client.AddSubscriberMethod(subscriber.Translate);
            
            client.Connect(Dns.GetHostName(), 1100);
            client.SendMessage("Привет, сервачок");


            subscriber.Translate("Привет, черепаха!", Language.Russian, Language.English);


            //Thread thread = new Thread(new ThreadStart(Server.main));
            //Thread thread2 =new Thread(new ThreadStart(Client.main));
            //Server.output();
            //Client.main();
        }
    }
}
