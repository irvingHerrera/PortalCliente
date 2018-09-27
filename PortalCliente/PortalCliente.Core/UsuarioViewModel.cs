using PortalCliente.Core.Enum;
using System;

namespace PortalCliente.Core
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public TipoRol Rol { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdPrecliente { get; set; }
    }
}
