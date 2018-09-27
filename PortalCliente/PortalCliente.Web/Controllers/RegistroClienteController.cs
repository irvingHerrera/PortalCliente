using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.RegistroCliente;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class RegistroClienteController : Controller
    {
        private readonly IRegistroClienteBusiness registroCliente;
        private readonly INotificacionBusiness notificacionBusiness;

        public RegistroClienteController()
        {
            registroCliente = new RegistroClienteBusiness();
            notificacionBusiness = new NotificacionBusiness();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BaseViewModel model)
        {
            return View();
        }

        public JsonResult TestCarta()
        {
            var modelo = new CartaEncomiendaViewModel
            {
                IdPrecliente = 2,
                IdUsuario = 1,
                NombreNotarioPublico = "Nombre Notario Publico",
                PeriodoCompredidoInicio = DateTime.Now,
                PeriodoCompredidoFin = DateTime.Now,
                CiudadNotariado = "Cuernavaca",
                EstadoNotariado = "Morelos",
                MembreteEmpresa = "Membrete Empresa",
                NumeroEscritura = "Numero Escritura",
                NumeroNotaria = "Numero Notaria",
                NombreAgenteAduanal = "EDUARDO MARTINIANO VILLARREAL DELGADO",
                Patente = "3457",
                DirreccionPatente = "TAXCO NO.3660 COL.MEXICO, NUEVO LAREDO,TAM C.P.88280"
            };

            registroCliente.GenerarCartaEncomienda(modelo, Server.MapPath("~/"));
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ObtieneDatosTituloSecciones(int idPrecliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var datos = new ClienteRepository().ObtenerTituloSecciones(idPrecliente);
                    List<string> lista = new List<string>();
                    return Json(new { resultado = true, data = datos }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (Exception ex)
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

        public async Task<JsonResult> ObtieneDatosFinanciamiento(int idPrecliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var datos = new ClienteRepository().ObtienerFinanciamiento(idPrecliente);
                    return Json(new { resultado = true, data = datos }, JsonRequestBehavior.AllowGet);
                });
            }
            catch (Exception ex)
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

        public async Task<JsonResult> GuardarDatoCliente(DatoClienteViewModel modelo)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.GuardarDatoCliente(modelo);
                        if (resultado)
                            return Json(new { resultado }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { resultado = false, mensaje = "Ocurrió un error al guardar los datos." }, JsonRequestBehavior.AllowGet);
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al guardar los datos." }, JsonRequestBehavior.AllowGet);
                }


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

        public async Task<JsonResult> GuardarCuestionario(CuestionarioViewModel cuestionario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.GuardarCuestionario(cuestionario);
                        if (resultado)
                            return Json(new { resultado }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { resultado = false, mensaje = "Ocurrió un error al guardar el cuestonario." }, JsonRequestBehavior.AllowGet);
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al guardar el cuestipnario." }, JsonRequestBehavior.AllowGet);
                }


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

        public async Task<JsonResult> ObtenerPaises()
        {

            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.ObtenerPaises();

                        List<Pais> lista = new List<Pais> { new Pais { id_pais = "", pais = "-- Seleccione un país --" } };
                        foreach (DataRow fila in resultado.Rows)
                        {
                            lista.Add(new Pais()
                            {
                                id_pais = fila["id_pais"].ToString(),
                                pais = fila["pais"].ToString(),
                            });
                        }

                        return Json(lista, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ObtenerEstados(string id_pais)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.ObtenerEstados(id_pais);

                        List<Estado> lista = new List<Estado> { new Estado { id_estado = "", estado = "-- Seleccione un estado --" } };
                        foreach (DataRow fila in resultado.Rows)
                        {
                            lista.Add(new Estado()
                            {
                                id_estado = fila["id_estado"].ToString(),
                                estado = fila["estado"].ToString(),
                            });
                        }

                        return Json(lista, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ObtenerCiudades(string id_estado)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.ObtenerCiudades(id_estado);

                        List<Ciudad> lista = new List<Ciudad> { new Ciudad { id_ciudad = "", ciudad = "-- Seleccione una ciudad --" } };
                        foreach (DataRow fila in resultado.Rows)
                        {
                            lista.Add(new Ciudad()
                            {
                                id_ciudad = fila["id_municipio"].ToString(),
                                ciudad = fila["ciudad"].ToString(),
                            });
                        }
                        return Json(lista, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> GuardarDatosCartaEnc(string id_usuario, string domicilio_fiscal_calle,
            string domicilio_fiscal_ciudad,
            string domicilio_fiscal_colonia,
            string domicilio_fiscal_cp,
            string domicilio_fiscal_estado,
            string domicilio_fiscal_municipio,
            string domicilio_fiscal_no_ext,
            string domicilio_fiscal_no_int,
            string numero_escritura,
            string nombre_notario,
            string numero_notaria,
            string ciudad_notariado,
            string estado_notariado,
            string membrete_empresa,
            DateTime periodo_compredido_inicio,
            DateTime periodo_compredido_fin,
            string patente_carta_encomienda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.GuardarCamposCartaEnc(
                            id_usuario,
                            domicilio_fiscal_calle,
             domicilio_fiscal_ciudad,
             domicilio_fiscal_colonia,
             domicilio_fiscal_cp,
             domicilio_fiscal_estado,
             domicilio_fiscal_municipio,
             domicilio_fiscal_no_ext,
             domicilio_fiscal_no_int,
             numero_escritura,
             nombre_notario,
             numero_notaria,
             ciudad_notariado,
             estado_notariado,
             membrete_empresa,
             periodo_compredido_inicio,
             periodo_compredido_fin,
             patente_carta_encomienda);

                        return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
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
        public async Task<JsonResult> ObtenerPatentes()
        {

            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.ObtenerPatentes();

                        List<Patente> lista = new List<Patente> { new Patente { id_patente = "", patente = "-- Seleccione un patente --", nombre = "", direccion = "" } };
                        foreach (DataRow fila in resultado.Rows)
                        {
                            lista.Add(new Patente()
                            {
                                id_patente = fila["id_patente"].ToString(),
                                patente = fila["patente"].ToString(),
                                nombre = fila["nombre"].ToString(),
                                direccion = fila["direccion"].ToString(),
                            });
                        }

                        return Json(lista, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> GenerarCartaenc(CartaEncomiendaViewModel modelo)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {

                        var resultado = registroCliente.GenerarCartaEncomienda(modelo, Server.MapPath("~/"));

                        if (string.IsNullOrEmpty(resultado))
                        {
                            return Json(new { resultado = false, mensaje = "Carta encomienda no generada." }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { resultado = true, documento = resultado }, JsonRequestBehavior.AllowGet);
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
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al obtener los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        public ActionResult DescargarDoc(string name)
        {
            return File(Server.MapPath("~/") + "Docs" + @"\" + name, "application/pdf", "CartaEncomienda.pdf");
        }

        public async Task<JsonResult> ObtenerDatosCartaEnc(int? id_usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = registroCliente.ObtenerDatosCartaEnc(id_usuario ?? 0);
                        var listaJson = GetTableRows(resultado);

                        return Json(new { resultado = true, data = listaJson }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> CerrarPrecliente(int id_usuario, bool con_carta_encomienda, string id_precliente, string motivo_sin_carta_encomienda)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = registroCliente.CerrarPrecliente(id_usuario, con_carta_encomienda, motivo_sin_carta_encomienda);
                    if (resultado)
                    {
                        var envioCorreo = notificacionBusiness.EnvioCorreoNotificacion(int.Parse(id_precliente));
                        return Json(new { resultado }, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(new { resultado = false, mensaje = "Ocurrió un error al cerrar el precliente." }, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public JsonResult ObtieneDatosClientePost(int idusuario)
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

    } //class



    public class Pais
    {
        public string id_pais { get; set; }
        public string pais { get; set; }
    }
    public class Estado
    {
        public string id_estado { get; set; }
        public string estado { get; set; }
    }
    public class Ciudad
    {
        public string id_ciudad { get; set; }
        public string ciudad { get; set; }
    }
    public class Patente
    {
        public string id_patente { get; set; }
        public string patente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
    }

}