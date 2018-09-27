using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class NotificacionController : Controller
    {
        private readonly INotificacionBusiness notificacionBusiness;
        private readonly IClienteBusiness clienteBusiness;

        public NotificacionController()
        {
            notificacionBusiness = new NotificacionBusiness();
            clienteBusiness = new ClienteBusiness();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Método para verificar si el usuario ya acepto los términos y condiciones
        /// </summary>
        /// <param name="idPreCliente"></param>
        /// <returns></returns>
        public async Task<JsonResult> ValidarTerminoCondicion(int idUsuario)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = notificacionBusiness.ObtenerEstatusTerminoCondicion(idUsuario);
                    return Json(new { resultado }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Error al consultar estatus de términos y condiciones",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }

        }

        /// <summary>
        /// Método que actualiza el estatus de terminos y condiciones del cliente
        /// </summary>
        /// <param name="idPreCliente"></param>
        /// <returns></returns>
        public async Task<JsonResult> AceptarTerminoCondicion(int idPreCliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = notificacionBusiness.ActualizarEstatusTerminoCondicion(idPreCliente, true);
                    return Json(new { resultado }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {

                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Error al aceptar términos y condiciones",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }

        }

        /// <summary>
        /// Método para obtener las notificaciones correspondientes al usuario
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> ObtenerNotificacion(int idUsuario, int idRol)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var lista = notificacionBusiness.ObtenerNotificacion(idUsuario, idRol);
                    return Json(new { resultado = true, dato = lista }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {

                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Error al obtener las notificaciones",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        /// <summary>
        /// Método para obtener los datos del usuario
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> ObtenerDatosUsuario(string usuario)
        {
            try
            {
                return await Task.Run(() =>
                {
                    DatosUsuarioBusiness obj = new DatosUsuarioBusiness();
                    var resultado = obj.ObtenerDatosUsuario(usuario);
                    List<DatosUsuarioViewModel> lista = new List<DatosUsuarioViewModel>();
                    foreach (DataRow fila in resultado.Rows)
                    {
                        lista.Add(new DatosUsuarioViewModel()
                        {
                            IdUsuario = fila["id_usuario"].ToString(),
                            Rol = (TipoRol)Enum.Parse(typeof(TipoRol), fila["id_rol"].ToString()),
                            Nombre = fila["nombre"].ToString(),
                            Usuario = fila["usuario"].ToString(),
                            Correo = fila["correo"].ToString(),
                            Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
                            IdPrecliente = fila["id_precliente"].ToString(),
                        });
                    }
                    return Json(lista, JsonRequestBehavior.AllowGet);
                    //return Json(new { resultado = true, dato = lista }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {

                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Error al obtener los datos del Usuario",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }


        /// <summary>
        /// Método que obtiene la lista de precliente para los combos de búsqueda
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult BusquedaPrecliente(string banderilla = "")
        {
            var lista = clienteBusiness.ObtenerListaPrecliente(banderilla);
            return PartialView("_BusquedaPrecliente", lista);
        }

        [ChildActionOnly]
        public ActionResult BusquedaPreclienteActivo()
        {
            var lista = clienteBusiness.ObtenerListaPreclienteActivo();
            return PartialView("_BusquedaPrecliente", lista);
        }

        [ChildActionOnly]
        public ActionResult BusquedaCliente(int GrupoEstatus)
        {
            var lista = clienteBusiness.ObtenerListaCliente(GrupoEstatus);
            return PartialView("_BusquedaPrecliente", lista);
        }

        [ChildActionOnly]
        public ActionResult BusquedaClienteAprobacion(int GrupoEstatus, int Rol, int id_usuario)
        {
            var lista = clienteBusiness.ObtenerListaClienteAprobacion(GrupoEstatus, Rol, id_usuario);
            return PartialView("_BusquedaPrecliente", lista);
        }

        [ChildActionOnly]
        public ActionResult BusquedaClienteSoloClientes()
        {
            var lista = clienteBusiness.ObtenerListaSoloClientes();
            ViewBag.isCliente = true;
            return PartialView("_BusquedaPrecliente", lista);
        }

        [ChildActionOnly]
        public ActionResult BusquedaClienteSoloPreclientes()
        {
            var lista = clienteBusiness.ObtenerListaSoloPreclientes();
            return PartialView("_BusquedaPrecliente", lista);
        }

        //public async Task<JsonResult> ObtenerListaPrecliente()
        //{
        //    try
        //    {
        //        return await Task.Run(() =>
        //        {
        //            var lista = clienteBusiness.ObtenerListaPrecliente();
        //            return Json(new { resultado = true, dato = lista }, JsonRequestBehavior.AllowGet);
        //        });
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return Json(new
        //            {
        //                resultado = false,
        //                mensaje = "Error al obtener la lista de preclientes",
        //                ErroTecnico = ex.Message
        //            }, JsonRequestBehavior.AllowGet);
        //        });
        //    }
        //}


    }
}