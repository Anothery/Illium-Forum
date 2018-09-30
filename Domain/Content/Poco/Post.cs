using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Content.Poco
{
    public class Post
    {
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public string UserId { get; set; }
    }
}