using PortalCliente.Core.Enum;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public interface IAprobacionBusiness
    {
        bool RealizarRevalidacion(int idPrecliente, int idUsuario, EstatusCliente estatusCliente, string observacion);
        bool RealizarAprobacion(int idUsuario, int idPrecliente, EstatusCliente estatusCliente);
		bool AprobadoSinProcedimientoPreAlta(int idPrecliente, int idUsuario, int idEstatus, string observacion);
		bool NoAprobado(int idPrecliente, int idUsuario, int idEstatus, string observacion);
        bool PreAltaRevalidacion(int idPrecliente, int idUsuario, int idEstatus, string observacion);
        bool EliminaActulizaTemporal(string idUsuario, int idPrecliente);
        DataTable ObtenerInfoActCliente(int idPrecliente, int idUsuario);
        DataTable ObtenerTabuladores(int idPrecliente, int idUsuario);
        DataTable ObtenerEmpTabulador1(int idPrecliente, int idUsuario);
        DataTable ObtenerContactoInfFin(int idPrecliente, int idUsuario);
        DataTable ObtenerTarifaServicio(int idPrecliente, int idUsuario);
        DataTable ObtenerContactosEI(int idPrecliente, int idUsuario);
    }
}
