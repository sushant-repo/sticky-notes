namespace StickyNote.API.Models
{
    public class BaseIDWithAudit
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
    }
}
