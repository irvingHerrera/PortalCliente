using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.Tabuladores;
using PortalCliente.Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class CapturaClienteController : Controller
    {

        private readonly ICapturaClienteBussiness capturaCliente;
        private readonly IClienteBusiness clienteBusiness;
        private readonly INotificacionBusiness notificacionBusiness;
        private readonly IDatosUsuarioRepository datosUsuario;

        public CapturaClienteController()
        {
            capturaCliente = new CapturaClienteBussiness();
            clienteBusiness = new ClienteBusiness();
            notificacionBusiness = new NotificacionBusiness();
            datosUsuario = new DatosUsuarioBusiness();
        }

        #region Metodos Privados

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
        
        #endregion

        // GET: CapturaCliente
        public ActionResult Index()
        {
            return View();
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

        public async Task<JsonResult> ObtenerCuestionarioCliente(string id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ObtenerCuestionarioCliente(id_precliente);

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

        public ActionResult TestProcedimiento()
        {
            return View();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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

        public async Task<JsonResult> ObtenerDocumentosCliente(string id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ObtenerDocumentosCliente(id_precliente);

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

        public async Task<JsonResult> GuardarRevisionDocumentosCliente(string id_precliente, string id_usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.GuardarRevisionDocumentosCliente(id_precliente, id_usuario);

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

        public async Task<JsonResult> GuardarTabuladores(TabuladorViewModel modelo)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.GuardarTabuladores(modelo);
                    if (resultado)
                        return Json(new { resultado }, JsonRequestBehavior.AllowGet);
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
                    var resultado = capturaCliente.BuscarDatosTabuladores(id_precliente);
                    var listaJSON = GetTableRows(resultado);
                    if(listaJSON.Count > 0) {
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

        public async Task<JsonResult> BuscarDatosTabuladoresContactos(string id_precliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.BuscarDatosTabuladoresContactos(id_precliente);
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

        public async Task<JsonResult> BuscarDatosTabuladoresTarifas(string id_precliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.BuscarDatosTabuladoresTarifas(id_precliente);
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

        public async Task<JsonResult> BuscarDatosTabuladoresTabs(string id_precliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.BuscarDatosTabuladoresTabs(id_precliente);
                    var empresas = ObtenerTablaEmpresa();

                    foreach (DataRow tab in resultado.Rows)
                    {
                        var empresa = capturaCliente.BuscarDatosTabuladoresEmpresa(tab["id_tabulador_tab"].ToString());

                        foreach (DataRow item in empresa.Rows)
                        {
                            empresas.Rows.Add(item.ItemArray);
                        }
                    }

                    var listaEmpresa = GetTableRows(empresas);

                    var listaJSON = GetTableRows(resultado);
                    if (listaJSON.Count > 0)
                    {
                        return Json(new { resultado = true, mensaje = "",
                                    data = new { tabs = listaJSON, empresas = listaEmpresa } }
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

        public async Task<JsonResult> BuscarDatosTabuladoresEmpresa(string id_tabulador_tab)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.BuscarDatosTabuladoresEmpresa(id_tabulador_tab);
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

        public async Task<JsonResult> TerminarProcedimientoOperacion(string id_precliente, string id_usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        if (string.IsNullOrEmpty(id_precliente) || string.IsNullOrEmpty(id_usuario))
                        {
                            throw new Exception("El parametro id_precliente o id_usuario no pueden ser nulos o vacíos.");
                        }

                        DataTable datosUsr = datosUsuario.ObtenerDatosUsuario(id_usuario.ToString());
                        int previoEstatus = Convert.ToInt16(datosUsr.Rows[0]["estatus"]);
                        int nuevoEstatus = 0;

                        if (previoEstatus == 5) //estatus aprobado sin procedimiento pre alta
                        {
                            nuevoEstatus = 10;
                        }
                        else if (previoEstatus == 8 &&
                        Convert.ToBoolean(datosUsr.Rows[0]["banderilla"])) //estatus cliente sin procedimiento
                        {
                            nuevoEstatus = 11;
                        }
                        else
                        {
                            throw new Exception("El cliente debe estar en estatus " +
                                "'Aprobado sin procedimiento Pre-Alta'" +
                                " o " +
                                "'Para aprobación Procedimiento Cliente' con banderilla activo.");
                        }

                        var actualizarEstatus = clienteBusiness.ActualizarEstatus(int.Parse(id_usuario), nuevoEstatus);

                        var envioCorreo = notificacionBusiness.EnvioCorreoNotificacion(int.Parse(id_precliente));

                        if (actualizarEstatus != null && envioCorreo != null)
                        {
                            return Json(new { resultado = true, mensaje = "", data = "" }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { resultado = false, mensaje = "Error al Terminar Procesos de Operación", data = "" }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> GuardarEdicion(CapturaClienteViewModel modelo)
        {
            try
            {
                var result = await Task.Run(() =>
                    {
                        return capturaCliente.ActualizarRegistroCliente(modelo, true);
                    });

                return Json(new { resultado = result }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ValidaNumeroDocumentosRevisados(string id_precliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.Run(() =>
                    {
                        var resultado = capturaCliente.ValidaNumeroDocumentosRevisados(id_precliente);
                        String auxiliar = "";
                        auxiliar = resultado.Rows[0]["Resultado"].ToString();
                        var listaJSON = GetTableRows(resultado);
                        if(auxiliar == "0")
                        {
                            return Json(new { resultado = false, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { resultado = true, mensaje = "", data = listaJSON }, JsonRequestBehavior.AllowGet);
                        }                        
                    });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Ocurrió un error al validar los datos." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
                {
                    return Json(new
                    {
                        resultado = false,
                        mensaje = "Ocurrió un error al validar los datos.",
                        ErroTecnico = ex.Message
                    }, JsonRequestBehavior.AllowGet);
                });
            }
        }

        [HttpGet]
        public async Task<JsonResult> ObtieneTabsPrecliente(int idPrecliente)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return capturaCliente.ObtieneTabsPrecliente(idPrecliente);
                });

                List<string> lista = new List<string>();
                foreach (DataRow v in result.Rows)
                {
                    lista.Add(v["id_tabulador_tab"].ToString() + "|" + v["indice"].ToString());
                }
                return Json(new { resultado = lista }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> GuardarTerminarProcedimientoOperacion(string id_precliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var datos = capturaCliente.GuardarTerminarProcedimientoOperacion(id_precliente);
                    string resultado = "";
                    foreach (DataRow v in datos.Rows)
                    {
                        resultado = v["Resultado"].ToString();
                    }
                    return Json(new { data = resultado, resultado = true }, JsonRequestBehavior.AllowGet);
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

        public async Task<JsonResult> ActivarCliente(string id_precliente)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var resultado = capturaCliente.ActivarCliente(id_precliente);

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


    }
}



