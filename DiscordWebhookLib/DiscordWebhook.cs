using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DiscordWebhookLib.Discord;
using Newtonsoft.Json;
using System.IO;

namespace DiscordWebhookLib
{
    public class DiscordWebhook
    {
        private Uri Link;
        private HttpClient client = new HttpClient();
        public string DefaultWebhookName = default;
        public DiscordWebhook(string WebhookUrl)
        {
            Link = new Uri(WebhookUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(20);

            
        }
        public async Task<HttpStatusCode> ExecuteAsync(DiscordMessage Message)
        {
            if (DefaultWebhookName != default)
            {
                Message.username = DefaultWebhookName;
            }
            if (Message.username == default)
            {
                Message.username = "Default chatbot name";
            }
            var data = new StringContent(JsonConvert.SerializeObject(Message), Encoding.UTF8, "application/json");
            //HttpResponseMessage responseMessage = client.PostAsJsonAsync<DiscordMessage>(Link, Message).Result;
            HttpResponseMessage responseMessage = await client.PostAsync(Link, data);
            return responseMessage.StatusCode;
        }
        public async Task<HttpStatusCode> LogAsync(DiscordMessage Message)
        {
            Message.content = Message.content+"//"+ DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            return await ExecuteAsync(Message);
        }

        public HttpStatusCode Log(DiscordMessage Message)
        {
            Message.content = Message.content + "//" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            return Execute(Message);
        }

        public HttpStatusCode Execute(DiscordMessage Message)
        {
            if (DefaultWebhookName != default)
            {
                Message.username = DefaultWebhookName;
            }
            if (Message.username == default)
            {
                Message.username = "Default chatbot name";
            }

            var httpRequest = (HttpWebRequest)WebRequest.Create(Link);

            httpRequest.Method = HttpMethod.Post.ToString();
            httpRequest.PrepareHttpsRequest();

                string obj = JsonConvert.SerializeObject(Message);


                byte[] data = Encoding.UTF8.GetBytes(obj);

                httpRequest.ContentLength = data.Length;

                Stream dataStream = httpRequest.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
                dataStream.Close();
               
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            return response.StatusCode;

            }



    }
}
