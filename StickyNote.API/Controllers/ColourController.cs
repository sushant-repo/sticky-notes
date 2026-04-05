using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StickyNote.API.Services;

namespace StickyNote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IColourService colourService;

        public ColourController(IColourService colourService)
        {
            this.colourService = colourService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetColourByName(string name)
        {
            var colour = await colourService.GetColourByNameAsync(name);
            if (colour == null)
            {
                return NotFound();
            }

            return Ok(colour);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColours()
        {
            var colours = await colourService.GetAllColoursAsync();
            return Ok(colours);
        }
    }
}
