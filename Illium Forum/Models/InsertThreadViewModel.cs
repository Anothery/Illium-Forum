using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Illium_Forum.Models
{
    public class InsertThreadViewModel
    {

        public string threadText { get; set; }

        public string threadName { get; set; }
        public int subId { get; set; }
        public string userId { get; set; }
    }
}