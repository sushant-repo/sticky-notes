using Microsoft.EntityFrameworkCore;
using StickyNote.API.Models;

namespace StickyNote.API.Data
{
    public class StickyNoteDbContext : DbContext
    {
        public StickyNoteDbContext(DbContextOptions<StickyNoteDbContext> options): base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Colour> Colours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.HasOne<Colour>()
                    .WithMany()
                    .HasForeignKey(e => e.ColourId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Colour>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Code).IsRequired();
            });
        }
    }
}
