using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Illium_Forum.Models
{
    public class ThreadViewModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int SubId { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public string UserId { get; set; }
        public int? PostCount { get; set; }
        public string Username { get; set; }

    }
}