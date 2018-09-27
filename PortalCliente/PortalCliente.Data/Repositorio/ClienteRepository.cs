using PortalCliente.Data.BD;
using PortalCliente.Data.DAC;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
    public class ClienteRepository : DataBaseAcces, IClienteRepository
    {

        public DataTable ObtenerDatoCliente(int idUsuario)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idUsuario,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_usuario"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerInformacionCliente");
            return resultado;
        }

        public DataTable ObtenerDatosTituloSecciones(int idprecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idprecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerDatosTituloSecciones");
            return resultado;
        }

        public DataTable ObtenerDatosFinanciamiento(int idprecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idprecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerDatosFinanciamiento");
            return resultado;
        }

        public DataTable ObtenerListaPreCliente(string banderilla)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = banderilla,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@banderilla"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerPreclientes");
            return resultado;
        }

        public DataTable ObtenerListaCliente(int GrupoEstatus)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = GrupoEstatus,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@opcion"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerClientesEstatus");
            return resultado;
        }

        public DataTable ObtenerListaClienteAprobacion(int GrupoEstatus, int Rol, int id_usuario)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = GrupoEstatus,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@opcion"
            });

            parametro.Add(new SqlParameter
            {
                Value = Rol,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@rol"
            });

            parametro.Add(new SqlParameter
            {
                Value = id_usuario,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_usuario"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerClientesEstatusAprobacion");
            return resultado;
        }

        public DataTable ObtenerListaPreClienteActivo()
        {
            var resultado = Select(new List<SqlParameter>(), "dbo.csp_CLI_ObtenerPreclientesActivos");
            return resultado;
        }

        public DataTable ObtenerContactos(string idprecliente)
        {
            var res = new CapturaClienteRepository().ObtenerContactosCliente(idprecliente);
            return res;
        }

        public List<ContactoDTO> ObtieneContactosPorPrecliente(string idprecliete)
        {
            List<ContactoDTO> lista = new List<ContactoDTO>();
            var datos = ObtenerContactos(idprecliete);
            foreach (DataRow dr in datos.Rows)
            {
                ContactoDTO cto = new ContactoDTO();
                cto.Nombre = dr["nombre"].ToString();
                cto.Correo = dr["correo"].ToString();
                cto.Telefono = dr["telefono"].ToString();
                cto.Area = dr["area"].ToString();
                cto.PuestoDepartamento = dr["puesto_departamento"].ToString();
                lista.Add(cto);
            }
            return lista;

        }

        public ClienteDTO ObtenerCliente(int idusuario)
        {
            var dr = ObtenerDatoCliente(idusuario).Rows[0];
            ClienteDTO cte = new ClienteDTO();
            cte.IdPreCliente = dr["id_precliente"] == DBNull.Value ? 0 : Convert.ToInt32(dr["id_precliente"]);
            cte.IdUsuario = dr["id_usuario"] == DBNull.Value ? 0 : Convert.ToInt32(dr["id_usuario"]);
            cte.IdClienteAduasis = dr["es_cliente_aduasis"] == DBNull.Value ? 0 : Convert.ToInt32(dr["es_cliente_aduasis"]);
            cte.IdClienteGP = dr["es_cliente_gp"] == DBNull.Value ? 0 : Convert.ToInt32(dr["es_cliente_gp"]);
            cte.EsCliente = dr["es_cliente"] == DBNull.Value ? false : Convert.ToBoolean(dr["es_cliente"]);
            cte.RepresentanteLegal = dr["representante_legal"] == DBNull.Value ? "" : dr["representante_legal"].ToString();
            cte.NombreFiscal = dr["nombre_fiscal"] == DBNull.Value ? "" : dr["nombre_fiscal"].ToString();
            cte.RFC = dr["rfc"] == DBNull.Value ? "" : dr["rfc"].ToString();
            cte.NombreComercial = dr["nombre_comercial"] == DBNull.Value ? "" : dr["nombre_comercial"].ToString();
            cte.Calle = dr["calle"] == DBNull.Value ? "" : dr["calle"].ToString();
            cte.NoExt = dr["no_ext"] == DBNull.Value ? "" : dr["no_ext"].ToString();
            cte.NoInt = dr["no_int"] == DBNull.Value ? "" : dr["no_int"].ToString();
            cte.Colonia = dr["colonia"] == DBNull.Value ? "" : dr["colonia"].ToString();
            cte.IdCiudad = dr["id_ciudad"] == DBNull.Value ? "" : dr["id_ciudad"].ToString();
            cte.CP = dr["cp"] == DBNull.Value ? "" : dr["cp"].ToString();
            cte.IdEstado = dr["id_estado"] == DBNull.Value ? "" : dr["id_estado"].ToString();
            cte.IdPais = dr["id_pais"] == DBNull.Value ? "" : dr["id_pais"].ToString();
            cte.Telefono = dr["telefono"] == DBNull.Value ? "" : dr["telefono"].ToString();
            cte.Giro = dr["giro"] == DBNull.Value ? "" : dr["giro"].ToString();
            cte.TiempoEstablecido = dr["tiempo_establecido"] == DBNull.Value ? "" : dr["tiempo_establecido"].ToString();
            cte.NumeroEmpleado = dr["numero_empleados"] == DBNull.Value ? 0 : Convert.ToInt32(dr["numero_empleados"]);
            cte.VentaAnual = dr["ventas_anuales"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["ventas_anuales"]);
            cte.PaginaWeb = dr["pagina_web"] == DBNull.Value ? "" : dr["pagina_web"].ToString();
            cte.PatentesOperacion = dr["patentes_operacion"] == DBNull.Value ? "" : dr["patentes_operacion"].ToString();
            cte.FrecuentaEmbarques = dr["frecuencia_embarques"] == DBNull.Value ? "" : dr["frecuencia_embarques"].ToString();
            cte.VucemCliente = dr["vucem_cliente"] == DBNull.Value ? false : Convert.ToBoolean(dr["vucem_cliente"]);
            cte.VucemGrupoei = dr["vucem_grupoei"] == DBNull.Value ? false : Convert.ToBoolean(dr["vucem_grupoei"]);
            cte.CorreosArriboEmbarque = dr["correos_arribo_embarque"] == DBNull.Value ? "" : dr["correos_arribo_embarque"].ToString();
            cte.Banco = dr["banco"] == DBNull.Value ? "" : dr["banco"].ToString();
            cte.NumeroCuenta = dr["numero_cuenta"] == DBNull.Value ? "" : dr["numero_cuenta"].ToString();
            cte.ClabeInterbancaria = dr["clabe_interbancaria"] == DBNull.Value ? "" : dr["clabe_interbancaria"].ToString();
            cte.Moneda = dr["moneda"] == DBNull.Value ? "" : dr["moneda"].ToString();
            cte.SucursalBanco = dr["sucursal_banco"] == DBNull.Value ? "" : dr["sucursal_banco"].ToString();
            cte.CiudadBanco = dr["ciudad_banco"] == DBNull.Value ? "" : dr["ciudad_banco"].ToString();
            cte.Certificacion = dr["certificacion1"] == DBNull.Value ? "" : dr["certificacion1"].ToString();
            cte.Certificacion2 = dr["certificacion2"] == DBNull.Value ? "" : dr["certificacion2"].ToString();
            cte.NumeroPuertos = dr["numero_puertos"] == DBNull.Value ? "" : dr["numero_puertos"].ToString();
            cte.ConCartaEncomiendaRespaldo = dr["con_carta_encomienda_respaldo"] == DBNull.Value ? false : Convert.ToBoolean(dr["con_carta_encomienda_respaldo"]);
            cte.MotivoSinCartaEncomiendaRespaldo = dr["motivo_sin_carta_encomienda_respaldo"] == DBNull.Value ? "" : dr["motivo_sin_carta_encomienda_respaldo"].ToString();
            cte.Banderilla = dr["banderilla"] == DBNull.Value ? false : Convert.ToBoolean(dr["banderilla"]);
            cte.Estatus = dr["estatus"] == DBNull.Value ? 0 : Convert.ToInt32(dr["estatus"]);
            //cte.AceptacionTerminosCondiciones = dr[""] == DBNull.Value ? false :  Convert.ToBoolean(dr["aceptacion_terminos_condiciones"]);
            cte.domicilio_fiscal_calle = dr["domicilio_fiscal_calle"] == DBNull.Value ? "" : dr["domicilio_fiscal_calle"].ToString();
            cte.domicilio_fiscal_ciudad = dr["domicilio_fiscal_ciudad"] == DBNull.Value ? "" : dr["domicilio_fiscal_ciudad"].ToString();
            cte.domicilio_fiscal_colonia = dr["domicilio_fiscal_colonia"] == DBNull.Value ? "" : dr["domicilio_fiscal_colonia"].ToString();
            cte.domicilio_fiscal_cp = dr["domicilio_fiscal_cp"] == DBNull.Value ? "" : dr["domicilio_fiscal_cp"].ToString();
            cte.domicilio_fiscal_estado = dr["domicilio_fiscal_estado"] == DBNull.Value ? "" : dr["domicilio_fiscal_estado"].ToString();
            cte.domicilio_fiscal_municipio = dr["domicilio_fiscal_municipio"] == DBNull.Value ? "" : dr["domicilio_fiscal_municipio"].ToString();
            cte.domicilio_fiscal_no_ext = dr["domicilio_fiscal_no_ext"] == DBNull.Value ? "" : dr["domicilio_fiscal_no_ext"].ToString();
            cte.domicilio_fiscal_no_int = dr["domicilio_fiscal_no_int"] == DBNull.Value ? "" : dr["domicilio_fiscal_no_int"].ToString();

            cte.Contacto = this.ObtieneContactosPorPrecliente(cte.IdPreCliente.ToString());
            cte.Cuenta = this.ObtenerCuentaPorPrecliente(cte.IdPreCliente.ToString());
            cte.Cuestionario = this.ObtenerCuestionarioCliente(cte.IdPreCliente.ToString());
            cte.Usuarios = new DxUsuarisoAudabook().GetByPreCliente(cte.IdPreCliente);
            cte.Documentos = new DocumentosClienteRepository().ObtieneDocPorPrecliente(cte.IdPreCliente);
            return cte;

        }

        public List<SeccionesDTO> ObtenerTituloSecciones(int idprecliente)
        {
            var dt = ObtenerDatosTituloSecciones(idprecliente);
            List<SeccionesDTO> cte = new List<SeccionesDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                SeccionesDTO aux = new SeccionesDTO();
                aux.titulo_seccion = dr["titulo_seccion"].ToString();
                cte.Add(aux);
            }
            return cte;
        }

        public DatosFinanciamientoDTO ObtienerFinanciamiento(int idprecliente)
        {
            DatosFinanciamientoDTO cte = new DatosFinanciamientoDTO();
            try {
                var dr = ObtenerDatosFinanciamiento(idprecliente).Rows[0];

                cte.monto = dr["monto"] == DBNull.Value ? "" : dr["monto"].ToString();
                cte.para_uso_en = dr["para_uso_en"] == DBNull.Value ? "" : dr["para_uso_en"].ToString();
                cte.punto_reorden = dr["punto_reorden"] == DBNull.Value ? "" : dr["punto_reorden"].ToString();
                cte.recuperacion = dr["recuperacion"] == DBNull.Value ? "" : dr["recuperacion"].ToString();
                cte.plazo = dr["plazo"] == DBNull.Value ? "" : dr["plazo"].ToString();
                cte.condiciones = dr["condiciones"] == DBNull.Value ? "" : dr["condiciones"].ToString();
                cte.con_financiamiento = dr["con_financiamiento"] == DBNull.Value ? "" : dr["con_financiamiento"].ToString();
                return cte;
            }
            catch(Exception ex)
            {
                cte.monto = "";
                cte.para_uso_en = "";
                cte.punto_reorden = "";
                cte.recuperacion = "";
                cte.plazo = "";
                cte.condiciones = "";
                cte.con_financiamiento = "";
                return cte;
            }
        }

        public List<CuentaDTO> ObtenerCuentaPorPrecliente(string idprecliente)
        {
            var dt = new CapturaClienteRepository().ObtenerCtasBancPECACliente(idprecliente);
            List<CuentaDTO> lista = new List<CuentaDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                CuentaDTO cta = new CuentaDTO();
                cta.Banco = dr["banco"].ToString();
                cta.NumeroCuenta = Convert.ToInt32(dr["numero_cuenta"]);
                cta.Identificador = dr["identificador"].ToString();
                cta.PatentesAutorizadas = dr["patentes_autorizadas"].ToString();
                cta.Aduana = dr["aduana"].ToString();
                cta.IdBanco = Convert.ToInt32(dr["id_banco"]);
                lista.Add(cta);
            }
            return lista;
        }

        public CuestionarioDTO ObtenerCuestionarioCliente(string idprecliente)
        {
            var dt = new CapturaClienteRepository().ObtenerCuestionarioCliente(idprecliente);
            CuestionarioDTO cuestionario = new CuestionarioDTO();
            foreach (DataRow dr in dt.Rows)
            {
                switch (Convert.ToInt32(dr["id_pregunta"]))
                {
                    case 1:
                        cuestionario.respuesta01 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion01 = dr["observacion"].ToString();
                        break;
                    case 2:
                        cuestionario.respuesta02 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion02 = dr["observacion"].ToString();
                        break;
                    case 3:
                        cuestionario.respuesta03 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion03 = dr["observacion"].ToString();
                        break;
                    case 4:
                        cuestionario.respuesta04 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion04 = dr["observacion"].ToString();
                        break;
                    case 5:
                        cuestionario.respuesta05 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion05 = dr["observacion"].ToString();
                        break;
                    case 6:
                        cuestionario.respuesta06 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion06 = dr["observacion"].ToString();
                        break;
                    case 7:
                        cuestionario.respuesta07 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion07 = dr["observacion"].ToString();
                        break;
                    case 8:
                        cuestionario.respuesta08 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion08 = dr["observacion"].ToString();
                        break;
                    case 9:
                        cuestionario.respuesta09 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion09 = dr["observacion"].ToString();
                        break;
                    case 10:
                        cuestionario.respuesta10 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion10 = dr["observacion"].ToString();
                        break;
                    case 11:
                        cuestionario.respuesta11 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion11 = dr["observacion"].ToString();
                        break;
                    case 12:
                        cuestionario.respuesta12 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion12 = dr["observacion"].ToString();
                        break;
                    case 13:
                        cuestionario.respuesta13 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion13 = dr["observacion"].ToString();
                        break;
                    case 14:
                        cuestionario.respuesta14 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion14 = dr["observacion"].ToString();
                        break;
                    case 15:
                        cuestionario.respuesta15 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion15 = dr["observacion"].ToString();
                        break;
                    case 16:
                        cuestionario.respuesta16 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion16 = dr["observacion"].ToString();
                        break;
                    case 17:
                        cuestionario.respuesta17 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion17 = dr["observacion"].ToString();
                        break;
                    case 18:
                        cuestionario.respuesta18 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion18 = dr["observacion"].ToString();
                        break;
                    case 19:
                        cuestionario.respuesta19 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion19 = dr["observacion"].ToString();
                        break;
                    case 20:
                        cuestionario.respuesta20 = dr["respuesta"].ToString().ToLower();
                        cuestionario.observacion20 = dr["observacion"].ToString();
                        break;
                }
            }
            return cuestionario;
        }

        public DataTable ObtenerDirecionCliente(int idPrecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idPrecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerDireccionCliente");
            return resultado;

        }

        public DataTable ObtenerRelacionPreclienteAprobador(int idPrecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idPrecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            parametro.Add(new SqlParameter
            {
                Value = 4,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_estatus"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerRelacionPreclienteAprobador");
            return resultado;
        }

        public DataTable ObtenerRelacionPreclienteAprobador(int idPrecliente, int idEstatus)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idPrecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            parametro.Add(new SqlParameter
            {
                Value = idEstatus,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_estatus"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerRelacionPreclienteAprobador");
            return resultado;
        }

        public int? ActualizarEstatus(int idusuario, int nuevoestatus)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idusuario,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_usuario"
            });

            parametro.Add(new SqlParameter
            {
                Value = nuevoestatus,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@nuevo_estatus"
            });

            var resultado = NoQuery(parametro, "dbo.csp_CLI_ActualizarNuevoEstatus");
            return resultado;
        }

        public DataTable ObtieneTabsPrecliente(int idPrecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idPrecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_TabuladoresPrecliente");
            return resultado;
        }

        public DataTable ObtenerListaSoloPreclientes()
        {
            var parametro = new List<SqlParameter>();

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerSoloPreclientes");
            return resultado;
        }

        public DataTable ObtenerListaSoloClientes()
        {
            var parametro = new List<SqlParameter>();

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerSoloClientes");
            return resultado;
        }
    }
}
