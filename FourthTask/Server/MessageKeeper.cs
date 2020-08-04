using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Server
{
    public class MessageKeeper
    {
        public struct ClientsMessage
        {
            public string MessagesFromClients;
            public string ClientIp;

            public ClientsMessage(string message, string clientIP)
            {
                MessagesFromClients = message;
                ClientIp = clientIP;
            }
        }

        List<ClientsMessage> clientsMessages = new List<ClientsMessage>();

        public void Add(string message, string address) => clientsMessages.Add(new ClientsMessage(message, address));
        
    }
}
