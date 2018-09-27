using PortalCliente.Core;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class DocumentosClienteController : Controller
    {

        

        // GET: DocumentosCliente
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult GuardaDocumento()
		{
            var helper = new ArchivoHelper();

            try
			{
				var id = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form["id"].ToString());
				var tipo = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form["tipo"].ToString());
				string sPath = "";
				string temppath = "~/Documentos/" + id.ToString() + "/";
				sPath = System.Web.Hosting.HostingEnvironment.MapPath(temppath);
				System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

				sPath = System.Web.Hosting.HostingEnvironment.MapPath(temppath);
				System.Web.HttpPostedFile hpf = hfc[0];

                var indicie = hpf.FileName.Split('.').Length - 1;
                var ext = "." + hpf.FileName.Split('.')[indicie];

                if (!helper.ExtensionValida(ext.Substring(1, ext.Length - 1))) {
                    return Json(new { Resultado = false, Error = "El tipo de archivo no es admitido." });
                }

                if (!Directory.Exists(sPath))
				{
					Directory.CreateDirectory(sPath);
				}

                
                var _nombrearchivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ext;


                hpf.SaveAs(sPath + hpf.FileName.Replace(ext, _nombrearchivo));

				DocumentosClienteRepository dac = new DocumentosClienteRepository();
				ExDocumentos doc = new ExDocumentos();
				doc.usuario_creacion = "admin";
				doc.usuario_modificacion = "admin";
                //doc.ruta_local = sPath + hpf.FileName.Replace(ext, _nombrearchivo);
                doc.ruta_local = @"\Documentos\" + id.ToString() + "\\" + hpf.FileName.Replace(ext, _nombrearchivo);
                doc.id_precliente = id;
				doc.id_documento = tipo;
				doc.fecha_modificacion = DateTime.Now;
				doc.fecha_creacion = DateTime.Now;
				doc.activo = true; 	
				dac.guardaDocumento(doc);
				return Json(doc.ruta_local);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpGet]
		public ActionResult DocumentosCargadosPorPrecliente(int idprecliente,bool carga, string mensaje)
		{
			try
			{
				var _documentos = new DocumentosClienteRepository().DocumentosCargadosPorPrecliente(idprecliente,carga,mensaje);
				return Json(new { documentos = _documentos },JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

        [HttpGet]
        public ActionResult DesactivarDocumentos(int id_precliente, int tipo_documento)
        {
            try
            {
                var _documentos = new DocumentosClienteRepository().DesactivarDocumentos(id_precliente, tipo_documento);
                return Json(new { documentos = _documentos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { Resultado = false, Error = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult BuscarTodosDocumentos(int id_precliente, int tipo_documento)
        {
            try
            {
                var _documentos = new DocumentosClienteRepository().BuscarTodosDocumentos(id_precliente, tipo_documento);
                return Json(new { documentos = _documentos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { Resultado = false, Error = ex.Message });
            }
        }

    }
}