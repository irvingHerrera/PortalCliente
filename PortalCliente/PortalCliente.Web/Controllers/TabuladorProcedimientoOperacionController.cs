using PortalCliente.Data.DAC;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Repositorio;
using PortalCliente.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace PortalCliente.Web.Controllers
{
    public class TabuladorProcedimientoOperacionController : Controller
    {
        // GET: TabuladorProcedimientoOperacion
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public JsonResult GuardaTabuladorProcedimiento(ExTabuladorProcedimientoOperacion _ExTabuladorProcedimientoOperacion)
		{
			try
			{
				var res = new TabuladorProcedimientoOperacionBussines().GuardaTabuladorProcedimientoOperacionBussines(_ExTabuladorProcedimientoOperacion);
				if (res)
				{
					return Json(new { respuesta = true });
				}
				else
				{
					return Json(new { respuesta = false, error = "Ocurrio un error al guardar el procedimiento operación" });
				}
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message });
			}
		}

		[HttpGet]
		public JsonResult GetApliacacionPreferencia()
		{
			try
			{
				var _items = new TabuladorProcedimientoOperacionBussines().GetApliacacionPreferencia();
				return Json(new { respuesta = true, items = _items  },JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message },JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public JsonResult GetExIncoterms()
		{
			try
			{
				var _items = new TabuladorProcedimientoOperacionBussines().GetExIncoterms();
				return Json(new { respuesta = true, items = _items },JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message },JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public JsonResult GetExMetodoValoracions()
		{
			try
			{
				var _items = new TabuladorProcedimientoOperacionBussines().GetExMetodoValoracions();
				return Json(new { respuesta = true, items = _items }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message },JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public JsonResult GetFormaPagos()
		{
			try
			{
				var _items = new TabuladorProcedimientoOperacionBussines().GetFormaPagos();
				return Json(new { respuesta = true, items = _items }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public JsonResult GetRegimens()
		{
			try
			{
				var _items = new TabuladorProcedimientoOperacionBussines().GetRegimens();
				return Json(new { respuesta = true, items = _items }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public JsonResult GetTabuladorTab(int idprecliente)
		{
			try
			{
				var _items = new TabuladorProcedimientoOperacionBussines().GetByTabuladorTab(idprecliente);
				return Json(new { respuesta = true, items = _items } ,JsonRequestBehavior.AllowGet );
			}
			catch (Exception ex)
			{
				return Json(new { respuesta = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
			}			
		}

        [HttpGet]
        public JsonResult PuedeActualizarProcedimientoOperacion(int idprecliente)
        {
            try
            {
                var res = new TabuladorProcedimientoOperacionBussines().puedeActualizar(idprecliente);
                return Json(new { respuesta = res }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}