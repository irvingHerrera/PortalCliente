using PortalCliente.Data.BD;
using PortalCliente.Data.Interfaz;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
    public class NotificacionRepository : DataBaseAcces, INotificacionRepository
    {
        public int? ActualizarEstatusTerminoCondicion(int idPreCliente, bool estatusTerminoCondicion)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idPreCliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            parametro.Add(new SqlParameter
            {
                Value = estatusTerminoCondicion,
                SqlDbType = SqlDbType.Bit,
                ParameterName = "@aceptacion_terminos_condiciones"
            });

            var resultado = NoQuery(parametro, "dbo.csp_CLI_ActualizarValorTerminosCondiciones");
            return resultado;
        }

        public DataTable ObtenerEstatusTerminoCondicion(int idUsuario)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idUsuario,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_usuario"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerEstatusTerminosCondiciones");
            return resultado;
        }

        public DataTable ObtenerNotificacion(int idUsuario, int idRol)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idUsuario,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_usuario"
            });

            parametro.Add(new SqlParameter
            {
                Value = idRol,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_rol"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerNotificacionesUsuario");
            return resultado;
        }

        public int? EnvioCorreoNotificacion(int idPrecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = idPrecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@IdPrecliente"
            });
            
            var resultado = ExecuteNoQuery(parametro, "dbo.csp_CLI_EnvioNotificacion");
            return resultado;
        }

        //
    }
}
