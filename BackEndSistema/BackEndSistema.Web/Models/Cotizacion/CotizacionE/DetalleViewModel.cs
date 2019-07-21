using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Cotizacion.CotizacionE
{
    public class DetalleViewModel
    {
        public decimal cantidad { get; set; }
        public string unidadMedida { get; set; }
        public decimal precioUnitario { get; set; }
        public string descripcion { get; set; }
        public int  idProducto { get; set; }
    }
}
