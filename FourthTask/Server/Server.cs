using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Server
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public int NumbOfListeners { get; set; } = 1;

        static void Main(string[] args)
        {


        }

        public void Start(int port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));

            socket.Listen(NumbOfListeners);

            while (true)
            {
                Socket clientSocket = socket.Accept();

                byte[] buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = clientSocket.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (clientSocket.Available > 0);

                Console.WriteLine(Encoding.UTF8.GetString(buffer));

                clientSocket.Send(Encoding.UTF8.GetBytes("Сервер получил сообщение, все норм"));

                Console.ReadKey();
            }
        }

        //public void AddObserver(IObserver o)
        //{
        //    observers.Add(o);
        //}

        //public void NotifyObservers()
        //{
        //    foreach (IObserver observer in observers)
        //        observer.Update();
        //}

        //public void RemoveObserver(IObserver o)
        //{
        //    observers.Remove(o);
        //}
    }
}
