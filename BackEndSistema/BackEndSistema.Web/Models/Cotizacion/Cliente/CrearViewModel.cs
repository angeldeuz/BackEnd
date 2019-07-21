using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Cotizacion.Cliente
{
    public class CrearViewModel
    {
        public string nombre { get; set; }
        public string RFC { get; set; }
        public string razonSocial { get; set; }
        public int idTipoCliente { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string correo { get; set; }
    }
}
