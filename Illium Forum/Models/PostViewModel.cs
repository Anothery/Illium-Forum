using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Illium_Forum.Models
{
    public class PostViewModel
    {
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}