using PortalCliente.Data.ENT;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface IClienteRepository
    {
        DataTable ObtenerDatoCliente(int idUsuario);
        DataTable ObtenerDatosTituloSecciones(int idprecliente);
        DataTable ObtenerListaPreCliente(string banderilla);
        DataTable ObtenerDirecionCliente(int idPrecliente);
        DataTable ObtenerRelacionPreclienteAprobador(int idPrecliente);
        DataTable ObtenerListaSoloPreclientes();
        DataTable ObtenerListaSoloClientes();
        DataTable ObtenerListaPreClienteActivo();
        DataTable ObtenerListaCliente(int GrupoEstatus);
        DataTable ObtenerListaClienteAprobacion(int GrupoEstatus, int Rol, int id_usuario);
        int? ActualizarEstatus(int idusuario, int nuevoestatus);
        DataTable ObtenerRelacionPreclienteAprobador(int idPrecliente, int idEstatus);
        DataTable ObtieneTabsPrecliente(int idPrecliente);
        List<ContactoDTO> ObtieneContactosPorPrecliente(string idprecliete);
    }
}
