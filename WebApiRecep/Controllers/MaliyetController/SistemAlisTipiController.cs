#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRecep.Data;
using WebApiRecep.Entities.MaliyetEntity;

namespace WebApiRecep.Controllers.MaliyetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemAlisTipiController : ControllerBase
    {
        private readonly MaliyetDbContext _context;

        public SistemAlisTipiController(MaliyetDbContext context)
        {
            _context = context;
        }

        // GET: api/SistemAlisTipi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlisTipi>>> GetAlisTipis()
        {
            return await _context.AlisTipis.ToListAsync();
        }

        // GET: api/SistemAlisTipi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlisTipi>> GetAlisTipi(int id)
        {
            var alisTipi = await _context.AlisTipis.FindAsync(id);

            if (alisTipi == null)
            {
                return NotFound();
            }

            return alisTipi;
        }

        // PUT: api/SistemAlisTipi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlisTipi(int id, AlisTipi alisTipi)
        {
            if (id != alisTipi.Id)
            {
                return BadRequest();
            }

            _context.Entry(alisTipi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlisTipiExists(id))
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

        // POST: api/SistemAlisTipi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlisTipi>> PostAlisTipi(AlisTipi alisTipi)
        {
            _context.AlisTipis.Add(alisTipi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlisTipi", new { id = alisTipi.Id }, alisTipi);
        }

        // DELETE: api/SistemAlisTipi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlisTipi(int id)
        {
            var alisTipi = await _context.AlisTipis.FindAsync(id);
            if (alisTipi == null)
            {
                return NotFound();
            }

            _context.AlisTipis.Remove(alisTipi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlisTipiExists(int id)
        {
            return _context.AlisTipis.Any(e => e.Id == id);
        }
    }
}
