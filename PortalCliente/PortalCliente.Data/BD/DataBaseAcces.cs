using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.BD
{
	public class DataBaseAcces
	{
		private string StrConection { get { return ConfigurationManager.AppSettings["BD"].ToString(); } }


		/// <summary>
		/// Select  
		/// </summary>
		/// <param name="parametros">IList SqlParameter</param>
		/// <param name="nombreSP">String Nombre SP</param>
		/// <returns>DataTable</returns>
		protected DataTable Select(List<SqlParameter> parametros, string nombreSP)
		{
			try
			{
				SqlConnection conn = new SqlConnection(StrConection);
				conn.Open();
				SqlCommand cmd = new SqlCommand(nombreSP);
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				foreach (SqlParameter p in parametros)
					cmd.Parameters.Add(p);
				SqlDataAdapter theAdapter = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				theAdapter.Fill(dt);
				conn.Close();
				conn.Dispose();
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// ejecuta no query con parametros 
		/// </summary>
		/// <param name="parametros">IList SqlParameter</param>
		/// <param name="nombreSP">string NombreSP</param>
		/// <returns>int?</returns>
		protected int? NoQuery(List<SqlParameter> parametros, string nombreSP)
		{
			try
			{
				SqlConnection conn = new SqlConnection(StrConection);
				conn.Open();
				SqlCommand cmd = new SqlCommand(nombreSP);
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				foreach (SqlParameter p in parametros)
					cmd.Parameters.Add(p);
				object resultado = cmd.ExecuteScalar();
				conn.Close();
				conn.Dispose();
				if (resultado != null)
					return (int)resultado;
				else
					return (int?)null;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Ejecuta No Query sin parametros 
		/// </summary>
		/// <param name="nombreSP">nombre del store procedure</param>
		/// <returns>int?</returns>
		protected int? NoQuery(string nombreSP)
		{
			try
			{
				SqlConnection conn = new SqlConnection(StrConection);
				conn.Open();
				SqlCommand cmd = new SqlCommand(nombreSP);
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				object resultado = cmd.ExecuteScalar();
				conn.Close();
				conn.Dispose();
				if (resultado != null)
					return (int)resultado;
				else
					return (int?)null;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        protected int? ExecuteNoQuery(List<SqlParameter> parametros, string nombreSP)
        {
            try
            {
                SqlConnection conn = new SqlConnection(StrConection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(nombreSP);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parametros)
                    cmd.Parameters.Add(p);
                object resultado = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                if (resultado != null)
                    return (int)resultado;
                else
                    return (int?)null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
