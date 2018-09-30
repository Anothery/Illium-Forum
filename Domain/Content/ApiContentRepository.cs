using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Domain.Content.Poco;

namespace Domain.Content
{
    public class ApiContentRepository : IContentRepository
    {
        //private ContentContext db;
        private ApiClient client;

        public ApiContentRepository(ApiClient apiClient)
        {
            //  db = context;
            client = apiClient;
        }

        public IEnumerable<Subject> GetSubjectList()
        {

            /*
             string jsonResponse = "[    {                'Code': 'po',        'Name': 'Политика',        'SubId': 1    },    {                'Code': 'b',        'Name': 'Бред',        'SubId': 2    },    {                'Code': 'co',        'Name': 'Комиксы',        'SubId': 3    },    {                'Code': 'vg',        'Name': 'Видеоигры',        'SubId': 4    }]";
            */

            string jsonResponse = client.GetSubs();
            List<Subject> list = JsonConvert.DeserializeObject<List<Subject>>(jsonResponse);
            if (list == null) return null;
            return list.OrderBy(p => p.Name);
            //return db.Subjects.OrderBy(p => p.Name);
        }

        public IEnumerable<Thread> GetThreadList()
        {
            /*
            string jsonResponse = "[ { 'Date': '2018-09-17T01:36:38', 'Name': 'Hello World', 'SubId': 1, 'Text': 'Hello Worldsssss', 'ThreadId': 16, 'UserId': 'a9520b96-b832-482a-893d-f6f918917449', 'PostCount': 0 }, { 'Date': '2018-09-17T01:09:14', 'Name': 'ayyy', 'SubId': 1, 'Text': 'ayyyyyy', 'ThreadId': 15, 'UserId': '505', 'PostCount': 5 }, { 'Date': '2018-08-29T19:09:10', 'Name': 'Torquent', 'SubId': 1, 'Text': 'Torquent nibh, nunc egestas, elit sed sem aut a.', 'ThreadId': 14, 'UserId': '9', 'PostCount': 5 }, { 'Date': '2018-08-29T19:06:18', 'Name': 'Ut sollicitudin', 'SubId': 1, 'Text': 'Ut sollicitudin varius, phasellus ut interdum morbi wisi mattis, eros condimentum vivamus duis, nunc adipiscing bibendum.', 'ThreadId': 13, 'UserId': '8', 'PostCount': 0 }, { 'Date': '2018-08-29T19:02:00', 'Name': 'Lobortis', 'SubId': 1, 'Text': 'Lobortis lorem class, tellus euismod non, etiam elit, aut aenean magna suspendisse.', 'ThreadId': 12, 'UserId': '8', 'PostCount': 2 }, { 'Date': '2018-08-29T18:41:52', 'Name': 'Praesent', 'SubId': 1, 'Text': 'Praesent porta egestas.', 'ThreadId': 11, 'UserId': '7', 'PostCount': 1 }, { 'Date': '2018-08-29T18:37:08', 'Name': 'Facilisi eros.', 'SubId': 1, 'Text': 'Title.', 'ThreadId': 10, 'UserId': '6', 'PostCount': 15 }, { 'Date': '2018-08-29T18:36:15', 'Name': 'Ipsum lorem', 'SubId': 1, 'Text': 'Ipsum lorem sed et turpis, et bibendum pellentesque nam quam. ', 'ThreadId': 9, 'UserId': '6', 'PostCount': 0 }, { 'Date': '2018-08-29T18:34:38', 'Name': 'Sem a enim', 'SubId': 1, 'Text': 'Sem a enim praesent cursus. Risus mus, nisl sit mauris purus magnis arcu eu, ut curae.', 'ThreadId': 8, 'UserId': '5', 'PostCount': 0 }, { 'Date': '2018-08-29T18:32:52', 'Name': 'Semper', 'SubId': 1, 'Text': 'Semper lacus rutrum, laborum pede ultrices interdum proin, risus amet metus elit suscipit amet, malesuada ipsum nec tempor luctus tristique. In imperdiet libero sit pede pellentesque, maecenas erat tristique dolor molestie, donec mi.', 'ThreadId': 7, 'UserId': '4', 'PostCount': 0 }, { 'Date': '2018-08-29T18:30:30', 'Name': 'Risus', 'SubId': 1, 'Text': 'Risus ut urna maecenas, quis lectus quisque proin mauris eu feugiat. Ante ligula et euismod quis, lectus fusce vivamus, suspendisse bibendum duis elit, aptent et hymenaeos ligula egestas nostrum vitae, vel tempus.', 'ThreadId': 6, 'UserId': '3', 'PostCount': 3 }, { 'Date': '2018-08-29T17:48:03', 'Name': 'Dictumst', 'SubId': 1, 'Text': 'Dictumst vestibulum dictum in accumsan elementum hendrerit, cras orci bibendum congue tempus a ipsum, tincidunt sit, scelerisque et mi, purus nonummy id ut urna. Mus ultrices nulla eu nam tellus. Placerat in vel id ante integer at', 'ThreadId': 4, 'UserId': '3', 'PostCount': 0 }, { 'Date': '2018-08-29T17:07:56', 'Name': 'Lorem', 'SubId': 1, 'Text': ' Lorem ipsum dolor sit amet, quam purus tortor nunc amet velit, eleifend auctor urna. Consequat metus tellus nonummy auctor. Convallis eu ac, elementum at, amet mauris neque auctor augue elit.', 'ThreadId': 2, 'UserId': '2', 'PostCount': 2 }, { 'Date': '2018-08-26T21:15:40', 'Name': 'Трамп', 'SubId': 1, 'Text': 'йцукенгш', 'ThreadId': 1, 'UserId': '1', 'PostCount': 5 } ]";
            */
            string jsonResponse = client.GetLastThreadsAll();
            List<Thread> list = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse);
            return list.OrderByDescending(p => p.Date);
            //return db.Subjects.OrderBy(p => p.Name);
        }
        public IEnumerable<Thread> GetThreadList(int subId)
        {
            /*
            string jsonResponse = "[ { 'Date': '2018-09-17T01:36:38', 'Name': 'Hello World', 'SubId': 1, 'Text': 'Hello Worldsssss', 'ThreadId': 16, 'UserId': 'a9520b96-b832-482a-893d-f6f918917449', 'PostCount': 0 }, { 'Date': '2018-09-17T01:09:14', 'Name': 'ayyy', 'SubId': 1, 'Text': 'ayyyyyy', 'ThreadId': 15, 'UserId': '505', 'PostCount': 5 }, { 'Date': '2018-08-29T19:09:10', 'Name': 'Torquent', 'SubId': 1, 'Text': 'Torquent nibh, nunc egestas, elit sed sem aut a.', 'ThreadId': 14, 'UserId': '9', 'PostCount': 5 }, { 'Date': '2018-08-29T19:06:18', 'Name': 'Ut sollicitudin', 'SubId': 1, 'Text': 'Ut sollicitudin varius, phasellus ut interdum morbi wisi mattis, eros condimentum vivamus duis, nunc adipiscing bibendum.', 'ThreadId': 13, 'UserId': '8', 'PostCount': 0 }, { 'Date': '2018-08-29T19:02:00', 'Name': 'Lobortis', 'SubId': 1, 'Text': 'Lobortis lorem class, tellus euismod non, etiam elit, aut aenean magna suspendisse.', 'ThreadId': 12, 'UserId': '8', 'PostCount': 2 }, { 'Date': '2018-08-29T18:41:52', 'Name': 'Praesent', 'SubId': 1, 'Text': 'Praesent porta egestas.', 'ThreadId': 11, 'UserId': '7', 'PostCount': 1 }, { 'Date': '2018-08-29T18:37:08', 'Name': 'Facilisi eros.', 'SubId': 1, 'Text': 'Title.', 'ThreadId': 10, 'UserId': '6', 'PostCount': 15 }, { 'Date': '2018-08-29T18:36:15', 'Name': 'Ipsum lorem', 'SubId': 1, 'Text': 'Ipsum lorem sed et turpis, et bibendum pellentesque nam quam. ', 'ThreadId': 9, 'UserId': '6', 'PostCount': 0 }, { 'Date': '2018-08-29T18:34:38', 'Name': 'Sem a enim', 'SubId': 1, 'Text': 'Sem a enim praesent cursus. Risus mus, nisl sit mauris purus magnis arcu eu, ut curae.', 'ThreadId': 8, 'UserId': '5', 'PostCount': 0 }, { 'Date': '2018-08-29T18:32:52', 'Name': 'Semper', 'SubId': 1, 'Text': 'Semper lacus rutrum, laborum pede ultrices interdum proin, risus amet metus elit suscipit amet, malesuada ipsum nec tempor luctus tristique. In imperdiet libero sit pede pellentesque, maecenas erat tristique dolor molestie, donec mi.', 'ThreadId': 7, 'UserId': '4', 'PostCount': 0 }, { 'Date': '2018-08-29T18:30:30', 'Name': 'Risus', 'SubId': 1, 'Text': 'Risus ut urna maecenas, quis lectus quisque proin mauris eu feugiat. Ante ligula et euismod quis, lectus fusce vivamus, suspendisse bibendum duis elit, aptent et hymenaeos ligula egestas nostrum vitae, vel tempus.', 'ThreadId': 6, 'UserId': '3', 'PostCount': 3 }, { 'Date': '2018-08-29T17:48:03', 'Name': 'Dictumst', 'SubId': 1, 'Text': 'Dictumst vestibulum dictum in accumsan elementum hendrerit, cras orci bibendum congue tempus a ipsum, tincidunt sit, scelerisque et mi, purus nonummy id ut urna. Mus ultrices nulla eu nam tellus. Placerat in vel id ante integer at', 'ThreadId': 4, 'UserId': '3', 'PostCount': 0 }, { 'Date': '2018-08-29T17:07:56', 'Name': 'Lorem', 'SubId': 1, 'Text': ' Lorem ipsum dolor sit amet, quam purus tortor nunc amet velit, eleifend auctor urna. Consequat metus tellus nonummy auctor. Convallis eu ac, elementum at, amet mauris neque auctor augue elit.', 'ThreadId': 2, 'UserId': '2', 'PostCount': 2 }, { 'Date': '2018-08-26T21:15:40', 'Name': 'Трамп', 'SubId': 1, 'Text': 'йцукенгш', 'ThreadId': 1, 'UserId': '1', 'PostCount': 5 } ]";
            */
            int ammount = 15;
            string jsonResponse = client.GetLastThreadsFromSub(subId, ammount);
            List<Thread> list = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse);
            return list.OrderByDescending(p => p.Date);
            //return db.Subjects.OrderBy(p => p.Name);
        }

        public int InsertThread(string threadName, string threadText, int subId, string userId)
        {
            string jsonResponse = client.InsertThread(threadName, threadText, subId, userId);
            List<InsertThread> list = JsonConvert.DeserializeObject<List<InsertThread>>(jsonResponse);
            if (list == null || list[0] == null) return -1;
            return list[0].insertedId;
            //return db.Subjects.OrderBy(p => p.Name);
        }

        public void InsertPost( string postText, int threadId, string userId)
        {
            string jsonResponse = client.InsertPost(postText, userId, threadId);

        }


        public Thread GetThread(int threadId)
        {
            /*
            string jsonResponse = "[ { 'Date': '2018-09-17T01:36:38', 'Name': 'Hello World', 'SubId': 1, 'Text': 'Hello Worldsssss', 'ThreadId': 16, 'UserId': 'a9520b96-b832-482a-893d-f6f918917449', 'PostCount': 0 }, { 'Date': '2018-09-17T01:09:14', 'Name': 'ayyy', 'SubId': 1, 'Text': 'ayyyyyy', 'ThreadId': 15, 'UserId': '505', 'PostCount': 5 }, { 'Date': '2018-08-29T19:09:10', 'Name': 'Torquent', 'SubId': 1, 'Text': 'Torquent nibh, nunc egestas, elit sed sem aut a.', 'ThreadId': 14, 'UserId': '9', 'PostCount': 5 }, { 'Date': '2018-08-29T19:06:18', 'Name': 'Ut sollicitudin', 'SubId': 1, 'Text': 'Ut sollicitudin varius, phasellus ut interdum morbi wisi mattis, eros condimentum vivamus duis, nunc adipiscing bibendum.', 'ThreadId': 13, 'UserId': '8', 'PostCount': 0 }, { 'Date': '2018-08-29T19:02:00', 'Name': 'Lobortis', 'SubId': 1, 'Text': 'Lobortis lorem class, tellus euismod non, etiam elit, aut aenean magna suspendisse.', 'ThreadId': 12, 'UserId': '8', 'PostCount': 2 }, { 'Date': '2018-08-29T18:41:52', 'Name': 'Praesent', 'SubId': 1, 'Text': 'Praesent porta egestas.', 'ThreadId': 11, 'UserId': '7', 'PostCount': 1 }, { 'Date': '2018-08-29T18:37:08', 'Name': 'Facilisi eros.', 'SubId': 1, 'Text': 'Title.', 'ThreadId': 10, 'UserId': '6', 'PostCount': 15 }, { 'Date': '2018-08-29T18:36:15', 'Name': 'Ipsum lorem', 'SubId': 1, 'Text': 'Ipsum lorem sed et turpis, et bibendum pellentesque nam quam. ', 'ThreadId': 9, 'UserId': '6', 'PostCount': 0 }, { 'Date': '2018-08-29T18:34:38', 'Name': 'Sem a enim', 'SubId': 1, 'Text': 'Sem a enim praesent cursus. Risus mus, nisl sit mauris purus magnis arcu eu, ut curae.', 'ThreadId': 8, 'UserId': '5', 'PostCount': 0 }, { 'Date': '2018-08-29T18:32:52', 'Name': 'Semper', 'SubId': 1, 'Text': 'Semper lacus rutrum, laborum pede ultrices interdum proin, risus amet metus elit suscipit amet, malesuada ipsum nec tempor luctus tristique. In imperdiet libero sit pede pellentesque, maecenas erat tristique dolor molestie, donec mi.', 'ThreadId': 7, 'UserId': '4', 'PostCount': 0 }, { 'Date': '2018-08-29T18:30:30', 'Name': 'Risus', 'SubId': 1, 'Text': 'Risus ut urna maecenas, quis lectus quisque proin mauris eu feugiat. Ante ligula et euismod quis, lectus fusce vivamus, suspendisse bibendum duis elit, aptent et hymenaeos ligula egestas nostrum vitae, vel tempus.', 'ThreadId': 6, 'UserId': '3', 'PostCount': 3 }, { 'Date': '2018-08-29T17:48:03', 'Name': 'Dictumst', 'SubId': 1, 'Text': 'Dictumst vestibulum dictum in accumsan elementum hendrerit, cras orci bibendum congue tempus a ipsum, tincidunt sit, scelerisque et mi, purus nonummy id ut urna. Mus ultrices nulla eu nam tellus. Placerat in vel id ante integer at', 'ThreadId': 4, 'UserId': '3', 'PostCount': 0 }, { 'Date': '2018-08-29T17:07:56', 'Name': 'Lorem', 'SubId': 1, 'Text': ' Lorem ipsum dolor sit amet, quam purus tortor nunc amet velit, eleifend auctor urna. Consequat metus tellus nonummy auctor. Convallis eu ac, elementum at, amet mauris neque auctor augue elit.', 'ThreadId': 2, 'UserId': '2', 'PostCount': 2 }, { 'Date': '2018-08-26T21:15:40', 'Name': 'Трамп', 'SubId': 1, 'Text': 'йцукенгш', 'ThreadId': 1, 'UserId': '1', 'PostCount': 5 } ]";
            */
            string jsonResponse = client.GetThread(threadId);
            List<Thread> list = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse);
            if (list == null || list[0] == null) return null;
            return list[0];
            //return db.Subjects.OrderBy(p => p.Name);
        }

        public IEnumerable<Post> GetPosts(int threadId)
        {
            string jsonResponse = client.GetPosts(threadId);
            var list= JsonConvert.DeserializeObject<List<Post>>(jsonResponse);
            return list;
        }
    }
}
