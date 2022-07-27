using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUC_Final_Project.Data;
using PUC_Final_Project.Models;

namespace PUC_Final_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TorneiosController : ControllerBase
    {
        private readonly BrasileiraoContext _context;

        public TorneiosController(BrasileiraoContext context)
        {
            _context = context;
        }

        // GET: api/Torneios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Torneio>>> GetTorneio()
        {
          if (_context.Torneio == null)
          {
              return NotFound();
          }
            return await _context.Torneio.ToListAsync();
        }

        // GET: api/Torneios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Torneio>> GetTorneio(int id)
        {
          if (_context.Torneio == null)
          {
              return NotFound();
          }
            var torneio = await _context.Torneio.FindAsync(id);

            if (torneio == null)
            {
                return NotFound();
            }

            return torneio;
        }

        // PUT: api/Torneios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTorneio(int id, Torneio torneio)
        {
            if (id != torneio.Id)
            {
                return BadRequest();
            }

            _context.Entry(torneio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Torneios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Torneio>> PostTorneio(Torneio torneio)
        {
          if (_context.Torneio == null)
          {
              return Problem("Entity set 'BrasileiraoContext.Torneio'  is null.");
          }
            _context.Torneio.Add(torneio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTorneio", new { id = torneio.Id }, torneio);
        }

        // DELETE: api/Torneios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTorneio(int id)
        {
            if (_context.Torneio == null)
            {
                return NotFound();
            }
            var torneio = await _context.Torneio.FindAsync(id);
            if (torneio == null)
            {
                return NotFound();
            }

            _context.Torneio.Remove(torneio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TorneioExists(int id)
        {
            return (_context.Torneio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
