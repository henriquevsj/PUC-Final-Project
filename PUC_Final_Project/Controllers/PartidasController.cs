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
    public class PartidasController : ControllerBase
    {
        private readonly BrasileiraoContext _context;

        public PartidasController(BrasileiraoContext context)
        {
            _context = context;
        }

        // GET: api/Partidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partida>>> GetPartida()
        {
          if (_context.Partida == null)
          {
              return NotFound();
          }
            return await _context.Partida.ToListAsync();
        }

        // GET: api/Partidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partida>> GetPartida(int id)
        {
          if (_context.Partida == null)
          {
              return NotFound();
          }
            var partida = await _context.Partida.FindAsync(id);

            if (partida == null)
            {
                return NotFound();
            }

            return partida;
        }

        // PUT: api/Partidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartida(int id, Partida partida)
        {
            if (id != partida.Id)
            {
                return BadRequest();
            }

            _context.Entry(partida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidaExists(id))
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

        // POST: api/Partidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Partida>> PostPartida(Partida partida)
        {
          if (_context.Partida == null)
          {
              return Problem("Entity set 'BrasileiraoContext.Partida'  is null.");
          }
            _context.Partida.Add(partida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartida", new { id = partida.Id }, partida);
        }

        // DELETE: api/Partidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            if (_context.Partida == null)
            {
                return NotFound();
            }
            var partida = await _context.Partida.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }

            _context.Partida.Remove(partida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidaExists(int id)
        {
            return (_context.Partida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
