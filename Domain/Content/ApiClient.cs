using Domain.Content.Poco;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Content
{
    public class ApiClient
    {
        private RestClient client;
        private string CONTENT_API;


        public ApiClient()
        {
            client = new RestClient("http://95.216.191.20");
            CONTENT_API = "api/v1/threads";
        }

        public string GetSubs()
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "getSubs" });
            var response = client.Execute(request);
            return response.Content;
        }

        public string GetLastThreadsAll()
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "getLastThreads" });
            var response = client.Execute(request);
            return response.Content;
        }

        public string GetLastThreadsFromSub(int subId, int ammount)
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "getLastThreadsFromSub", subId = subId, threadAmmount = ammount});
            var response = client.Execute(request);
            return response.Content;
        }

        public string InsertThread(string thread_name, string thread_text, int sub_id, string user_id)
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "addThread", threadName=thread_name, threadText = thread_text, userId = user_id, subId = sub_id });
            var response = client.Execute(request);
            return response.Content;
        }

        public string InsertPost(string post_text, string user_id, int thread_id)
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "addPost", text = post_text, userId = user_id, threadId = thread_id });
            var response = client.Execute(request);
            return response.Content;
        }


        public string GetThread(int threadId)
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "getThread", threadId = threadId });
            var response = client.Execute(request);
            return response.Content;
        }

        public string GetPosts(int threadId)
        {
            var request = new RestRequest(CONTENT_API, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { type = "getPosts", threadId = threadId });
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
