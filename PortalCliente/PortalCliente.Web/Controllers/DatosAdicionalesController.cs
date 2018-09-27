using PortalCliente.Data.DAC;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class DatosAdicionalesController : Controller
    {
        // GET: DatosAdicionales
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult GuardaDatosAdicionales(ExDatosAdicionales datosadicionales, 
			                                  List<ExUsuariosAudabook> usuariosaudabook)
		{
			try
			{
			    new DxDatosAdicionales().GuardaDatosADicionales(datosadicionales);
				var dac = new DxUsuarisoAudabook();

                dac.deletePorPrecliente(datosadicionales.id_precliente);
               
				    foreach (var v in usuariosaudabook)
				    {
						v.fecha_creacion = DateTime.Now;
						v.fecha_modificacion = DateTime.Now;
						v.id_precliente = datosadicionales.id_precliente;
						v.usuario_creacion = "admin";
						v.usuario_modificacion = "admin";
					    dac.Save(v);
				    }

				return Json(new { Ok = "OK" });
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpGet]
		public JsonResult ObtieneDatosCliente(int idusuario)
		{
			try
			{
				var datos = new ClienteRepository().ObtenerCliente(idusuario);
				return Json(datos, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}

		}
    }
}