using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;

namespace PortalCliente.Data.DAC
{
	public class DxTabuladorProcOpCats : DataBaseAcces
	{
		public List<ExApliacacionPreferencia> GetApliacacionPreferencia()
		{
			try
			{
				List<ExApliacacionPreferencia> Listitems = new List<ExApliacacionPreferencia>();
				List<SqlParameter> lista = new List<SqlParameter>();
				DataTable dt = Select(lista, "csp_CLI_ApliacacionPreferencia");
				foreach (DataRow dr in dt.Rows)
				{
					ExApliacacionPreferencia item = new ExApliacacionPreferencia();
					item.Id = Convert.ToInt32(dr["Id"]);
					item.Clave = dr["Clave"] == DBNull.Value ? (string)null : dr["Clave"].ToString();
					item.Descripcion = dr["Descripcion"] == DBNull.Value ? (string)null : dr["Descripcion"].ToString();
					Listitems.Add(item);
				}
				return Listitems;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExFormaPago> GetFormaPago()
		{
			try
			{
				List<ExFormaPago> Listitems = new List<ExFormaPago>();
				List<SqlParameter> lista = new List<SqlParameter>();
				DataTable dt = Select(lista, "csp_CLI_FormaPago");
				foreach (DataRow dr in dt.Rows)
				{
					ExFormaPago item = new ExFormaPago();
					item.Id = Convert.ToInt32(dr["Id"]);
					item.Clave = dr["Clave"] == DBNull.Value ? (string)null : dr["Clave"].ToString();
					item.Descripcion = dr["Descripcion"] == DBNull.Value ? (string)null : dr["Descripcion"].ToString();
					Listitems.Add(item);
				}
				return Listitems;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExIncoterm> GetIncoterm()
		{
			try
			{
				List<ExIncoterm> Listitems = new List<ExIncoterm>();
				List<SqlParameter> lista = new List<SqlParameter>();
				DataTable dt = Select(lista, "csp_CLI_Incoterm");
				foreach (DataRow dr in dt.Rows)
				{
					ExIncoterm item = new ExIncoterm();
					item.Id = Convert.ToInt32(dr["Id"]);
					item.Clave = dr["Clave"] == DBNull.Value ? (string)null : dr["Clave"].ToString();
					item.Descripcion = dr["Descripcion"] == DBNull.Value ? (string)null : dr["Descripcion"].ToString();
					Listitems.Add(item);
				}
				return Listitems;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExMetodoValoracion> GetMetodoValoracion()
		{
			try
			{
				List<ExMetodoValoracion> Listitems = new List<ExMetodoValoracion>();
				List<SqlParameter> lista = new List<SqlParameter>();
				DataTable dt = Select(lista, "csp_CLI_MetodoValoracion");
				foreach (DataRow dr in dt.Rows)
				{
					ExMetodoValoracion item = new ExMetodoValoracion();
					item.Id = Convert.ToInt32(dr["Id"]);
					item.Clave = dr["Clave"] == DBNull.Value ? (string)null : dr["Clave"].ToString();
					item.Descripcion = dr["Descripcion"] == DBNull.Value ? (string)null : dr["Descripcion"].ToString();
					Listitems.Add(item);
				}
				return Listitems;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExRegimen> GetRegimen()
		{
			try
			{
				List<ExRegimen> Listitems = new List<ExRegimen>();
				List<SqlParameter> lista = new List<SqlParameter>();
				DataTable dt = Select(lista, "csp_CLI_Regimen");
				foreach (DataRow dr in dt.Rows)
				{
					ExRegimen item = new ExRegimen();
					item.Id = Convert.ToInt32(dr["Id"]);
					item.Clave = dr["Clave"] == DBNull.Value ? (string)null : dr["Clave"].ToString();
					item.Descripcion = dr["Descripcion"] == DBNull.Value ? (string)null : dr["Descripcion"].ToString();
					Listitems.Add(item);
				}
				return Listitems;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
