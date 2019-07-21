using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSistema.Web.Models.Usuarios.Usuario
{
    public class ActualizarViewModel
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public int idEstatus { get; set; }
        public string Rol { get; set; }

        public string password { get; set; }
        public bool act_password { get; set; }
    }
}
