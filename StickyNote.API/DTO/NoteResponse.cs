namespace StickyNote.API.DTO
{
    public class NoteResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ColourResponse? Colour { get; set; }
    }
}
