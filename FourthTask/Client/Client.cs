using Client.Enumerables;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        event Action<string, Language, Language> NotifySubs;

        public Language LanguageOfMessage { get; set; } = Language.Russian;
        public Language LanguageNeedToGet { get; set; } = Language.English;

        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            
        }

        /// <summary>
        /// Established a connection to a remote host. The host is specified by a host name and a port number.
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="port"></param>
        public void Connect(string hostName, int port) => socket.Connect(hostName, port);

        /// <summary>
        /// Established a connection to a remote host. The host is specified by a ip address and a port number.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void Connect(IPAddress address, int port) => socket.Connect(address, port);

        async public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            socket.Send(data);
            await Task.Run(() => WaitAnswerAsync());
        }

        private void WaitAnswerAsync()
        {
            StringBuilder answer = new StringBuilder();

            byte[] buffer = new byte[256];
            int bytesRec = 0;

            do
            {
                bytesRec = socket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, bytesRec));
            }
            while (socket.Available > 0);

            NotifySubs?.Invoke(answer.ToString(), LanguageOfMessage, LanguageNeedToGet);
        }

        /// <summary>
        /// Closes the connection to the server
        /// </summary>
        public void CloseConnection()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        /// <summary>
        /// Adds an action to be called after the server responds
        /// </summary>
        /// <param name="action">Action to be performed</param>
        public void AddSubscriberMethod(Action<string, Language, Language> action) => NotifySubs += action;


        /// <summary>
        /// Removes an action from the queue of actions that are called after an event
        /// </summary>
        /// <param name="action">Action to be taken after notification</param>
        public void RemoveSubscriberMethod(Action<string, Language, Language> action) => NotifySubs -= action;

    }
}
