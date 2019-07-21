using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Usuarios
{
    public class EmpleadoViewModel
    {
        public int idEmpleado { get; set; }
        public string empleado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idEstatus { get; set; }
        public string estatus { get; set; }

    }
}
