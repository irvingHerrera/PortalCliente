using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
    public class AltaClienteRepository : DataBaseAcces, IAltaClienteRepository
    {
        public int? GuardarExpediente(int idPrecliente, string rutaExpediente, string usuarioCreacion)
        {
            var parametro = new List<SqlParameter>();

            try
            {
                parametro.Add(new SqlParameter
                {
                    Value = rutaExpediente,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@ruta"
                });

                parametro.Add(new SqlParameter
                {
                    Value = idPrecliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });

                parametro.Add(new SqlParameter
                {
                    Value = usuarioCreacion,
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = "@usuario_creacion"
                });

                var resultado = ExecuteNoQuery(parametro, "dbo.csp_GuardarExpedienteCliente_SP");
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GuardarSistemasOperativos(SistemasOperativosDTO modelo)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = modelo.ID_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@ID_precliente"
            });
            parametro.Add(new SqlParameter
            {
                Value = modelo.ADUASIS,
                SqlDbType = SqlDbType.Bit,
                ParameterName = "@ADUASIS"
            });
            parametro.Add(new SqlParameter
            {
                Value = modelo.GP,
                SqlDbType = SqlDbType.Bit,
                ParameterName = "@GP"
            });
            parametro.Add(new SqlParameter
            {
                Value = modelo.Equipo,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@Equipo"
            });
            parametro.Add(new SqlParameter
            {
                Value = modelo.Correos,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@Correos"
            });

            var resultado = Select(parametro, "dbo.csp_tblCLI_GuardarSistemasOperativos");
            return resultado;
        }
    }
}
