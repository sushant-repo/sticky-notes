using System.ComponentModel.DataAnnotations;

namespace StickyNote.API.DTO
{
    public class NoteRequest
    {
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;
        public string Colour { get; set; } = string.Empty;
    }
}
