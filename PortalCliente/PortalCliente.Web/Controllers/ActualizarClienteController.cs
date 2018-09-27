using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel.Tabuladores;
using PortalCliente.Data.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class ActualizarClienteController : Controller
    {

        private readonly IActualizarClienteBussiness actualizarCteBussiness;
        private readonly IClienteBusiness clienteBusiness;

        public ActualizarClienteController()
        {
            actualizarCteBussiness = new ActualizarClienteBussiness();
            clienteBusiness = new ClienteBusiness();
        }

        // GET: ActualizarCliente
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GuardarDatoOperacion(TabuladorViewModel modelo,
            List<ExTabuladorProcedimientoOperacion> _ExTabuladorProcedimientoOperacion)
        {
            try
            {
                return await Task.Run(() =>
                {
                    modelo.Ciudad = new Core.CatalogoViewModel { id = modelo.IdCiudad };
                    modelo.Estado = new Core.CatalogoViewModel { id = modelo.IdEstado };

                    var resultado = actualizarCteBussiness.GuardarDatoOperacion(modelo);

                    if (_ExTabuladorProcedimientoOperacion == null) goto NoTabs;

                    foreach (var itemTab in _ExTabuladorProcedimientoOperacion)
                    {
                        resultado = new TabuladorProcedimientoOperacionBussines().GuardaTabuladorProcedimientoOperacionBussines_TMP(itemTab);
                        if (!resultado) break;
                    }

                    //etiqueta para no guardar los "N" procedimientos de operacion
                    NoTabs:

                    if (resultado)
                    {

                        clienteBusiness.ActualizarEstatus(modelo.IdUsuario, (int)EstatusCliente.ParaAprobarActualización);
                        return Json(new { resultado }, JsonRequestBehavior.AllowGet);
                    }
                        
                    else
                        return Json(new { resultado = false, mensaje = "Ocurrió un error al guardar los datos." }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al guardar los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> BuscarDatosTabuladores(string id_precliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    bool temporal = false;
                    var resultado = actualizarCteBussiness.BuscarDatosTabuladores(id_precliente, ref temporal);
                    var listaJSON = GetTableRows(resultado);
                    if (listaJSON.Count > 0)
                    {
                        return Json(new { resultado = true, mensaje = "", data = listaJSON, temporal = temporal }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { resultado = false, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                });
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

        public async Task<JsonResult> BuscarDatosTabuladoresContactos(string id_precliente, bool temporal)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = actualizarCteBussiness.BuscarDatosTabuladoresContactos(id_precliente, temporal);
                    var listaJSON = GetTableRows(resultado);
                    if (listaJSON.Count > 0)
                    {
                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { resultado = false, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                });
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

        public async Task<JsonResult> BuscarDatosTabuladoresTarifas(string id_precliente, bool temporal)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = actualizarCteBussiness.BuscarDatosTabuladoresTarifas(id_precliente, temporal);
                    var listaJSON = GetTableRows(resultado);
                    if (listaJSON.Count > 0)
                    {
                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { resultado = false, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                });
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

        public async Task<JsonResult> BuscarDatosTabuladoresTabs(string id_precliente, bool temporal)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = actualizarCteBussiness.BuscarDatosTabuladoresTabs(id_precliente, temporal);
                    var empresas = ObtenerTablaEmpresa();

                    foreach (DataRow tab in resultado.Rows)
                    {
                        var empresa = actualizarCteBussiness.BuscarDatosTabuladoresEmpresa(tab["id_tabulador_tab"].ToString(), temporal);

                        foreach (DataRow item in empresa.Rows)
                        {
                            empresas.Rows.Add(item.ItemArray);
                        }
                    }

                    var listaEmpresa = GetTableRows(empresas);

                    var listaJSON = GetTableRows(resultado);
                    if (listaJSON.Count > 0)
                    {
                        return Json(new
                        {
                            resultado = true,
                            mensaje = "",
                            data = new { tabs = listaJSON, empresas = listaEmpresa }
                        }
                                    , JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { resultado = false, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                });
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

        private DataTable ObtenerTablaEmpresa()
        {
            var tabla = new DataTable();

            tabla.Columns.Add("empresa");
            tabla.Columns.Add("concepto_facturacion");
            tabla.Columns.Add("concepto_auto_facturacion");
            tabla.Columns.Add("tarifa_venta");
            tabla.Columns.Add("tarifa_venta_tipo_moneda");
            tabla.Columns.Add("tarifa_compra");
            tabla.Columns.Add("tarifa_compra_tipo_moneda");
            tabla.Columns.Add("id_tabulador_tab");
            tabla.Columns.Add("descripcion_autofacturacion");
            tabla.Columns.Add("descripcion_facturacion");

            return tabla;
        }

        public async Task<JsonResult> BuscarDatosTabuladoresEmpresa(string id_tabulador_tab, bool temporal)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = actualizarCteBussiness.BuscarDatosTabuladoresEmpresa(id_tabulador_tab, temporal);
                    var listaJSON = GetTableRows(resultado);
                    if (listaJSON.Count > 0)
                    {
                        return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { resultado = false, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                    }
                });
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

        [HttpGet]
        public JsonResult GetTabuladorTab(int idprecliente)
        {
            try
            {
                var _items = actualizarCteBussiness.GetByTabuladorTab(idprecliente);
                return Json(new { respuesta = true, items = _items }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
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

        //[HttpPost]
        //public JsonResult GuardaTabuladorProcedimiento(ExTabuladorProcedimientoOperacion _ExTabuladorProcedimientoOperacion)
        //{
        //    try
        //    {
        //        var res = new TabuladorProcedimientoOperacionBussines().GuardaTabuladorProcedimientoOperacionBussines(_ExTabuladorProcedimientoOperacion);
        //        if (res)
        //        {
        //            return Json(new { respuesta = true });
        //        }
        //        else
        //        {
        //            return Json(new { respuesta = false, error = "Ocurrio un error al guardar el procedimiento operación" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { respuesta = false, error = ex.Message });
        //    }
        //}
    }
}