using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Cotizacion.Producto
{
    public class ProductoViewModel
    {
        public int idProducto { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public string unidadMedida { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public int idEstatus { get; set; }
        public string estatus { get; set; }
    }
}
