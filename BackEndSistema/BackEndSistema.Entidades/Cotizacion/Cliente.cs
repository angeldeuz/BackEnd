using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Entidades.Cotizacion
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string RFC { get; set; }
        public string razonSocial { get; set; }
        public int idTipoCliente { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string correo { get; set; }

        public TipoCliente tipocliente { get; set; }

    }
}
