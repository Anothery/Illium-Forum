using Domain.MySQLIdentity;

namespace Illium_Forum.Models
{
    public class ThreadViewModel
    {
        public long ThreadId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }
        public int Votecount { get; set; }
        public string Postcount { get; set; }
        public string UserName { get; set; }
    }
}
