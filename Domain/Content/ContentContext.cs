namespace Domain.Content
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContentContext : DbContext
    {
        public ContentContext()
            : base("name=ContentContext")
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Thread>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Thread>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Thread>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);
        }
    }
}
