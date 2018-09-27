using System;

namespace PortalCliente.Core.ViewModel
{
    public class UsuariosAudabookViewModel
    {
        public int IdUsuarioAduabook { get; set; }
        public int IdPrecliente { get; set; }
        public string Nombre { get; set; }
        public string PuestoDepartamento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Admon { get; set; }
        public string Oper { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
