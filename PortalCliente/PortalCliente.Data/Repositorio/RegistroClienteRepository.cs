using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
    public class RegistroClienteRepository : DataBaseAcces, IRegistroClienteRepository
    {
        public RegistroClienteRepository()
        {

        }

        #region MetodosPrivados

        private DataTable TablaCliente(ClienteDTO cliente)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("id_precliente");
            tabla.Columns.Add("representante_legal");
            tabla.Columns.Add("nombre_fiscal");
            tabla.Columns.Add("rfc");
            tabla.Columns.Add("nombre_comercial");
            tabla.Columns.Add("calle");
            tabla.Columns.Add("no_ext");
            tabla.Columns.Add("no_int");
            tabla.Columns.Add("colonia");
            tabla.Columns.Add("id_ciudad");
            tabla.Columns.Add("cp");
            tabla.Columns.Add("id_estado");
            tabla.Columns.Add("id_pais");
            tabla.Columns.Add("telefono");
            tabla.Columns.Add("banco");
            tabla.Columns.Add("numero_cuenta");
            tabla.Columns.Add("clabe_interbancaria");
            tabla.Columns.Add("moneda");
            tabla.Columns.Add("sucursal_banco");
            tabla.Columns.Add("ciudad_banco");
            tabla.Columns.Add("estatus");
            tabla.Columns.Add("aceptacion_terminos_condiciones");
            tabla.Columns.Add("fecha_modificacion", typeof(DateTime));
            tabla.Columns.Add("usuario_modificacion");

            var fila = tabla.NewRow();

            fila["id_precliente"] = cliente.IdPreCliente;
            fila["representante_legal"] = cliente.RepresentanteLegal;
            fila["nombre_fiscal"] = cliente.NombreFiscal;
            fila["rfc"] = cliente.RFC;
            fila["nombre_comercial"] = cliente.NombreComercial;
            fila["calle"] = cliente.Calle;
            fila["no_ext"] = cliente.NoExt;
            fila["no_int"] = cliente.NoInt;
            fila["colonia"] = cliente.Colonia;
            fila["id_ciudad"] = cliente.IdCiudad;
            fila["cp"] = cliente.CP;
            fila["id_estado"] = cliente.IdEstado;
            fila["id_pais"] = cliente.IdPais;
            fila["telefono"] = cliente.Telefono;
            fila["banco"] = cliente.Banco;
            fila["numero_cuenta"] = cliente.NumeroCuenta;
            fila["clabe_interbancaria"] = cliente.ClabeInterbancaria;
            fila["moneda"] = cliente.Moneda;
            fila["sucursal_banco"] = cliente.SucursalBanco;
            fila["ciudad_banco"] = cliente.CiudadBanco;
            fila["aceptacion_terminos_condiciones"] = cliente.AceptacionTerminosCondiciones;
            fila["fecha_modificacion"] = DateTime.Now.ToString();
            fila["usuario_modificacion"] = cliente.UsuarioModificacion;
            tabla.Rows.Add(fila);

            return tabla;
        }

        private DataTable TablaCuenta(List<CuentaDTO> cuenta, int IDPrecliente)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("id_precliente");
            tabla.Columns.Add("banco");
            tabla.Columns.Add("numero_cuenta");
            tabla.Columns.Add("identificador");
            tabla.Columns.Add("patentes_autorizadas");
            tabla.Columns.Add("aduana");
            tabla.Columns.Add("fecha_creacion", typeof(DateTime));
            tabla.Columns.Add("usuario_creacion");
            tabla.Columns.Add("fecha_modificacion", typeof(DateTime));
            tabla.Columns.Add("usuario_modificacion");

            foreach (var item in cuenta)
            {
                var fila = tabla.NewRow();
                fila["id_precliente"] = IDPrecliente;
                fila["banco"] = item.Banco;
                fila["numero_cuenta"] = item.NumeroCuenta;
                fila["identificador"] = item.Identificador;
                fila["patentes_autorizadas"] = item.PatentesAutorizadas;
                fila["aduana"] = item.Aduana;
                fila["fecha_creacion"] = DateTime.Now.ToString();
                fila["usuario_creacion"] = item.UsuarioCreacion;
                fila["fecha_modificacion"] = DateTime.Now.ToString();
                fila["usuario_modificacion"] = item.UsuarioModificacion;
                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        private DataTable TablaContacto(List<ContactoDTO> contacto, int IDPrecliente)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("id_precliente");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("correo");
            tabla.Columns.Add("telefono");
            tabla.Columns.Add("area");
            tabla.Columns.Add("puesto_departamento");
            tabla.Columns.Add("fecha_creacion", typeof(DateTime));
            tabla.Columns.Add("usuario_creacion");
            tabla.Columns.Add("fecha_modificacion", typeof(DateTime));
            tabla.Columns.Add("usuario_modificacion");

            foreach (var item in contacto)
            {
                var fila = tabla.NewRow();
                fila["id_precliente"] = IDPrecliente;
                fila["nombre"] = item.Nombre;
                fila["correo"] = item.Correo;
                fila["telefono"] = item.Telefono;
                fila["area"] = item.Area;
                fila["puesto_departamento"] = item.PuestoDepartamento;
                fila["fecha_creacion"] = DateTime.Now.ToString();
                if(item.UsuarioCreacion == null)
                {
                    item.UsuarioCreacion = "test";
                }
                fila["usuario_creacion"] = item.UsuarioCreacion;
                fila["fecha_modificacion"] = DateTime.Now.ToString();
                fila["usuario_modificacion"] = item.UsuarioModificacion;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        #endregion

        public int? GuardarDatoCliente(ClienteDTO cliente)
        {
            var parametro = new List<SqlParameter>();

            var tClinte = TablaCliente(cliente);
            var tCuenta = TablaCuenta(cliente.Cuenta, cliente.IdPreCliente);
            var tConctacto = TablaContacto(cliente.Contacto, cliente.IdPreCliente);

            parametro.Add(new SqlParameter
            {
                Value = tClinte,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@cliente"
            });
            parametro.Add(new SqlParameter
            {
                Value = tConctacto,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@contacto"
            });
            parametro.Add(new SqlParameter
            {
                Value = tCuenta,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@cuenta"
            });

            var resultado = ExecuteNoQuery(parametro, "dbo.tblCLI_GuardarDatoCliente_SP");
            return resultado;
        }

        public int? GuardarCuestionario(CuestionarioDTO cuestionario)
        {
            try
            {
                var parametro = new List<SqlParameter>();

                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.id_precliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.id_usuario,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_usuario"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta01,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta01"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta02,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta02"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta03,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta03"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta04,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta04"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta05,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta05"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta06,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta06"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta07,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta07"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta08,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta08"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta09,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta09"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta10,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta10"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta11,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta11"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta12,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta12"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta13,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta13"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta14,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta14"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta15,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta15"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta16,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta16"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta17,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta17"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta18,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta18"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta19,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta19"
                });
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.respuesta20,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@respuesta20"
                });
                if (cuestionario.observacion01 == null)
                    cuestionario.observacion01 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion01,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion01"
                });
                if (cuestionario.observacion02 == null)
                    cuestionario.observacion02 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion02,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion02"
                });
                if (cuestionario.observacion03 == null)
                    cuestionario.observacion03 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion03,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion03"
                });
                if (cuestionario.observacion04 == null)
                    cuestionario.observacion04 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion04,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion04"
                });
                if (cuestionario.observacion05 == null)
                    cuestionario.observacion05 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion05,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion05"
                });
                if (cuestionario.observacion06 == null)
                    cuestionario.observacion06 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion06,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion06"
                });
                if (cuestionario.observacion07 == null)
                    cuestionario.observacion07 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion07,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion07"
                });
                if (cuestionario.observacion08 == null)
                    cuestionario.observacion08 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion08,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion08"
                });
                if (cuestionario.observacion09 == null)
                    cuestionario.observacion09 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion09,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion09"
                });
                if (cuestionario.observacion10 == null)
                    cuestionario.observacion10 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion10,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion10"
                });
                if (cuestionario.observacion11 == null)
                    cuestionario.observacion11 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion11,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion11"
                });
                if (cuestionario.observacion12 == null)
                    cuestionario.observacion12 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion12,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion12"
                });
                if (cuestionario.observacion13 == null)
                    cuestionario.observacion13 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion13,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion13"
                });
                if (cuestionario.observacion14 == null)
                    cuestionario.observacion14 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion14,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion14"
                });
                if (cuestionario.observacion15 == null)
                    cuestionario.observacion15 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion15,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion15"
                });
                if (cuestionario.observacion16 == null)
                    cuestionario.observacion16 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion16,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion16"
                });
                if (cuestionario.observacion17 == null)
                    cuestionario.observacion17 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion17,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion17"
                });
                if (cuestionario.observacion18 == null)
                    cuestionario.observacion18 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion18,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion18"
                });
                if (cuestionario.observacion19 == null)
                    cuestionario.observacion19 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion19,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion19"
                });
                if (cuestionario.observacion20 == null)
                    cuestionario.observacion20 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.observacion20,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observacion20"
                });
                if (cuestionario.certificacion1 == null)
                    cuestionario.certificacion1 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.certificacion1,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@certificacion1"
                });
                if (cuestionario.certificacion2 == null)
                    cuestionario.certificacion2 = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.certificacion2,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@certificacion2"
                });
                if (cuestionario.numero_puertos == null)
                    cuestionario.numero_puertos = "";
                parametro.Add(new SqlParameter
                {
                    Value = cuestionario.numero_puertos,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@numero_puertos"
                });
                var resultado = NoQuery(parametro, "csp_CLI_GuardarCuestionarioSeguridad");
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? CerrarPrecliente(int id_usuario, bool con_carta_encomienda, string motivo_sin_carta_encomienda)
        {
            try
            {
                var parametro = new List<SqlParameter>();

                parametro.Add(new SqlParameter
                {
                    Value = id_usuario,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_usuario"
                });

                parametro.Add(new SqlParameter
                {
                    Value = false,
                    SqlDbType = SqlDbType.Bit,
                    ParameterName = "@banderilla"
                });

                parametro.Add(new SqlParameter
                {
                    Value = con_carta_encomienda,
                    SqlDbType = SqlDbType.Bit,
                    ParameterName = "@con_carta_encomienda"
                });

                parametro.Add(new SqlParameter
                {
                    Value = motivo_sin_carta_encomienda,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@motivo_sin_carta_encomienda"
                });

                var resultado = NoQuery(parametro, "csp_CLI_ActualizarBanderilla");
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        ClienteDTO IRegistroClienteRepository.ObtenerDatoCliente()
        {
            throw new System.NotImplementedException();
        }

        /*Métodos para obtener paises, estados y ciudades*/
        public DataTable ObtenerPaises()
        {
            var resultado = Select(new List<SqlParameter>(), "dbo.csp_cli_obtenerpaises");
            return resultado;
        }

        public DataTable ObtenerEstados(string id_pais)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_pais,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@id_pais"
            });
            var resultado = Select(parametro, "dbo.csp_cli_obtenerestados");
            return resultado;
        }

        public DataTable ObtenerCiudades(string id_estado)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_estado,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@id_estado"
            });
            var resultado = Select(parametro, "dbo.csp_cli_obtenerciudades");
            return resultado;
        }
        /*********************************************************/

        public int? GuardarCamposCartaEnc(
            string id_usuario,
            string domicilio_fiscal_calle,
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
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_usuario,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@id_usuario"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_calle,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_calle"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_ciudad,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_ciudad"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_colonia,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_colonia"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_cp,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_cp"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_estado,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_estado"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_municipio,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_municipio"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_no_ext,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_no_ext"
            });

            parametro.Add(new SqlParameter
            {
                Value = domicilio_fiscal_no_int,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@domicilio_fiscal_no_int"
            });

            parametro.Add(new SqlParameter
            {
                Value = numero_escritura,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@numero_escritura"
            });

            parametro.Add(new SqlParameter
            {
                Value = nombre_notario,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@nombre_notario"
            });

            parametro.Add(new SqlParameter
            {
                Value = numero_notaria,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@numero_notaria"
            });

            parametro.Add(new SqlParameter
            {
                Value = ciudad_notariado,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@ciudad_notariado"
            });

            parametro.Add(new SqlParameter
            {
                Value = estado_notariado,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@estado_notariado"
            });

            parametro.Add(new SqlParameter
            {
                Value = membrete_empresa,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@membrete_empresa"
            });

            parametro.Add(new SqlParameter
            {
                Value = periodo_compredido_inicio,
                SqlDbType = SqlDbType.DateTime,
                ParameterName = "@periodo_compredido_inicio"
            });

            parametro.Add(new SqlParameter
            {
                Value = periodo_compredido_fin,
                SqlDbType = SqlDbType.DateTime,
                ParameterName = "@periodo_compredido_fin"
            });

            parametro.Add(new SqlParameter
            {
                Value = patente_carta_encomienda,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@patente_carta_encomienda"
            });
            var resultado = ExecuteNoQuery(parametro, "dbo.csp_CLI_ActualizarCartaEncomienda");
            return resultado;
        }

        public DataTable ObtenerPatentes()
        {
            var resultado = Select(new List<SqlParameter>(), "dbo.csp_CLI_ObtenerPatentes");
            return resultado;
        }

        public DataTable ObtenerDatosCartaEnc(int id_usuario)
        {
            var parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter
            {
                Value = id_usuario,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_usuario"
            });
            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerInfoCartaEncomienda");
            return resultado;
        }
        //
    }
}
