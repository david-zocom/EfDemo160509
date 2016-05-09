using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekDemo.Model
{
    class BibliotekContext : DbContext
    {
        public BibliotekContext() : base("Bibblan") { }

        public DbSet<Genre> Genrer { get; set; }
        public DbSet<Bok> Böcker { get; set; }
        public DbSet<Lån> Lån { get; set; }
        public DbSet<Låntagare> Låntagare { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bok>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Böcker);

            modelBuilder.Entity<Bok>()
                .HasOptional(b => b.Lån)
                .WithMany(l => l.Böcker)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Låntagare>()
                .HasMany(lt => lt.Lån)
                .WithRequired(l => l.Låntagare)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Bok>()
                .HasKey(b => b.BokId);  // inte nödvändigt

            modelBuilder.Entity<Bok>()
                .Property(b => b.Titel)
                .IsRequired()
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Genre>()
                .Property(g => g.Namn)
                .IsRequired();

            modelBuilder.Entity<Låntagare>()
                .Property(lt => lt.Namn)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
