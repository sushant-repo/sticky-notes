using StickyNote.API.Data;
using StickyNote.API.Models;
using Microsoft.EntityFrameworkCore;
using StickyNote.API.DTO;

namespace StickyNote.API.Services
{
    internal class NoteService : INoteService
    {
        private readonly StickyNoteDbContext _context;
        private readonly IColourService _colourService;

        public NoteService(StickyNoteDbContext context, IColourService colourService)
        {
            this._context = context;
            this._colourService = colourService;
        }

        public async Task<IEnumerable<NoteResponse>> GetAllNotesAsync()
        {
            return await GetNotesWithColourReadonly();
        }

        public async Task<NoteResponse> GetNoteByIdAsync(int id)
        {
            var notes = await GetNotesWithColourReadonly();
            return notes.SingleOrDefault(x => x.Id == id);
        }

        public async Task<Note> AddNote(NoteRequest noteDto)
        {
            int? colourId = await GetColourIdByName(noteDto);
            var note = new Note
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
                ColourId = colourId,
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        private async Task<int?> GetColourIdByName(NoteRequest noteDto)
        {
            var colour = await _colourService.GetColourByNameAsync(noteDto.Colour);
            var colourId = colour?.Id;
            return colourId;
        }

        public async Task<bool> EditNote(int id, NoteRequest noteDto)
        {
            var existingNote = await _context.Notes.FindAsync(id);

            if (existingNote == null)
            {
                return false;
            }

            existingNote.Title = noteDto.Title;
            existingNote.Description = noteDto.Description;
            existingNote.ColourId = await GetColourIdByName(noteDto);
            existingNote.UpdatedDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteNote(int id)
        {
            var deletedNote = await _context.Notes.FindAsync(id);
            if (deletedNote == null)
            {
                return false;
            }

            _context.Notes.Remove(deletedNote);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<IEnumerable<NoteResponse>> GetNotesWithColourReadonly()
        {
            return await _context.Notes.Select(x => new NoteResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Colour = new ColourResponse
                {
                    Id = x.Colour.Id,
                    Title = x.Colour.Title,
                    Code = x.Colour.Code
                }
            })
                .ToListAsync();
        }
    }
}
