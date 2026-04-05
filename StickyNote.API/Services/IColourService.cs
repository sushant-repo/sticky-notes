using StickyNote.API.Data;
using StickyNote.API.Models;

namespace StickyNote.API.Services
{
    public interface IColourService
    {
        Task<IEnumerable<Colour>> GetAllColoursAsync();
        Task<Colour> GetColourByNameAsync(string name);
    }
}