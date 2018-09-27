using PortalCliente.Core.Enum;

namespace PortalCliente.Core.ViewModel
{
    public class BaseViewModel
    {
        public int IdNotificacion { get; set; }
        public int IdPrecliente { get; set; }
        public int IdUsuario { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
        public TipoRol Rol { get; set; }
        public string Tab { get; set; }
        public bool CargarDato { get; set; }
    }
}
