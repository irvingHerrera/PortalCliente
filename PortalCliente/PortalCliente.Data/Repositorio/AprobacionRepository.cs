using PortalCliente.Data.BD;
using PortalCliente.Data.Interfaz;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
    public class AprobacionRepository : DataBaseAcces, IAprobacionRepository
    {
        public int? AprobadoSinProcedimientoPreAlta(int idPrecliente, int idUsuario, int idEstatus, string observacion)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = 1, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOpcion" });
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idusuario" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idprecliente" });
                parametros.Add(new SqlParameter { Value = idEstatus, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idestatus" });
                parametros.Add(new SqlParameter { Value = observacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@observaciones" });
                NoQuery(parametros, "csp_CLI_AprobacionCliente ");
                return (int?)null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int? NoAprobado(int idPrecliente, int idUsuario, int idEstatus, string observacion)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = 2, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOpcion" });
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idusuario" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idprecliente" });
                parametros.Add(new SqlParameter { Value = idEstatus, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idestatus" });
                parametros.Add(new SqlParameter { Value = observacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@observaciones" });
                NoQuery(parametros, "csp_CLI_AprobacionCliente ");
                return (int?)null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public int? PreAltaRevalidacion(int idUsuario, int idPrecliente, int idEstatus, string observacion)
        {
            try
            {
                if (observacion == null)
                {
                    observacion = "";
                }
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_precliente" });
                parametros.Add(new SqlParameter { Value = idEstatus, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@nuevo_estatus" });
                parametros.Add(new SqlParameter { Value = observacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@observaciones" });
                var resultado = ExecuteNoQuery(parametros, "dbo.csp_CLI_AprobacionPreAltaRevalidacion");
                return resultado;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public int? RealizarAprobacion(int idUsuario, int idPrecliente, int estatusCliente)
        {
            var parametro = new List<SqlParameter>();

            try
            {
                parametro.Add(new SqlParameter
                {
                    Value = idUsuario,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_usuario"
                });

                parametro.Add(new SqlParameter
                {
                    Value = idPrecliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });

                parametro.Add(new SqlParameter
                {
                    Value = estatusCliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@nuevo_estatus"
                });

                parametro.Add(new SqlParameter
                {
                    Value = string.Empty,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observaciones "
                });

                var resultado = ExecuteNoQuery(parametro, "dbo.csp_CLI_ActualizarEstatusAprobacionRevalidacion");
                return resultado;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public int? RealizarRevalidacion(int idUsuario, int idPrecliente, int estatusCliente, string observacion)
        {
            var parametro = new List<SqlParameter>();

            try
            {
                parametro.Add(new SqlParameter
                {
                    Value = idUsuario,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_usuario"
                });

                parametro.Add(new SqlParameter
                {
                    Value = idPrecliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });

                parametro.Add(new SqlParameter
                {
                    Value = estatusCliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@nuevo_estatus"
                });

                parametro.Add(new SqlParameter
                {
                    Value = observacion,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@observaciones "
                });

                var resultado = ExecuteNoQuery(parametro, "dbo.csp_CLI_ActualizarEstatusAprobacionRevalidacion");
                return resultado;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public DataTable ObtenerInfoActCliente(int idPrecliente, int idUsuario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_cliente" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                var resultado = Select(parametros, "dbo.sp_obtenerinfo_actcte");
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerTabuladores(int idPrecliente, int idUsuario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_cliente" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                var resultado = Select(parametros, "dbo.sp_obtenerTabuladores");
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerEmpTabulador1(int idPrecliente, int idUsuario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_cliente" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                var resultado = Select(parametros, "dbo.sp_obtenerEmpTabulador1");
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerContactoInfFin(int idPrecliente, int idUsuario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_cliente" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                var resultado = Select(parametros, "dbo.sp_obtenerContactoInfFin");
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerTarifaServicio(int idPrecliente, int idUsuario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_cliente" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                var resultado = Select(parametros, "dbo.sp_obtenerTarifaServicio");
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerContactosEI(int idPrecliente, int idUsuario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = idPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_cliente" });
                parametros.Add(new SqlParameter { Value = idUsuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@id_usuario" });
                var resultado = Select(parametros, "dbo.sp_obtenerContactosGrupoEI");
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int? EliminaActulizaTemporal(string idUsuario, int idPrecliente)
        {
            var parametro = new List<SqlParameter>();

            try
            {
                parametro.Add(new SqlParameter
                {
                    Value = idUsuario,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_usuario"
                });

                parametro.Add(new SqlParameter
                {
                    Value = idPrecliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });

                var resultado = ExecuteNoQuery(parametro, "dbo.csp_CLI_ElimnaActualizaTemporales");
                return resultado;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
