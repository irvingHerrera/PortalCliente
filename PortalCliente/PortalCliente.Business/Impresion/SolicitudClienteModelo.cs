using System.Data;

namespace PortalCliente.Business.Impresion
{
    internal class SolicitudClienteModelo
    {
        public DataTable InformacionCliente { get; set; }
        public DataTable InformacionContacto { get; set; }
        public DataTable InformacionCuenta { get; set; }
    }
}
