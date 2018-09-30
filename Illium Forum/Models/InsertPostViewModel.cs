using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Illium_Forum.Models
{
    public class InsertPostViewModel
    {
        public string postText { get; set; }
        public string userId { get; set; }
        public int threadId { get; set; }
    }
}