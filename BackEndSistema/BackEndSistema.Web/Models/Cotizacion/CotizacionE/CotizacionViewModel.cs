using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Cotizacion.CotizacionE
{
    public class CotizacionViewModel
    {
        public int idCotizacion { get; set; }
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public int idEstatus { get; set; }
        public string estatus { get; set; }
        public decimal subtotal { get; set; }
        public decimal iva { get; set; }
        public decimal total { get; set; }
        public decimal descuento { get; set; }
        public decimal aumento { get; set; }
    }
}
