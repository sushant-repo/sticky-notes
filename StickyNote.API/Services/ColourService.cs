using Microsoft.EntityFrameworkCore;
using StickyNote.API.Data;
using StickyNote.API.Models;

namespace StickyNote.API.Services
{
    public class ColourService : IColourService
    {
        private readonly StickyNoteDbContext _context;

        public ColourService(StickyNoteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Colour> GetColourByNameAsync(string name)
        {
            return await _context.Colours.AsNoTracking().FirstOrDefaultAsync(c => c.Title == name);
        }

        public async Task<IEnumerable<Colour>> GetAllColoursAsync()
        {
            return await _context.Colours.AsNoTracking().ToListAsync();
        }
    }
}
