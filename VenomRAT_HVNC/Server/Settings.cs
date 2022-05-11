using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server
{
    public static class Settings
    {
        public static long SentValue { get; set; }

        public static long ReceivedValue { get; set; }

        public static List<string> Blocked = new List<string>();

        public static object LockBlocked = new object();

        public static object LockReceivedSendValue = new object();

        public static string CertificatePath = Application.StartupPath + "\\ServerCertificate.p12";

        public static X509Certificate2 ServerCertificate;

        public static readonly string Version = "VenomRAT_HVNC  5.0.4";

        public static object LockListviewClients = new object();

        public static object LockListviewLogs = new object();

        public static object LockListviewThumb = new object();

        public static bool ReportWindow = false;

        public static List<Clients> ReportWindowClients = new List<Clients>();

        public static object LockReportWindowClients = new object();
    }
}
