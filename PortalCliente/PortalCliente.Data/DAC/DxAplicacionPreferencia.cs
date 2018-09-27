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
	public class DxAplicacionPreferencia : DataBaseAcces
	{

		public List<ExApliacacionPreferencia> Get()
		{
			try
			{
				List<ExApliacacionPreferencia> Listitems = new List<ExApliacacionPreferencia>();
				List<SqlParameter> lista = new List<SqlParameter>();
				DataTable dt = Select(lista,"tblCLI_Incoterm_SP");
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

	}
}
