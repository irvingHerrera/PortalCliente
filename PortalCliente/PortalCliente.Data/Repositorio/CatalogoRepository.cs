using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PortalCliente.Data.BD;
using PortalCliente.Data.Interfaz;

namespace PortalCliente.Data.Repositorio
{
    public class CatalogoRepository : DataBaseAcces, ICatalogoRepository
    {
        public DataTable ObtenerCiudad(string IdEstado)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = IdEstado,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@id_estado"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerCiudades");
            return resultado;
        }

        public DataTable ObtenerEstado(string IdPais)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = IdPais,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@id_pais"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerEstados");
            return resultado;
        }

        public DataTable ObtenerPais()
        {  
            var resultado = Select(new List<SqlParameter>(), "dbo.csp_CLI_ObtenerPaises");
            return resultado;
        }

        public DataTable ObtenerAduanas()
        {
            var parametro = new List<SqlParameter>();

            var resultado = Select(parametro, "ELI..CSP_VER_LISTADO_ADUANAS");
            return resultado;
        }

        public DataTable ObtenerClavePedimento()
        {
            var parametro = new List<SqlParameter>();

            var resultado = Select(parametro, "ELI..CSP_VER_LISTADO_CLAVE_PEDIMENTO");
            return resultado;
        }

        public DataTable ObtenerConceptoFacturacion(string empresa)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = empresa,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@empresa"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerCatalogoConceptosFacturacion");
            return resultado;
        }

        public DataTable ObtenerConceptoAutoFacturacion()
        {
            var parametro = new List<SqlParameter>();

            var resultado = Select(parametro, "dbo.csp_CLI_ObtenerCatalogoConceptosAutoFacturacion");
            return resultado;
        }
    }
}
