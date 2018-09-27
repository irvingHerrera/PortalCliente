using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ICatalogoBusiness catalogoBusiness;
        private readonly IConfiguracionBusiness configuracionBusiness;

        public CatalogoController()
        {
            catalogoBusiness = new CatalogoBusiness();
            configuracionBusiness = new ConfiguracionBusiness();
        }


        public async Task<JsonResult> ObtenerPais()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var lista = catalogoBusiness.ObtenerPais();
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
                        mensaje = "Error al obtener lista de Paises",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerEstados(string IdPais)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var lista = catalogoBusiness.ObtenerEstado(IdPais);
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
                        mensaje = "Error al obtener lista de Estados",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerCiudades(string IdEstado)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var lista = catalogoBusiness.ObtenerCiudad(IdEstado);
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
                        mensaje = "Error al obtener lista de Ciudades",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public async Task<JsonResult> ObtenerAduanas()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = catalogoBusiness.ObtenerAduanas();
                        return Json(new { resultado = true, mensaje = "", data = resultado }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ObtenerClavePedimento()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = catalogoBusiness.ObtenerClavePedimento();
                        return Json(new { resultado = true, mensaje = "", data = resultado }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ObtenerConceptoFacturacion(string empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = catalogoBusiness.ObtenerConceptoFacturacion(empresa);
                        return Json(new { resultado = true, mensaje = "", data = resultado }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ObtenerConceptoAutoFacturacion()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = catalogoBusiness.ObtenerConceptoAutoFacturacion();
                        return Json(new { resultado = true, mensaje = "", data = resultado }, JsonRequestBehavior.AllowGet);
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

        public JsonResult ObtenerEquipoOperativo()
        {
            try
            {
                var listaEquipo = configuracionBusiness.ObtenerEquipoOperativo();

                if (listaEquipo != null)
                    return Json(new { resultado = true, data = listaEquipo }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}