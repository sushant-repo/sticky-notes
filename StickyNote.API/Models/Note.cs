namespace StickyNote.API.Models
{
    public class Note : BaseIDWithAudit
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ColourId { get; set; }
    }
}
