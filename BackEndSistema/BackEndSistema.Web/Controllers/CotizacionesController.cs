using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSistema.Datos;
using BackEndSistema.Entidades.Cotizacion;
using BackEndSistema.Web.Models.Cotizacion.CotizacionE;

namespace BackEndSistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CotizacionesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Cotizacion/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CotizacionViewModel>> Listar()
        {
            var cotizacion = await _context.Cotizaciones
                .Include(c => c.usuarios)
                .Include(c => c.cliente)
                .Include(c => c.estatus)
                .OrderByDescending(c => c.idCotizacion)
                .Take(100)
                .ToListAsync();

            return cotizacion.Select(c => new CotizacionViewModel
            {
                idCotizacion = c.idCotizacion,
                idUsuario = c.idCotizacion,
                usuario   = c.usuarios.usuario,
                fechaActualizacion = c.fechaActualizacion,
                idCliente = c.idCliente,
                nombre = c.cliente.nombre,
                idEstatus = c.idEstatus,
                estatus = c.estatus.estatus,
                subtotal = c.subtotal,
                iva = c.iva,
                total = c.total,
                descuento = c.descuento,
                aumento= c.aumento


            });
        }

        // POST: api/Cotizaciones/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;

            CotizacionE cotizacion = new CotizacionE
            {
                idUsuario = model.idUsuario,
                fechaRegistro = fechaHora,
                fechaActualizacion = fechaHora,
                idCliente = model.idCliente,
                idEstatus = model.idEstatus,
                subtotal = model.subtotal,
                iva = model.iva,
                total = model.total,
                descuento  =  model.descuento,
                aumento  = model.aumento
            };


            try
            {
                _context.Cotizaciones.Add(cotizacion);
                await _context.SaveChangesAsync();
                var id = cotizacion.idCotizacion;
                foreach (var det in model.detalles)
                {
                    Detalles_Cotizacion detalle = new Detalles_Cotizacion
                    {
                        idCotizacion = id,
                        cantidad = det.cantidad,
                        unidadMedida = det.unidadMedida,
                        precioUnitario = det.precioUnitario,
                        descripcion  = det.descripcion,
                        idProducto = det.idProducto
                    };
                    _context.DetallesCotizacion.Add(detalle);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            return Ok();
        }

        private bool CotizacionEExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.idCotizacion == id);
        }
    }
}
