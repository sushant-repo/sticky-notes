using StickyNote.API.DTO;
using StickyNote.API.Models;

namespace StickyNote.API.Services
{
    public interface INoteService
    {
        Task<Note> AddNote(NoteRequest noteDto);
        Task<bool> DeleteNote(int id);
        Task<bool> EditNote(int id, NoteRequest noteDto);
        Task<IEnumerable<NoteResponse>> GetAllNotesAsync();
        Task<NoteResponse> GetNoteByIdAsync(int id);
    }
}