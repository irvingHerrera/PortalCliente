using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface INotificacionRepository
    {
        DataTable ObtenerEstatusTerminoCondicion(int idUsuario);
        int? ActualizarEstatusTerminoCondicion(int idPreCliente, bool estatusTerminoCondicion);
        DataTable ObtenerNotificacion(int idUsuario, int idRol);
        int? EnvioCorreoNotificacion(int idPrecliente);
    }
}
