namespace StickyNote.API.Models;

public class Colour : BaseIDWithAudit
{
    public string Title { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public ICollection<Note> Notes { get; set; } = new List<Note>();
}
