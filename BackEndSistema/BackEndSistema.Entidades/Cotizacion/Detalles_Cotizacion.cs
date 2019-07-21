using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Entidades.Cotizacion
{
    public class Detalles_Cotizacion
    {
        public int idDetalle { get; set; }
        public int idCotizacion { get; set; }
        public decimal cantidad { get; set; }
        public string unidadMedida { get; set; }
        public decimal precioUnitario { get; set; }
        public string descripcion { get; set; }
        public int idProducto { get; set; }

        public CotizacionE cotizacione { get; set; }
        public Producto producto { get; set; }
    }
}
