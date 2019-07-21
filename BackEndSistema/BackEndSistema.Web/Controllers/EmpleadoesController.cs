using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSistema.Datos;
using BackEndSistema.Entidades.Usuarios;
using BackEndSistema.Web.Models.Usuarios;
using BackEndSistema.Web.Models.Usuarios.Empleado;

namespace BackEndSistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EmpleadoesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Empleadoes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EmpleadoViewModel>> Listar()
        {
            var empleado = await _context.Empleados
                 .Include(i => i.estatus)
                .ToListAsync();

            return empleado.Select(e => new EmpleadoViewModel
            {

                idEmpleado = e.idEmpleado,
                empleado = e.empleado,
                fechaRegistro = e.fechaRegistro,
                idEstatus = e.idEstatus,
                estatus = e.estatus.estatus
            });
        }

        // GET: api/Empleadoes/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            //var empleado = await _context.Empleados.Where(c => c.idEstatus == 1).ToListAsync();
            var empleado = await _context.Empleados.ToListAsync();

            return empleado.Select(e => new SelectViewModel
            {

                idEmpleado = e.idEmpleado,
                empleado = e.empleado
            });
        }

        // GET: api/Empleadoes/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Mostrar([FromRoute] int id)
        {
            var empleado = await _context.Empleados
                .FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(new EmpleadoViewModel
            {
                idEmpleado = empleado.idEmpleado,
                empleado = empleado.empleado,
                fechaRegistro = empleado.fechaRegistro,
                idEstatus = empleado.idEstatus
            });
        }

        // PUT: api/Empleadoes/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idEmpleado <= 0)
            {
                return BadRequest();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(c => c.idEmpleado == model.idEmpleado);

            if (empleado == null)
            {
                return NotFound();
            }

            empleado.empleado = model.empleado;
            empleado.idEstatus = model.idEstatus;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Empleadoes/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fecha = DateTime.Now;
            Empleado empleado = new Empleado
            {
                empleado = model.empleado,
                fechaRegistro = fecha,
                idEstatus = model.idEstatus
            };

            _context.Empleados.Add(empleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Categorias/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Eliminar([FromRoute]int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }


            return Ok(empleado);
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.idEmpleado == id);
        }
    }
}
