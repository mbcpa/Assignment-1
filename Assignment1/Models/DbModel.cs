namespace Assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel1")
        {
        }

        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Band>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Band>()
                .Property(e => e.MemberCount)
                .IsUnicode(false);

            modelBuilder.Entity<Song>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Song>()
                .Property(e => e.Length)
                .IsUnicode(false);

            modelBuilder.Entity<Song>()
                .Property(e => e.Band)
                .IsUnicode(false);

            modelBuilder.Entity<Song>()
                .HasOptional(e => e.Band1)
                .WithRequired(e => e.Song);
        }
    }
}
