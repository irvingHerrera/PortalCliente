using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface IAprobacionRepository
    {
        int? RealizarRevalidacion(int idPrecliente, int idUsuario, int estatusCliente, string observacion);
        int? RealizarAprobacion(int idUsuario, int idPrecliente, int idEstatus);
        int? AprobadoSinProcedimientoPreAlta(int idPrecliente, int idUsuario, int idEstatus, string observacion);
        int? NoAprobado(int idPrecliente, int idUsuario, int idEstatus, string observacion);
        int? EliminaActulizaTemporal(string idUsuario, int idPrecliente);
        DataTable ObtenerInfoActCliente(int idPrecliente, int idUsuario);
        DataTable ObtenerTabuladores(int idPrecliente, int idUsuario);
        DataTable ObtenerEmpTabulador1(int idPrecliente, int idUsuario);
        DataTable ObtenerContactoInfFin(int idPrecliente, int idUsuario);
        DataTable ObtenerTarifaServicio(int idPrecliente, int idUsuario);
        DataTable ObtenerContactosEI(int idPrecliente, int idUsuario);
    }
}
