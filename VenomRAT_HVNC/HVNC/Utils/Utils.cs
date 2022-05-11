using System.Threading;

namespace VenomRAT_HVNC.HVNC.Utils
{
    public class Utils
    {
        public static void SendLogs(string logcontent)
        {
        }

        public static void xTLOG(string message)
        {
            Thread thread = new Thread(delegate ()
            {
                SendLogs(message);
            });
            thread.Start();
        }
    }
}