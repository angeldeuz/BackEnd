using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Entidades.Usuarios
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string empleado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idEstatus { get; set; }

        public Estatus estatus {get; set; }
    }
}
