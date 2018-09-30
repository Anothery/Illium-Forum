using Domain.Content.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Illium_Forum.Models
{
    public class InsideThreadViewModel
    {
        public ThreadViewModel thread { get; set; }
        public List<Post> posts { get; set; }
    }
}