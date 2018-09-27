using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface IImpresionRepository
    {
        DataTable ObtenerExpedienteCliente(int idPrecliente);
    }
}
