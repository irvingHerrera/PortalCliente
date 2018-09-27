using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PortalCliente.Data.BD;
using PortalCliente.Data.Interfaz;

namespace PortalCliente.Data.Repositorio
{
    public class ConfiguracionRepository : DataBaseAcces, IConfiguracionRepository
    {
        public DataTable ObtenerEquipoOperativo()
        {
            var resultado = Select(new List<SqlParameter>(), "dbo.csp_CLI_ObtenerEquipoOperativo");
            return resultado;
        }
    }
}
