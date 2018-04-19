namespace Domain.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("content.threads")]
    public partial class Thread
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thread()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        [Column(TypeName = "uint")]
        public long ThreadId { get; set; }

        [StringLength(1000)]
        public string Text { get; set; }

        [Required]
        [StringLength(255)]
        public string UserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }

        [Column(TypeName = "uint")]
        public long SubId { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        public int Votecount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
