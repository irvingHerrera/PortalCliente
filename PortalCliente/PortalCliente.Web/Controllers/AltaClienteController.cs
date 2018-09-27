using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data;
using System;

namespace PortalCliente.Web.Controllers
{
    public class AltaClienteController : Controller
    {
        private readonly IAltaClienteBusiness altaClienteBusiness;
        private readonly ICapturaClienteBussiness capturaCliente;

        public AltaClienteController()
        {
            altaClienteBusiness = new AltaClienteBusiness();
            capturaCliente = new CapturaClienteBussiness();
        }

        // GET: AltaClienteController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GenerarExpediente()
        {
            var listTest = new List<string>()
            {
                @"\Documentos\1\untitled.pdf",
                @"\Documentos\1\Introduccion-a-Xamarin-y-Xamarin.Forms_1.pdf",
                @"\Documentos\1\panda.gif",
                @"\Documentos\1\Curriculum Vitae Irving Ulises Herrera Molina.pdf",
                @"\Documentos\1\untitled2.pdf"
            };

            var t = Server.MapPath("~/");

            var ruta = altaClienteBusiness.GenerarExpediente(listTest, 1, Server.MapPath("~/"), "usuarioCreacion");

            return Json(ruta, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GuardarSistemasOperativos(SistemasOperativosViewModel modelo)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = altaClienteBusiness.GuardarSistemasOperativos(modelo);
                    if (resultado.Rows.Count > 0)
                    {
                        var fila = resultado.Rows[0];
                    }
                    // OBTENER DATOS PARA API
                    // LLAMAR A API
                    // GUARDAR DATOS EN ADUASIS
                    var listaJSON = GetTableRows(resultado);
                    return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> GuardarEdicion(CapturaClienteViewModel modelo)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return capturaCliente.ActualizarRegistroCliente(modelo, false);
                });

                return Json(new { resultado = result, mensaje = "Ocurrió un error al actualizar los datos.", }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    resultado = false,
                    mensaje = "Ocurrió un error al actualizar los datos.",
                    ErroTecnico = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}