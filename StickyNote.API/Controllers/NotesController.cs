using Microsoft.AspNetCore.Mvc;
using StickyNote.API.DTO;
using StickyNote.API.Models;
using StickyNote.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StickyNote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            this._noteService = noteService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<NoteResponse>> Get()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return Ok(notes);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteResponse>> GetById(int id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteRequest noteDto)
        {
            var createdNote = await _noteService.AddNote(noteDto);
            return CreatedAtAction(nameof(GetById), new { id = createdNote.Id }, createdNote);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] NoteRequest noteDto)
        {
            var updated = await _noteService.EditNote(id, noteDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var deleted = await _noteService.DeleteNote(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
