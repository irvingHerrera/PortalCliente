using PortalCliente.Business.Interfaz;
using PortalCliente.Core;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business
{
    public class NotificacionBusiness : INotificacionBusiness
    {
        private readonly INotificacionRepository notificacion;

        public NotificacionBusiness()
        {
            notificacion = new NotificacionRepository();
        }

        #region Metodos Privados

        private List<NotificacionViewModel> ObtenerListaNotificacion(DataTable tabla, TipoRol rol)
        {
            var lista = new List<NotificacionViewModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new NotificacionViewModel
                {
                    IdPrecliente = Convert.ToInt32(fila["id_precliente"].ToString()),
                    Rol = rol,
                    NombreComercial = fila["nombre_comercial"].ToString().Trim(),
                    IdNotificacion = Convert.ToInt32(fila["id_notificacion_usuario"].ToString()),
                    Estatus = (EstatusCliente)Enum.Parse(typeof(EstatusCliente), fila["estatus"].ToString()),
                    Descripcion = fila["Notificacion"].ToString()
                });
            }

            return lista;
        }

        #endregion

        public bool ActualizarEstatusTerminoCondicion(int idPreCliente, bool estatusTerminoCondicion)
        {
            var resultado = notificacion.ActualizarEstatusTerminoCondicion(idPreCliente, estatusTerminoCondicion);
            if (resultado != null)
                return resultado.Value > 0 ? true : false;
            else
                return false;
        }

        public bool ObtenerEstatusTerminoCondicion(int idUsuario)
        {
            var table = notificacion.ObtenerEstatusTerminoCondicion(idUsuario);
            var resultado = (bool)table.Rows[0][0];
            return resultado;
        }

        public List<NotificacionViewModel> ObtenerNotificacion(int idUsuario, int idRol)
        {
            ClienteHelper clienteHelper = new ClienteHelper();
            var listaNotificacion = new List<NotificacionViewModel>();
            var table = notificacion.ObtenerNotificacion(idUsuario, idRol);
            listaNotificacion = ObtenerListaNotificacion(table, (TipoRol)Enum.Parse(typeof(TipoRol), idRol.ToString()));

            foreach (var item in listaNotificacion)
            {
                var complemento = clienteHelper.ObtenerVistaControladorByRolEstatus(item.Rol, item.Estatus);
                if (complemento != null)
                {
                    item.Vista = complemento.Vista;
                    item.Controlador = complemento.Controlador;
                    item.Tab = complemento.Tab;
                }

            }

            return listaNotificacion;
        }

        public int? EnvioCorreoNotificacion(int idPrecliente)
        {
            var resultado = notificacion.EnvioCorreoNotificacion(idPrecliente);
            return resultado;
        }
    }
}
