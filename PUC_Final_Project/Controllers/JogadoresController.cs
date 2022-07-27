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
    public class JogadoresController : ControllerBase
    {
        private readonly BrasileiraoContext _context;

        public JogadoresController(BrasileiraoContext context)
        {
            _context = context;
        }

        // GET: api/Jogadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> GetJogador()
        {
          if (_context.Jogador == null)
          {
              return NotFound();
          }
            return await _context.Jogador.ToListAsync();
        }

        // GET: api/Jogadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> GetJogador(int id)
        {
          if (_context.Jogador == null)
          {
              return NotFound();
          }
            var jogador = await _context.Jogador.FindAsync(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return jogador;
        }

        // PUT: api/Jogadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogador(int id, Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return BadRequest();
            }

            _context.Entry(jogador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogadorExists(id))
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

        // POST: api/Jogadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jogador>> PostJogador(Jogador jogador)
        {
          if (_context.Jogador == null)
          {
              return Problem("Entity set 'BrasileiraoContext.Jogador'  is null.");
          }
            _context.Jogador.Add(jogador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogador", new { id = jogador.Id }, jogador);
        }

        // DELETE: api/Jogadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogador(int id)
        {
            if (_context.Jogador == null)
            {
                return NotFound();
            }
            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }

            _context.Jogador.Remove(jogador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogadorExists(int id)
        {
            return (_context.Jogador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
