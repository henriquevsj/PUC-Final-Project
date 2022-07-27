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
    public class TransferenciasController : ControllerBase
    {
        private readonly BrasileiraoContext _context;

        public TransferenciasController(BrasileiraoContext context)
        {
            _context = context;
        }

        // GET: api/Transferencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transferencia>>> GetTransferencia()
        {
          if (_context.Transferencia == null)
          {
              return NotFound();
          }
            return await _context.Transferencia.ToListAsync();
        }

        // GET: api/Transferencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transferencia>> GetTransferencia(int id)
        {
          if (_context.Transferencia == null)
          {
              return NotFound();
          }
            var transferencia = await _context.Transferencia.FindAsync(id);

            if (transferencia == null)
            {
                return NotFound();
            }

            return transferencia;
        }

        // PUT: api/Transferencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransferencia(int id, Transferencia transferencia)
        {
            if (id != transferencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(transferencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferenciaExists(id))
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

        // POST: api/Transferencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transferencia>> PostTransferencia(Transferencia transferencia)
        {
          if (_context.Transferencia == null)
          {
              return Problem("Entity set 'BrasileiraoContext.Transferencia'  is null.");
          }
            _context.Transferencia.Add(transferencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransferencia", new { id = transferencia.Id }, transferencia);
        }

        // DELETE: api/Transferencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransferencia(int id)
        {
            if (_context.Transferencia == null)
            {
                return NotFound();
            }
            var transferencia = await _context.Transferencia.FindAsync(id);
            if (transferencia == null)
            {
                return NotFound();
            }

            _context.Transferencia.Remove(transferencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransferenciaExists(int id)
        {
            return (_context.Transferencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
