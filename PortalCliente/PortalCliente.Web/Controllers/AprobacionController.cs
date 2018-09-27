using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class AprobacionController : Controller
    {
        private readonly IAprobacionBusiness aprobacionBusiness;
        private readonly ICapturaClienteBussiness capturaCliente;
        private readonly IClienteBusiness clienteBusiness;
        private readonly Data.Interfaz.IDatosUsuarioRepository datosUsuario;
        private readonly INotificacionBusiness notificacionBusiness;

        public AprobacionController()
        {
            aprobacionBusiness = new AprobacionBusiness();
            capturaCliente = new CapturaClienteBussiness();
            clienteBusiness = new ClienteBusiness();
            datosUsuario = new DatosUsuarioBusiness();
            notificacionBusiness = new NotificacionBusiness();
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Revalidacion(int idUsuario, int idPrecliente, EstatusCliente estatus, string observacion)
        {
            switch (estatus)
            {
                case EstatusCliente.ParaAprobacionProcedimientoCliente:
                    estatus = EstatusCliente.RevalidacionProcedimientoCliente;
                    break;
                case EstatusCliente.ParaAprobacionProcedimientoPrealta:
                    estatus = estatus = EstatusCliente.RevalidacionProcedimientoPrealta;
                    break;
                default:
                    break;
            }

            try
            {
                var resultado = await Task.Run(() =>
                {
                    return aprobacionBusiness.RealizarRevalidacion(idUsuario, idPrecliente, estatus, observacion);
                });

                if (resultado)
                    return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion." }, JsonRequestBehavior.AllowGet);

            }
            catch (System.Exception ex)
            {
                return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion.", ErrorTecnico = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> Aprobacion(int idUsuario, int idPrecliente, EstatusCliente estatus)
        {
            switch (estatus)
            {
                case EstatusCliente.ParaAprobacionProcedimientoCliente:
                    estatus = EstatusCliente.Cliente;
                    break;
                case EstatusCliente.ParaAprobacionProcedimientoPrealta:
                    estatus = estatus = EstatusCliente.AprobadoPreAlta;
                    break;
                default:
                    break;
            }

            try
            {
                var resultado = await Task.Run(() =>
                {
                    return aprobacionBusiness.RealizarAprobacion(idUsuario, idPrecliente, estatus);
                });

                if (resultado)
                    return Json(new { resultado = true }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion." }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion.", ErrorTecnico = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        public async Task<JsonResult> ObtenerCuentaPECA(string idPrecliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.ObtenerCtasBancaria(idPrecliente);

                    return Json(new { resultado = true, data = resultado }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos de la cuenta.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerDirecionCliente(int idPrecliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = clienteBusiness.ObtenerDirecionCliente(idPrecliente);

                    return Json(new { resultado = true, data = resultado }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos de la cuenta.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerNumeroTabulador(int idUsuario, int idPrecliente)
        {
            try
            {
                var numero = await Task.Run(() =>
                {
                    return capturaCliente.ObtenerNumeroTabuladores(idUsuario, idPrecliente);
                });

                return Json(new { resultado = true, data = numero }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener el número de tabuladores.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerListaAprobador(int idPrecliente)
        {
            try
            {
                var listaAprobador = await Task.Run(() =>
                {
                    return capturaCliente.ObtenerRelacionPreclieteAprobador(idPrecliente);
                });

                return Json(new { resultado = true, data = listaAprobador }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(
                    new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener el número de tabuladores.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
            }
        }
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
        public async Task<JsonResult> ObtenerInfoCliente(string id_usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ObtenerInfoCliente(id_usuario);

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

        public async Task<JsonResult> ObtenerContactosCliente(string id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ObtenerContactosCliente(id_precliente);

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
        public async Task<JsonResult> ObtenerPECACliente(string id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ObtenerCtasBancPECACliente(id_precliente);

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

        public async Task<JsonResult> ObtenerUsrsAduabookCliente(string id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ObtenerUsrAduabookCliente(id_precliente);

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


        public async Task<JsonResult> AprobadoSinProcedimientoPreAlta(int idUsuario, int idPrecliente, int estatus, string observacion)
        {
            try
            {
                var resultado = await Task.Run(() =>
                {
                    return aprobacionBusiness.AprobadoSinProcedimientoPreAlta(idUsuario, idPrecliente, estatus, observacion);
                });

                if (resultado)
                    return Json(new { resultado = true });
                else
                    return Json(new { resultado = false, mensaje = "Ocurrió un error." });
            }
            catch (System.Exception)
            {
                return Json(new { resultado = false, mensaje = "Ocurrió un error." });
            }
        }

        public async Task<JsonResult> NoAprobado(int idUsuario, int idPrecliente, int estatus, string observacion)
        {
            try
            {

                var resultado = await Task.Run(() =>
            {
                return aprobacionBusiness.NoAprobado(idUsuario, idPrecliente, estatus, observacion);
            });

                if (resultado)
                    return Json(new { resultado = true });
                else
                    return Json(new { resultado = false, mensaje = "Ocurrió un error." });

            }
            catch (System.Exception)
            {
                return Json(new { resultado = false, mensaje = "Ocurrió un error." });
            }
        }
        public async Task<JsonResult> PreAltaRevalidacion(int idUsuario, int idPrecliente, int estatus, string observacion)
        {
            try
            {
                var resultado = await Task.Run(() =>
                {
                    return aprobacionBusiness.PreAltaRevalidacion(idUsuario, idPrecliente, estatus, observacion);
                });

                if (resultado)
                    return Json(new { resultado = true });
                else
                    return Json(new { resultado = false, mensaje = "Ocurrió un error en  Pre-Alta Revalidacion" });
            }
            catch (System.Exception)
            {
                return Json(new { resultado = false, mensaje = "Ocurrió un error." });
            }
        }
        public async Task<JsonResult> AprobacionActCliente(int idUsuario, int idPrecliente, string observacion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {

                        EstatusCliente estatus = EstatusCliente.Cliente;
                        aprobacionBusiness.EliminaActulizaTemporal(idUsuario.ToString(), idPrecliente);
                        var actualizarEstatus = aprobacionBusiness.RealizarRevalidacion(idPrecliente, idUsuario, estatus, observacion);

                        if (actualizarEstatus)
                        {
                            var envioCorreo = notificacionBusiness.EnvioCorreoNotificacion(idPrecliente);

                            if (envioCorreo != null)
                            {
                                return Json(new { resultado = true, mensaje = "", data = "" }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion.", data = "" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion.", data = "" }, JsonRequestBehavior.AllowGet);
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
                return await Task.Run(() =>
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al realizar la revalidacion.", ErrorTecnico = ex.Message }, JsonRequestBehavior.AllowGet);
                });
            }
        }
        public async Task<JsonResult> RevalidacionActCliente(int idUsuario, int idPrecliente, string observacion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {

                        var actualizarEstatus = aprobacionBusiness.RealizarRevalidacion(
                            idPrecliente, idUsuario, EstatusCliente.RevalidaciónDeActualización, observacion);
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

        public async Task<JsonResult> ObtenerInfActCliente(int idUsuario, int idPrecliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {

                        var informacionCte = aprobacionBusiness.ObtenerInfoActCliente(idPrecliente, idUsuario);
                        var tabuladores = aprobacionBusiness.ObtenerTabuladores(idPrecliente, idUsuario);
                        var empresas = aprobacionBusiness.ObtenerEmpTabulador1(idPrecliente, idUsuario);
                        var inffinanciera = aprobacionBusiness.ObtenerContactoInfFin(idPrecliente, idUsuario);
                        var servicios = aprobacionBusiness.ObtenerTarifaServicio(idPrecliente, idUsuario);
                        var usrsAduabook = capturaCliente.ObtenerUsrAduabookCliente(idPrecliente.ToString());
                        var contactosEI = aprobacionBusiness.ObtenerContactosEI(idPrecliente, idUsuario);
                        var contactosRS = capturaCliente.ObtenerContactosCliente(idPrecliente.ToString());

                        if (informacionCte != null)
                        {
                            var jsonInfte = GetTableRows(informacionCte);
                            var jsonTabuladores = GetTableRows(tabuladores);
                            var jsonEmpresas = GetTableRows(empresas);
                            var jsonContactosIF = GetTableRows(inffinanciera);
                            var jsonTarifaServ = GetTableRows(servicios);
                            var jsonUsaduabook = GetTableRows(usrsAduabook);
                            var jsonContactosEI = GetTableRows(contactosEI);
                            var jsonContactosRS = GetTableRows(contactosRS);

                            //new Dictionary<string, object> { { "EmpresasT1", jsonTabuladores } });
                            jsonInfte[0].Add("EmpresasT1", jsonEmpresas);
                            jsonInfte[0].Add("Tabuladores", jsonTabuladores);
                            jsonInfte[0].Add("ContactosIF", jsonContactosIF);
                            jsonInfte[0].Add("TarifaServ", jsonTarifaServ);
                            jsonInfte[0].Add("UsrsAduabook", jsonUsaduabook);
                            jsonInfte[0].Add("ContactosEI", jsonContactosEI);
                            jsonInfte[0].Add("ContactosRS", jsonContactosRS);

                            return Json(new
                            {
                                resultado = true,
                                data = jsonInfte[0]
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { resultado = false, mensaje = "Ocurrió un error al obtener la información de actualización cliente." }, JsonRequestBehavior.AllowGet);
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

    }
}