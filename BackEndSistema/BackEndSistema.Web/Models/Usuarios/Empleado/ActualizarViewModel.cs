using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Usuarios.Empleado
{
    public class ActualizarViewModel
    {
        public int idEmpleado { get; set; }
        public string empleado { get; set; }
        public int idEstatus { get; set; }
    }
}
