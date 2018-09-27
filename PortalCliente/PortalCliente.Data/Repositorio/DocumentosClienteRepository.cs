using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortalCliente.Data.Repositorio
{
	public class DocumentosClienteRepository : DataBaseAcces
	{

		private DataTable TablaDocumentos(ExDocumentos exDocumentos)
		{
			var tabla = new DataTable();

			tabla.Columns.Add("id_documento_cliente");
			tabla.Columns.Add("id_documento");
			tabla.Columns.Add("id_precliente");
			tabla.Columns.Add("activo");
			tabla.Columns.Add("ruta_local");
			tabla.Columns.Add("fecha_creacion",typeof(DateTime));
			tabla.Columns.Add("usuario_creacion");
			tabla.Columns.Add("fecha_modificacion", typeof(DateTime));
			tabla.Columns.Add("usuario_modificacion");
			tabla.Columns.Add("motivo_sin_carta_encomienda_respaldo");
			
			var fila = tabla.NewRow();

			fila["id_documento"] = exDocumentos.id_documento;
			fila["id_precliente"] = exDocumentos.id_precliente;
			fila["activo"] = exDocumentos.activo;
			fila["ruta_local"] = exDocumentos.ruta_local;
			fila["fecha_creacion"] = exDocumentos.fecha_creacion;
			fila["usuario_creacion"] = exDocumentos.usuario_creacion;
			fila["fecha_modificacion"] = exDocumentos.fecha_modificacion;
			fila["usuario_modificacion"] = exDocumentos.usuario_modificacion;
			fila["id_documento_cliente"] = 0;
			fila["motivo_sin_carta_encomienda_respaldo"] = DBNull.Value;



			tabla.Rows.Add(fila);

			return tabla;
		}

		public int? guardaDocumento(ExDocumentos exDocumentos)
		{
			var parametro = new List<SqlParameter>();
			var tDocumentos = TablaDocumentos(exDocumentos);
			parametro.Add(new SqlParameter
			{
				Value = tDocumentos,
				SqlDbType = SqlDbType.Structured,
				ParameterName = "@documento"
			});

			var resultado = ExecuteNoQuery(parametro, "dbo.tblCLI_GuardarDocumentoCliente_SP");
			return resultado;
		}

		public List<ExDocumentos> ObtieneDocPorPrecliente(int idprecliente)
		{
			try
			{
				
				
				string _path = @"\Documentos\" + idprecliente.ToString() + @"\";
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = idprecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idprecliente" });

				List<ExDocumentos> documentos = new List<ExDocumentos>();
				DataTable dt = Select(parametros, "csp_CLI_ObtieneDocumentos_SP");
				foreach (DataRow dr in dt.Rows)
				{
					ExDocumentos doc = new ExDocumentos();
					doc.id_documento = Convert.ToInt32(dr["id_documento"]);
					doc.ruta_local = dr["ruta_local"].ToString();
					doc.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					doc.usuario_creacion = dr["usuario_creacion"].ToString();
					doc.fecha_modificacion =  Convert.ToDateTime(dr["fecha_modificacion"]);
					doc.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
					//doc.ruta_local = siguienteString(doc.ruta_local, _path);
					documentos.Add(doc);
				}
				return documentos;
			}
			catch (Exception ex)
			{
				throw ex; 
			}
		}

		public List<string> DocumentosCargadosPorPrecliente(int id,bool CartaEncomiendaRespaldo, string mensaje)
		{
			try
			{
				if (CartaEncomiendaRespaldo)
				{
					    
				}
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idprecliente" });
				DataTable dt = Select(parametros, "csp_CLI_ObtieneDocumentosCargados");
				List<string> documentos = new List<string>();
				foreach (DataRow dr in dt.Rows)
				{
					documentos.Add(dr["descripcion"].ToString() + "|" + dr["id"].ToString());
				}
				return documentos;
			}
			catch (Exception ex)
			{
				throw ex; 
			}
		}

        public List<string> DesactivarDocumentos(int id_precliente, int tipo_documento)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter { Value = id_precliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@IDPrecliente" });
                parametros.Add(new SqlParameter { Value = tipo_documento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@TipoDocumento" });

                DataTable dt = Select(parametros, "csp_CLI_DesactivarDocumentos");
                List<string> documentos = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    documentos.Add(dr["SALIDA"].ToString());
                }
                return documentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> BuscarTodosDocumentos(int id_precliente, int tipo_documento)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter { Value = id_precliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@IDPrecliente" });
                parametros.Add(new SqlParameter { Value = tipo_documento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@TipoDocumento" });

                DataTable dt = Select(parametros, "csp_CLI_BuscarTodosDocumentos");
                List<string> documentos = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    documentos.Add(dr["Nombre"].ToString());
                    documentos.Add(dr["Ruta"].ToString());
                }
                return documentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string siguienteString(string original, string buscar)
		{
			int index = original.IndexOf(buscar);
			if (index >= 0)
			{
				index += buscar.Length;
			}
			return original.Substring(index, original.Length - index);
		}

	}
}
