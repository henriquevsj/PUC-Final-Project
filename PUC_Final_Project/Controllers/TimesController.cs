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

    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly BrasileiraoContext _context;

        public TimesController(BrasileiraoContext context)
        {
            _context = context;
        }

        // GET: api/Times
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Time>>> GetTime()
        {
          if (_context.Time == null)
          {
              return NotFound();
          }
            return await _context.Time.ToListAsync();
        }

        // GET: api/Times/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetTime(int id)
        {
          if (_context.Time == null)
          {
              return NotFound();
          }
            var time = await _context.Time.FindAsync(id);

            if (time == null)
            {
                return NotFound();
            }

            return time;
        }

        // PUT: api/Times/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTime(int id, Time time)
        {
            if (id != time.Id)
            {
                return BadRequest();
            }

            _context.Entry(time).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeExists(id))
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

        // POST: api/Times
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Time>> PostTime(Time time)
        {
          if (_context.Time == null)
          {
              return Problem("Entity set 'BrasileiraoContext.Time'  is null.");
          }
            _context.Time.Add(time);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTime", new { id = time.Id }, time);
        }

        // DELETE: api/Times/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTime(int id)
        {
            if (_context.Time == null)
            {
                return NotFound();
            }
            var time = await _context.Time.FindAsync(id);
            if (time == null)
            {
                return NotFound();
            }

            _context.Time.Remove(time);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeExists(int id)
        {
            return (_context.Time?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
