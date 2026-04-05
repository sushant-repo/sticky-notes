using System.ComponentModel.DataAnnotations;

namespace StickyNote.API.Models
{
    public class Note : BaseIDWithAudit
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? ColourId { get; set; }
        public Colour? Colour { get; set; }
    }
}
