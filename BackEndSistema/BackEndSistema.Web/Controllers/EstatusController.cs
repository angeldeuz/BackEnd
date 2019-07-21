using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSistema.Datos;
using BackEndSistema.Entidades;

namespace BackEndSistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EstatusController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Estatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estatus>>> GetEstatus()
        {
            return await _context.Estatus.ToListAsync();
        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estatus>> GetEstatus(int id)
        {
            var estatus = await _context.Estatus.FindAsync(id);

            if (estatus == null)
            {
                return NotFound();
            }

            return estatus;
        }

        // PUT: api/Estatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstatus(int id, Estatus estatus)
        {
            if (id != estatus.idEstatus)
            {
                return BadRequest();
            }

            _context.Entry(estatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstatusExists(id))
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

        // POST: api/Estatus
        [HttpPost]
        public async Task<ActionResult<Estatus>> PostEstatus(Estatus estatus)
        {
            _context.Estatus.Add(estatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstatus", new { id = estatus.idEstatus }, estatus);
        }

        // DELETE: api/Estatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estatus>> DeleteEstatus(int id)
        {
            var estatus = await _context.Estatus.FindAsync(id);
            if (estatus == null)
            {
                return NotFound();
            }

            _context.Estatus.Remove(estatus);
            await _context.SaveChangesAsync();

            return estatus;
        }

        private bool EstatusExists(int id)
        {
            return _context.Estatus.Any(e => e.idEstatus == id);
        }
    }
}
