using PortalCliente.Core.ViewModel;
using System.Collections.Generic;

namespace PortalCliente.Business.Interfaz
{
    public interface INotificacionBusiness
    {
        bool ObtenerEstatusTerminoCondicion(int idUsuario);
        bool ActualizarEstatusTerminoCondicion(int idPreCliente, bool estatusTerminoCondicion);
        List<NotificacionViewModel> ObtenerNotificacion(int idUsuario, int idRol);
        int? EnvioCorreoNotificacion(int idPrecliente);
    }
}
