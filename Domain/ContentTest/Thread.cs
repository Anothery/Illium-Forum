using Domain.MySQLIdentity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Content
{
    [Table("Threads")]
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }
        public int Votecount { get; set; }

        [Required]
        public int SubId { get; set; }
        [ForeignKey("SubId")]
        public Subject CurrentSubject { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }

        public ICollection<Post> Posts { get; set; }
        public Thread()
        {
            Posts = new List<Post>();
        }
    }
}
