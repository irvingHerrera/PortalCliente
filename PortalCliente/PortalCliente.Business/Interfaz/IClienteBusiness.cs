using PortalCliente.Core.ViewModel;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public interface IClienteBusiness
    {
        List<BusquedaPreclienteViewModel> ObtenerListaPrecliente(string banderilla);
        List<BusquedaPreclienteViewModel> ObtenerListaPreclienteActivo();
        List<BusquedaPreclienteViewModel> ObtenerListaCliente(int GrupoEstatus);
        List<BusquedaPreclienteViewModel> ObtenerListaClienteAprobacion(int GrupoEstatus, int Rol, int id_usuario);
        List<BusquedaPreclienteViewModel> ObtenerListaSoloClientes();
        List<BusquedaPreclienteViewModel> ObtenerListaSoloPreclientes();
        ClienteViewModel ObtenerDirecionCliente(int idPreliente);
        int? ActualizarEstatus(int idUsuario, int nuevoestatus);
        DataTable ObtenerUsrsCambioEstatus(int idPrecliente, int idEstatus);
    }
}
