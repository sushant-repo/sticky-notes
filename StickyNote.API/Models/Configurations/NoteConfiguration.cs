using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StickyNote.API.Models.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(50);
            entity.Property(x => x.Description).IsRequired().HasMaxLength(500);
            entity.HasOne(n => n.Colour)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.ColourId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
