using PortalCliente.Core.Enum;

namespace PortalCliente.Core.ViewModel
{
    public class DatosUsuarioViewModel
    {
        public string IdUsuario { get; set; }
        public TipoRol Rol { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Fecha { get; set; }
        public string IdPrecliente { get; set; }
    }
}
