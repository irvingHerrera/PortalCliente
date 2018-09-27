using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using System.Collections.Generic;

namespace PortalCliente.Core
{
    public class ClienteHelper
    {

        #region Metodos Privados

        private List<NotificacionViewModel> ListaAnalisis()
        {
            var lista = new List<NotificacionViewModel>
            {
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.EnRegistro,
                    Rol = TipoRol.Cliente,
                    Controlador = "RegistroCliente",
                    Vista = "Index"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.EnCaptura,
                    Rol = TipoRol.EjecutivoVenta,
                    Controlador = "CapturaCliente",
                    Vista = "Index",
                    Tab = "RegistroCliente"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.EnCaptura,
                    Rol = TipoRol.EjecutivoVenta,
                    Controlador = "CapturaCliente",
                    Vista = "Index",
                    Tab = "Tabulador"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.AprobadoSinProcedimientoPreAlta,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "CapturaCliente",
                    Vista = "Index",
                    Tab = "ProcedimientoOperacion"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.AprobadoSinProcedimientoPreAlta,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "AltaCliente",
                    Vista = "Index",
                    Tab = "ProcedimientoOperacion"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.AprobadoPreAlta,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "AltaCliente",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobacionPreAlta,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = "Prealta"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.Cliente,
                    Rol = TipoRol.AltaCliente,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobacionProcedimientoPrealta,
                    Rol = TipoRol.Lider,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = "ProcedimientoOperacion"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobacionProcedimientoPrealta,
                    Rol = TipoRol.GerenteComercial,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = "ProcedimientoOperacion"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobacionProcedimientoCliente,
                    Rol = TipoRol.Lider,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobacionProcedimientoCliente,
                    Rol = TipoRol.GerenteComercial,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobacionProcedimientoCliente,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobarActualización,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "Aprobacion",
                    Vista = "Index",
                    Tab = "ActualizacionCliente"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.Activo,
                    Rol = TipoRol.GerenteComercial,
                    Controlador = "Consulta",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.Activo,
                    Rol = TipoRol.AltaCliente,
                    Controlador = "Consulta",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.Inactivo,
                    Rol = TipoRol.AltaCliente,
                    Controlador = "Consulta",
                    Vista = "Index",
                    Tab = ""
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.ParaAprobarActualización,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "ActualizarCliente",
                    Vista = "Index",
                    Tab = "DatosGeneralesCliente"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.RevalidaciónDeActualización,
                    Rol = TipoRol.AltaCliente,
                    Controlador = "ActualizarCliente",
                    Vista = "Index",
                    Tab = "DatosGeneralesCliente"
                },
                new NotificacionViewModel
                {
                    Estatus = EstatusCliente.Actualizado,
                    Rol = TipoRol.Aprobacion,
                    Controlador = "ActualizarCliente",
                    Vista = "Index",
                    Tab = "DatosGeneralesCliente"
                }
            };

            return lista;
        }

        #endregion

        public NotificacionViewModel ObtenerVistaControladorByRolEstatus(TipoRol rol, EstatusCliente estatus)
        {
            return ListaAnalisis().Find(l => l.Rol == rol && l.Estatus == estatus);
        }

    }
}
