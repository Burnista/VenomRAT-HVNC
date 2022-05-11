using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace VenomRAT_HVNC.Server.Helper
{
    internal class DingDing
    {
        public static void Send(string WebHook, string secret, string content)
        {
            string str1 = "";
            TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.ToUniversalTime();
            long num = (dateTime.Ticks - 621355968000000000L) / 10000L;
            string s1 = num.ToString() + "\n" + secret;
            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            byte[] bytes1 = asciiEncoding.GetBytes(secret);
            byte[] bytes2 = asciiEncoding.GetBytes(s1);
            string str2;
            using (HMACSHA256 hmacshA256 = new HMACSHA256(bytes1))
                str2 = HttpUtility.UrlEncode(Convert.ToBase64String(hmacshA256.ComputeHash(bytes2)), Encoding.UTF8);
            string requestUriString = WebHook + "&timestamp=" + num.ToString() + "&sign=" + str2;
            var data = new
            {
                msgtype = "text",
                text = new { content = content }
            };
            string s2 = JsonConvert.SerializeObject((object)data);
            Console.WriteLine(requestUriString);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json;charset=utf-8";
            byte[] bytes3 = Encoding.UTF8.GetBytes(s2);
            httpWebRequest.ContentLength = (long)bytes3.Length;
            using (Stream requestStream = httpWebRequest.GetRequestStream())
                requestStream.Write(bytes3, 0, bytes3.Length);
            using (StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream(), Encoding.UTF8))
                str1 = streamReader.ReadToEnd();
        }
    }
}