namespace Domain.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("content.posts")]
    public partial class Post
    {
        [Key]
        [Column(TypeName = "uint")]
        public long PostId { get; set; }

        [Column(TypeName = "uint")]
        public long UserId { get; set; }

        [StringLength(255)]
        public string Text { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }

        [Column(TypeName = "uint")]
        public long ThreadId { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        public virtual Thread Thread { get; set; }
    }
}
