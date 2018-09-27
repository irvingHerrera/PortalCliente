using PortalCliente.Core.Enum;

namespace PortalCliente.Core.ViewModel
{
    public class NotificacionViewModel : BaseViewModel
    {
        public string Descripcion { get; set; }
        public EstatusCliente Estatus { get; set; }
        public string NombreComercial { get; set; }
        public string Controlador { get; set; }
        public string Vista { get; set; }
    }
}