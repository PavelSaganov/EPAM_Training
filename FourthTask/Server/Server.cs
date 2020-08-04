using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        event Action<string, string> NotifySubs;

        /// <summary>
        /// Max number of clients, that can connect to server
        /// </summary>
        public int NumbOfListeners { get; set; } = 5;

        /// <summary>
        /// Starts the server
        /// </summary>
        /// <param name="port">The port from which the server will accept connections</param>
        public void Start(int port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(NumbOfListeners);

            Thread waitRequest = new Thread(new ThreadStart(WaitRequest));
            waitRequest.Start();
        }


        /// <summary>
        /// Waiting to receive a request from a client
        /// </summary>
        private void WaitRequest()
        {
            var message = new StringBuilder();
            Socket clientSocket;

            while (true)
            {
                clientSocket = socket.Accept();
                byte[] buffer = new byte[256];
                var size = 0;

                do
                {
                    size = clientSocket.Receive(buffer);
                    message.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (clientSocket.Available > 0);

                NotifySubs?.Invoke(message.ToString(), ((IPEndPoint)clientSocket.LocalEndPoint).Address.ToString());
                clientSocket.Send(Encoding.UTF8.GetBytes("Сервер получил сообщение: " + message));
            }
        }

        /// <summary>
        /// Shuts down the socket
        /// </summary>
        public void Stop()
        {
            socket.Shutdown(SocketShutdown.Both);
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
