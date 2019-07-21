using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Entidades.Cotizacion
{
    public class Producto
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

        public Estatus estatus { get; set; }
    }
}
