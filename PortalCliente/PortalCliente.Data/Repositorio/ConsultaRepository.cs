using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;

namespace PortalCliente.Data.Repositorio
{
    public class ConsultaRepository : DataBaseAcces, IConsultaRepository
    {
        public DataTable ObtenerListaPreclientesPendientes()
        {
            var parametro = new List<SqlParameter>();
            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerPreclientesPendientes");
            return resultado;
        }

        public DataTable ObtenerInfoTabuladoresTEMP(int id_precliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.sp_ObtenerInfoTabuladores");
            return resultado;
        }

        public DataTable ObtenerAprobacionDePreAltaCliente(int id_precliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerAprobacionDePreAltaCliente");
            return resultado;
        }

        public DataTable ObtenerAprobacionDeAltaCliente(int id_precliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerAprobacionDeAltaCliente");
            return resultado;
        }

        
    }
}
