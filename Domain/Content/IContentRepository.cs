using Domain.Content.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Content
{
    public interface IContentRepository
    {
        IEnumerable<Subject> GetSubjectList();
        IEnumerable<Thread> GetThreadList();
        IEnumerable<Thread> GetThreadList(int SubId);
        int InsertThread(string threadName, string threadText, int subId, string userId);

        Thread GetThread(int threadId);
        IEnumerable<Post> GetPosts(int threadId);
        void InsertPost(string postText, int threadId, string userId);
    }
}
