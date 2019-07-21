using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Usuarios.Usuario
{
    public class CrearViewModel
    {
        public string usuario { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idEstatus { get; set; }
        public string password { get; set; }
        public string Rol { get; set; }
    }
}
