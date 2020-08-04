using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        event Action<string, string> NotifySubs;

        public int NumbOfListeners { get; set; } = 1;

        static void Main(string[] args)
        {
            

        }

        public void Start(int port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));

            socket.Listen(NumbOfListeners);
            Task.Run(() => WaitRequestAsync());
        }

        private void WaitRequestAsync()
        {
            while (true)
            {
                Socket clientSocket = socket.Accept();

                byte[] buffer = new byte[256];
                var size = 0;
                var message = new StringBuilder();

                do
                {
                    size = clientSocket.Receive(buffer);
                    message.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (clientSocket.Available > 0);

                //Console.WriteLine(Encoding.UTF8.GetString(buffer));

                NotifySubs?.Invoke(message.ToString(), ((IPEndPoint)clientSocket.LocalEndPoint).Address.ToString());
                clientSocket.Send(Encoding.UTF8.GetBytes("Сервер получил сообщение: " + message));

                //Console.ReadKey();
            }
        }

        public void Stop()
        {
            socket.Close();
        }


        /// <summary>
        /// Adds an action to be called after the server responds
        /// </summary>
        /// <param name="action">Action to be performed</param>
        public void AddSubscriberMethod(Action<string, string> action) => NotifySubs += action;


        /// <summary>
        /// Removes an action from the queue of actions that are called after an event
        /// </summary>
        /// <param name="action">Action to be taken after notification</param>
        public void RemoveSubscriberMethod(Action<string, string> action) => NotifySubs -= action;

    }
}
