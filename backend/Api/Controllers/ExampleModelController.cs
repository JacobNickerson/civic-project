using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleModelController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExampleModelController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var examples = await _context.ExampleTable.ToListAsync();
            return Ok(examples);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ExampleModel example)
        {
            _context.ExampleTable.Add(example);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = example.Id }, example);
        }
    }
}
