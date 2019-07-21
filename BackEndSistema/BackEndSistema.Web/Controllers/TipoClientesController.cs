using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSistema.Datos;
using BackEndSistema.Entidades.Cotizacion;
using BackEndSistema.Web.Models.Cotizacion.TipoCliente;

namespace BackEndSistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoClientesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TipoClientesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/TipoClientes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoClienteViewModel>> Listar()
        {
            var tipocliente = await _context.TipoClientes.ToListAsync();

            return tipocliente.Select(t => new TipoClienteViewModel
            {

                idTipoCliente = t.idTipoCliente,
                tipoCliente = t.tipoCliente,
                aumento = t.aumento
            });
        }

        

        private bool TipoClienteExists(int id)
        {
            return _context.TipoClientes.Any(e => e.idTipoCliente == id);
        }
    }
}
