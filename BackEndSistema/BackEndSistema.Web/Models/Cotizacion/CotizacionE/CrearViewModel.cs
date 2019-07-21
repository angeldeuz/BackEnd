using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Cotizacion.CotizacionE
{
    public class CrearViewModel
    {
        public int idUsuario { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public int idCliente { get; set; }
        public int idEstatus { get; set; }
        public decimal subtotal { get; set; }
        public decimal iva { get; set; }
        public decimal total { get; set; }
        public decimal descuento { get; set; }
        public decimal aumento { get; set; }

        public List<DetalleViewModel> detalles { get; set; }
    }
}
