using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.DAC
{
    public class DxModulos : DataBaseAcces
	{
		enum Opciones
		{
			Save = 1,
			Update = 2,
			Delete = 3,
			Get = 4,
			GetByID = 5
		}


		public DxModulos()
		{

		}

		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_Modulos"></param>
		/// <returns>True or False</returns>
		public int Save(ExModulos _tblCLI_Modulos)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.id_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_modulo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.descripcion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vdescripcion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				int? resultado = NoQuery(parametros, "tblCLI_Modulos_SP");
				return (int)resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_Modulos"></param>
		/// <returns></returns>
		public bool Update(ExModulos _tblCLI_Modulos)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Update, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.id_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_modulo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.descripcion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vdescripcion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				NoQuery(parametros, "tblCLI_Modulos_SP");
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_Modulos"></param>
		/// <returns></returns>
		public bool Delete(ExModulos _tblCLI_Modulos)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Delete, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Modulos.id_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VClaveEntidad" });
				NoQuery(parametros, "tblCLI_Modulos_SP");
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		///
		/// </summary>
		/// <returns>List of tblCLI_Modulos</returns>
		public List<ExModulos> Get()
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Get, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				List<ExModulos> _tblCLI_Moduloss = new List<ExModulos>();
				DataTable dt = Select(parametros, "tblCLI_Modulos_SP");
				foreach (DataRow dr in dt.Rows)
				{
					 ExModulos _tblCLI_Modulos = new ExModulos();
					_tblCLI_Modulos.id_modulo = Convert.ToInt32(dr["id_modulo"]);
					_tblCLI_Modulos.descripcion = dr["descripcion"].ToString();
					_tblCLI_Modulos.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_Modulos.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_Modulos.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_Modulos.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
					_tblCLI_Moduloss.Add(_tblCLI_Modulos);
				}
				return _tblCLI_Moduloss;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		///
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		public ExModulos GetByID(int id)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.GetByID, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_modulo" });
				ExModulos _tblCLI_Modulos = new ExModulos();
				DataTable dt = Select(parametros, "tblCLI_Modulos_SP");
				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					_tblCLI_Modulos.id_modulo = Convert.ToInt32(dr["id_modulo"]);
					_tblCLI_Modulos.descripcion = dr["descripcion"].ToString();
					_tblCLI_Modulos.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_Modulos.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_Modulos.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_Modulos.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
				}
				return _tblCLI_Modulos;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
