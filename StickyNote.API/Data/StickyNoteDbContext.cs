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
                //entity.HasData([
                //    new Colour { Id = 1, Title = "Red", Code= "#EF9A9A", CreatedDateTime = DateTime.Now},
                //    new Colour { Id = 2, Title = "Green", Code= "#81C784", CreatedDateTime = DateTime.Now},
                //    new Colour { Id = 3, Title = "Blue", Code= "#64B5F6", CreatedDateTime = DateTime.Now},
                //    new Colour { Id = 4, Title = "Yellow", Code= "#FFEE58", CreatedDateTime = DateTime.Now},
                //    new Colour { Id = 5, Title = "Grey", Code= "#BDBDBD", CreatedDateTime = DateTime.Now},
                //    new Colour { Id = 6, Title = "Pink", Code= "#F48FB1", CreatedDateTime = DateTime.Now},
                //    ]);
            });
        }
    }
}
