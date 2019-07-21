using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Cotizacion.TipoCliente
{
    public class TipoClienteViewModel
    {
        public int idTipoCliente { get; set; }
        public string tipoCliente { get; set; }
        public decimal aumento { get; set; }
    }
}
