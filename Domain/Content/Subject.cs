using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Content
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Thread> Threads { get; set; }
    }
}
