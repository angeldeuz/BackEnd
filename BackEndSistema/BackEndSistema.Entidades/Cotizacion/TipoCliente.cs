using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Entidades.Cotizacion
{
    public class TipoCliente
    {
        public int idTipoCliente { get; set; }
        public string tipoCliente { get; set; }
        public decimal aumento { get; set; }
    }
}
