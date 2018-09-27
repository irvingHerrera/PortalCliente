using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using System.Web.Mvc;
using System.Linq;
using PortalCliente.Core;
using PortalCliente.Core.ViewModel;

namespace PortalCliente.Web.Controllers
{
    public class ImpresionController : Controller
    {
        private readonly IImpresionBusiness impresionBusiness;
        private readonly IAltaClienteBusiness altaClienteBusiness;

        public ImpresionController()
        {
            impresionBusiness = new ImpresionBusiness();
            altaClienteBusiness = new AltaClienteBusiness();
        }

        // GET: Impresion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerExpediente(int idPrecliente, int idUsuario)
        {
            try
            {
                var listaDocuemento = impresionBusiness.ObtenerDocumentoClienteExpediente(idPrecliente);
                var listaRuta = listaDocuemento.Select( d => d.RutaLocal).ToList();

                var ruta = altaClienteBusiness.GenerarExpediente(listaRuta, idPrecliente, Server.MapPath("~/"), AplicacionDatoUsuario.Instancia.Usuario.Nombre);

                var documento = new DocumentoViewModel();

                if (string.IsNullOrEmpty(ruta))
                {
                    documento = null;
                }
                else
                {
                    documento.ExisteDocumento = true;
                    documento.IdPrecliente = idPrecliente;
                    documento.RutaLocal = ruta;
                }

                if (documento != null)
                {
                    return Json(new { resultado = true, data = documento }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener el expediente."
                    }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (System.Exception ex)
            {
                return Json(new
                {
                    resultado = false,
                    mensaje = "Ocurrió un error al obtener el expediente.",
                    ErrorTecnico = ex.Message + "\n" + ex.StackTrace
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReporteSolicitudCliente(int idPrecliente, int idUsuario)
        {
            try
            {
                var documento = impresionBusiness.ReporteSolicitudCliente(idPrecliente, idUsuario, Server.MapPath("~/"));

                if (documento != null)
                {
                    return Json(new { resultado = true, data = documento }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener la solicitud."
                    }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (System.Exception ex)
            {
                return Json(new
                {
                    resultado = false,
                    mensaje = "Ocurrió un error al obtener la solicitud.",
                    ErrorTecnico = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReporteProcedimientoOperacion(int idPrecliente, int idUsuario)
        {
            try
            {
                var documento = impresionBusiness.ReporteProcedimientoOperacion(idPrecliente, idUsuario, Server.MapPath("~/"));

                if (documento != null)
                {
                    return Json(new { resultado = true, data = documento }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener la solicitud."
                    }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (System.Exception ex)
            {
                return Json(new
                {
                    resultado = false,
                    mensaje = "Ocurrió un error al obtener la solicitud.",
                    ErrorTecnico = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult TestReporteTabulador(int idPrecliente, int idUsuario)
        {
            var documento = impresionBusiness.ReporteTabulador(idPrecliente, Server.MapPath("~/"));

            return Json(documento, JsonRequestBehavior.AllowGet);
        }
    }
}