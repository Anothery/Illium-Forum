using Domain.MySQLIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Content
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }
    
        public int ThreadId { get; set; }
        [ForeignKey("ThreadId")]
        public Thread CurrentThread { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }
    }
}
