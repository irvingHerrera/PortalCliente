using PortalCliente.Data.ENT;
using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface IConsultaRepository
    {
        DataTable ObtenerListaPreclientesPendientes();
        DataTable ObtenerInfoTabuladoresTEMP(int id_precliente);
        DataTable ObtenerAprobacionDePreAltaCliente(int id_precliente);
        DataTable ObtenerAprobacionDeAltaCliente(int id_precliente);
        
    }
}
