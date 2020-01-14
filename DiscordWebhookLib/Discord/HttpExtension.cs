using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace DiscordWebhookLib.Discord
{
    public static class HttpExtensions
    {
        public static void PrepareHttpsRequest(this HttpWebRequest self)
        {

            self.PreAuthenticate = true;
            self.Date = DateTime.Now;
            self.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0";
            self.ServicePoint.Expect100Continue = false;
            self.ContentType = "application/json";
            self.CookieContainer = new CookieContainer();
            self.ProtocolVersion = HttpVersion.Version11;

            self.KeepAlive = false;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);

            self.Credentials = System.Net.CredentialCache.DefaultCredentials;
            self.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

        }
    }
}
