using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSistema.Datos;
using BackEndSistema.Entidades.Cotizacion;
using BackEndSistema.Web.Models.Cotizacion.Producto;

namespace BackEndSistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProductosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Productos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductoViewModel>> Listar()
        {
            var producto = await _context.Productos.Include(p => p.estatus).ToListAsync();

            return producto.Select(p => new ProductoViewModel
            {
                idProducto = p.idProducto,
                fechaRegistro = p.fechaRegistro,
                fechaActualizacion = p.fechaActualizacion,
                nombre = p.nombre,
                clave = p.clave,
                unidadMedida =p.unidadMedida,
                cantidad = p.cantidad,
                precio = p.precio,
                idEstatus = p.idEstatus,
                estatus = p.estatus.estatus


            });
        }

        // GET: api/Articulos/BuscarClaveProducto/CEth
        [HttpGet("[action]/{clave}")]
        public async Task<ActionResult> BuscarClaveProducto([FromRoute] string clave)
        {
            var producto = await _context.Productos.Include(p => p.estatus)
                .Where(p => p.idEstatus == 1).
                SingleOrDefaultAsync(p => p.clave == clave);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(new ProductoViewModel
            {
                idProducto = producto.idProducto,
                fechaRegistro = producto.fechaRegistro,
                fechaActualizacion = producto.fechaActualizacion,
                nombre = producto.nombre,
                clave = producto.clave,
                unidadMedida = producto.unidadMedida,
                cantidad = producto.cantidad,
                precio = producto.precio,
                idEstatus = producto.idEstatus,
                estatus = producto.estatus.estatus
            });
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.idProducto == id);
        }
    }
}
