using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel.Tabuladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaBusiness consultaBusiness;
        private readonly IAprobacionBusiness aprobacionBussiness;
        private readonly IClienteBusiness clienteBusiness;
        private readonly INotificacionBusiness notificacionBusiness;

        public ConsultaController()
        {
            consultaBusiness = new ConsultaBusiness();
            clienteBusiness = new ClienteBusiness();
            aprobacionBussiness = new AprobacionBusiness();
            notificacionBusiness = new NotificacionBusiness();
        }

        public ActionResult PreCliente()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            return View();
        }

        public ActionResult AltaPendiente()
        {
            return View();
        }

        public async Task<JsonResult> ObtenerListaPreclientePendiente()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var listaEmpleado = consultaBusiness.ObtenerListaPreclientePendiente();

                    return Json(new { resultado = true, data = listaEmpleado }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos de los preclientes.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerUsrsNoAprobado(int id_precliente, int id_estatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = clienteBusiness.ObtenerUsrsCambioEstatus(id_precliente, id_estatus);

                        var listaJSON = GetTableRows(resultado);

                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al obtener los datos." }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> AprobacionPrealta(int idUsuario, int idPrecliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {

                        var actualizarEstatus = aprobacionBussiness.RealizarRevalidacion(
                            idPrecliente, idUsuario, EstatusCliente.AprobadoPreAlta, "");
                        if (actualizarEstatus)
                        {
                            var envioCorreo = notificacionBusiness.EnvioCorreoNotificacion(idPrecliente);

                            if (envioCorreo != null)
                                return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);
                            else
                                return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion." }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion." }, JsonRequestBehavior.AllowGet);
                        }

                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al obtener los datos." }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (System.Exception ex)
            {
                return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion.", ErrorTecnico = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> ObtenerInfoTabulador(int id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = consultaBusiness.ObtenerInfoTabuladoresTEMP(id_precliente);

                        var listaJSON = GetTableRows(resultado);

                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al obtener los datos." }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerAprobacionDePreAltaCliente(int idPrecliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = consultaBusiness.ObtenerAprobacionDePreAltaCliente(idPrecliente);

                        var listaJSON = GetTableRows(resultado);

                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al obtener los datos." }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerAprobacionDeAltaCliente(int idPrecliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = consultaBusiness.ObtenerAprobacionDeAltaCliente(idPrecliente);

                        var listaJSON = GetTableRows(resultado);

                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al obtener los datos." }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        

        //Convierte un DataTable en Diccionario. (Para retornar como JSON)
        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }
    }
}