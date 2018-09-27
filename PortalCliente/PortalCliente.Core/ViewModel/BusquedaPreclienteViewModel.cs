using PortalCliente.Core.Enum;

namespace PortalCliente.Core.ViewModel
{
    public class BusquedaPreclienteViewModel
    {
        public int IdPrecliente { get; set; }
        public int IdUsuario { get; set; }
        public string IdPreclienteVisual { get; set; }
        public EstatusCliente Estatus { get; set; }
        public string NombreComercial { get; set; }
    }
}
