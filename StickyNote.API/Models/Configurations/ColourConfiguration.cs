using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StickyNote.API.Models.Configurations
{
    public class ColourConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(10);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(7);
            entity.HasMany(c => c.Notes)
                .WithOne(n => n.Colour)
                .HasForeignKey(n => n.ColourId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
