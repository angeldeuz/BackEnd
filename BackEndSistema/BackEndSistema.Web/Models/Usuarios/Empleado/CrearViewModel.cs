using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Usuarios.Empleado
{
    public class CrearViewModel
    {
       
        public string empleado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idEstatus { get; set; }
    }
}
