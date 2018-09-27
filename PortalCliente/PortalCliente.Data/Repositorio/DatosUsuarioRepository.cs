using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalCliente.Data.ENT;
using System.Data.SqlClient;
using System.Data;
using PortalCliente.Data.BD;
using PortalCliente.Data.Interfaz;

namespace PortalCliente.Data.Repositorio
{
    public class DatosUsuarioRepository: DataBaseAcces, IDatosUsuarioRepository
	{
        public DataTable ObtenerDatosUsuario(string usuario)
        {
            try
            {
                var parametro = new List<SqlParameter>();

                parametro.Add(new SqlParameter
                {
                    Value = usuario,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@usuario"
                });

                var resultado = Select(parametro, "csp_CLI_ObtenerDatosUsuario");
                return resultado;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable ValidarLogin(string usuario, string password)
        {
            try
            {
                var parametro = new List<SqlParameter>();

                parametro.Add(new SqlParameter
                {
                    Value = usuario,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@usuario"
                });

                parametro.Add(new SqlParameter
                {
                    Value = password,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@contrasenia"
                });

                var resultado = Select(parametro, "csp_CLI_ValidaLogin");
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
