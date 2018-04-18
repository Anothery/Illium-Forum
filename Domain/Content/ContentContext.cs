using System.Data.Entity;

namespace Domain.Content
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ContentContext : DbContext
    {
        public ContentContext() : base("ContentConn") { }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Thread> Threads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thread>()
                .HasRequired<Subject>(s => s.CurrentSubject)
                .WithMany(g => g.Threads)
                .WillCascadeOnDelete();
        }
    }
}

