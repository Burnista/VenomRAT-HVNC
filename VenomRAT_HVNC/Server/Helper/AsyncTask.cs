using System.Collections.Generic;

namespace VenomRAT_HVNC.Server.Helper
{
    public class AsyncTask
    {
        public AsyncTask(byte[] _msgPack, string _id, bool _admin)
        {
            this.msgPack = _msgPack;
            this.id = _id;
            this.admin = _admin;
            this.doneClient = new List<string>();
        }

        public byte[] msgPack;

        public string id;

        public bool admin;

        public List<string> doneClient;
    }
}
