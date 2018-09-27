using PortalCliente.Data.ENT;
using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface IAltaClienteRepository
    {
        int? GuardarExpediente(int idPrecliente, string rutaExpediente, string usuarioCreacion);
        DataTable GuardarSistemasOperativos(SistemasOperativosDTO modelo);
    }
}
