using PortalCliente.Data.BD;
using PortalCliente.Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
    public class ImpresionRepository : DataBaseAcces, IImpresionRepository
    {
        public DataTable ObtenerExpedienteCliente(int idPrecliente)
        {
            var parametro = new List<SqlParameter>();

            try
            {
                parametro.Add(new SqlParameter
                {
                    Value = idPrecliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });

                var resultado = Select(parametro, "dbo.csp_CLI_ObtenerDocumentoExpediente");
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
