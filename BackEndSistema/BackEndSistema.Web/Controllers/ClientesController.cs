using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSistema.Datos;
using BackEndSistema.Entidades.Cotizacion;
using BackEndSistema.Web.Models.Cotizacion.Cliente;

namespace BackEndSistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ClientesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Clientes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteViewModel>> Listar()
        {
            var cliente = await _context.Clientes.Include(c => c.tipocliente).ToListAsync();

            return cliente.Select(c => new ClienteViewModel
            {
                idCliente = c.idCliente,
                nombre = c.nombre,
                RFC = c.RFC,
                razonSocial = c.razonSocial,
                idTipoCliente = c.idTipoCliente,
                tipoCliente = c.tipocliente.tipoCliente,
                fechaRegistro = c.fechaRegistro,
                correo = c.correo
            });
        }

        // GET: api/Clientes/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Mostrar([FromRoute] int id)
        {
            var cliente = await _context.Clientes.Include(c => c.tipocliente).
                SingleOrDefaultAsync(c => c.idCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(new ClienteViewModel
            {
                idCliente = cliente.idCliente,
                nombre = cliente.nombre,
                tipoCliente = cliente.tipocliente.tipoCliente,
                RFC = cliente.RFC,
                razonSocial = cliente.razonSocial,
                idTipoCliente = cliente.idTipoCliente,
                fechaRegistro = cliente.fechaRegistro,
                correo = cliente.correo
            });
        }

        // PUT: api/Clientes/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idCliente <= 0)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.idCliente == model.idCliente);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.nombre = model.nombre;
            cliente.RFC = model.RFC;
            cliente.razonSocial = model.razonSocial;
            cliente.idTipoCliente = model.idTipoCliente;
            //cliente.fechaRegistro = model.fechaRegistro;
            cliente.correo = model.correo;


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

        // POST: api/Clientes/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Cliente cliente = new Cliente
            {
                nombre = model.nombre,
                RFC = model.RFC,
                razonSocial = model.razonSocial,
                idTipoCliente = model.idTipoCliente,
                fechaRegistro = fechaHora,
                correo = model.correo

        };

            _context.Clientes.Add(cliente);
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
        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.idCliente == id);
        }
    }
}
