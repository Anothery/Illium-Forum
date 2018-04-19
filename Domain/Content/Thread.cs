using Domain.MySQLIdentity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Content
{
    [Table("Threads")]
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }
        public int Votecount { get; set; }

        public int SubId { get; set; }
        public Subject CurrentSubject { get; set; }

        public int UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
