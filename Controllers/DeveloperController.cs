using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSqlite.Data;
using WebApiSqlite.Models;

namespace WebApiSqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly WebApiSqliteContext _context;

        public DeveloperController(WebApiSqliteContext context)
        {
            _context = context;
        }

        // GET: api/Developer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        {
          if (_context.Developers == null)
          {
              return NotFound();
          }
            return await _context.Developers.ToListAsync();
        }

        // GET: api/Developer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
          if (_context.Developers == null)
          {
              return NotFound();
          }
            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return developer;
        }

        [HttpGet("GenearteEcoById/{id}")]
        public async Task<ActionResult<Developer>> GenearteEcoById(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            if(developer.ECOYear == 0 & developer.ECOCount == 0)
            {
                var values = await GenerateEcoByIdAsync(id);
                developer.ECOYear = values.Year;
                developer.ECOCount = values.Count;
                await _context.SaveChangesAsync();
            }

            return developer;
        }

        private async Task<YearCount> GenerateEcoByIdAsync(int id)
        {
            if (!await _context.Developers.AnyAsync(d => d.ECOYear == DateTime.Now.Year))
            {
                return new YearCount() { Count = 1, Year = DateTime.Now.Year };
            }

            int max = await _context.Developers.Where(d => d.ECOYear == DateTime.Now.Year).MaxAsync(d => d.ECOCount) + 1;
            return new YearCount() { Count = max, Year = DateTime.Now.Year };
        }

        // POST: api/Developer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(Developer developer)
        {
          if (_context.Developers == null)
          {
              return Problem("Entity set 'WebApiSqliteContext.Developers'  is null.");
          }

            YearCount dev = await IncrementDeveloperIdAsync();

            developer.Year = dev.Year;
            developer.Count = dev.Count;
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeveloper", new { id = developer.DeveloperId }, developer);
        }

        private async Task<YearCount> IncrementDeveloperIdAsync()
        {
            if (!await _context.Developers.AnyAsync(d => d.Year == DateTime.Now.Year))
            {
               return new YearCount() { Count = 1, Year = DateTime.Now.Year };
            }

            int max = await _context.Developers.Where(d => d.Year == DateTime.Now.Year).MaxAsync(d => d.Count) + 1;
            return new YearCount() { Count = max, Year = DateTime.Now.Year };
        }

        // DELETE: api/Developer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            if (_context.Developers == null)
            {
                return NotFound();
            }
            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeveloperExists(int id)
        {
            return (_context.Developers?.Any(e => e.DeveloperId == id)).GetValueOrDefault();
        }


        // PUT: api/Developer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDeveloper(int id, Developer developer)
        //{
        //    if (id != developer.DeveloperId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(developer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeveloperExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
    }
}
