using PortalCliente.Core.Enum;
using System;

namespace PortalCliente.Core.ViewModel
{
    public class PreclientePendienteViewModel
    {
        public int IdUsuario { get; set; }
        public int IdPrecliente { get; set; }
        public string IdPreclienteVisual { get; set; }
        public string NombreCliente { get; set; }
        public EstatusCliente Estatus { get; set; }
        public string DescripcionEstatus { get; set; }
        public DateTime InicioTramite { get; set; }
        public string UsuarioTramite { get; set; }
        public string Asignatario { get; set; }
    }
}
