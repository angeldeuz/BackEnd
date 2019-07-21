using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndSistema.Entidades.Usuarios
{
     public class Usuario
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idEstatus { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }

        public string Rol { get; set; }

        public Estatus estatus { get; set; }
    }
}
