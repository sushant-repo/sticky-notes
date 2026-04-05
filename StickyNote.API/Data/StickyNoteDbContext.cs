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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StickyNoteDbContext).Assembly);
        }
    }
}
