using Domain.Content.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Illium_Forum.Models
{
    public class SubjectViewModel
    {
        public Subject subject { get; set; }
        public List<Thread> threads { get; set; }       
    }
}