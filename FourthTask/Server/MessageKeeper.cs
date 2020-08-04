using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Server
{
    public class MessageKeeper
    {
        /// <summary>
        /// A structure that stores the address of the client and the messages that he sent
        /// </summary>
        public struct ClientsMessage
        {
            public List<string> MessagesFromClient;
            public string ClientIp;

            public ClientsMessage(string message, string clientIP)
            {
                MessagesFromClient = new List<string>()
                    { message };
                ClientIp = clientIP;
            }
        }

        /// <summary>
        /// List of structures that store information about messages
        /// </summary>
        public List<ClientsMessage> ClientsMessages { get; private set; } = new List<ClientsMessage>();

        /// <summary>
        /// Adds a message to the client
        /// </summary>
        /// <param name="message">Message sent by client</param>
        /// <param name="address">Client address from which the message was sent</param>
        public void Add(string message, string address)
        {
                if (ClientsMessages.Where(cm => cm.ClientIp == address).Count() == 0)
                    ClientsMessages.Add(new ClientsMessage(message, address));
                else
                    ClientsMessages.First().MessagesFromClient.Add(message);   
        }

    }
}
