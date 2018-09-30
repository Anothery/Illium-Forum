using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Content.Poco
{
    public class Thread
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int SubId { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public string UserId { get; set; }
        public int? PostCount { get; set; }
    }
}