using Newtonsoft.Json;
using System.IO;
using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;

namespace WindowsFormsClient
{
    internal class MessengerClientAPI
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public void TestNewtonsoftJson()
        {
            Message message = new Message("Eixini", "Hello!", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(message);
            Console.WriteLine(output);
            Message deserializedMessage = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMessage);
        }

        public Message GetMessageRestSharp(int MessageId)
        {
            string ServiceUrl = "http://localhost:5272";
            var client = new RestClient(ServiceUrl);
            var request = new RestRequest("/api/Messenger/" + MessageId.ToString(), Method.Get);
            RestResponse<Message> Response = client.Execute<Message>(request);
            string ResponseContent = Response.Content;
            Message deserializedMessage = JsonConvert.DeserializeObject<Message>(ResponseContent);
            return deserializedMessage;
        }

        public async Task<Message> GetMessageHTTPAsync(int MessageId)
        {
            var responseString = await httpClient.GetStringAsync($"http://localhost:5272/api/Messenger/{MessageId.ToString()}");
            if(responseString != null)
            {
                Message deserializedMessage = JsonConvert.DeserializeObject<Message>(responseString);
                return deserializedMessage;
            }
            return null;
        }

        public Message GetMessage(int MessageId)
        {
            WebRequest request = WebRequest.Create($"http://localhost:5272/api/Messenger/{MessageId.ToString()}");
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            if ((status.ToLower() == "ok") && (responseFromServer != "Not found"))
            {
                Message deserializedMessage = JsonConvert.DeserializeObject<Message>(responseFromServer);
                //Console.WriteLine(deserializedMessage);
                return deserializedMessage;
            }
            return null;
        }

        public bool SendMessage(Message message)
        {
            WebRequest request = WebRequest.Create("http://localhost:5272/api/Messenger");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(message);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse() as WebResponse;
            dataStream = response.GetResponseStream() as Stream;

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return true;
        }
    }
}
