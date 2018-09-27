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
	public class DxRolesModulos : DataBaseAcces
	{
		enum Opciones
		{
			Save = 1,
			Update = 2,
			Delete = 3,
			Get = 4,
			GetByID = 5
		}


		public DxRolesModulos()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_RolesModulos"></param>
		/// <returns>True or False</returns>
		public int Save(ExRolesModulos _tblCLI_RolesModulos)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_rol_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol_modulo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_modulo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				int? resultado = NoQuery(parametros, "tblCLI_RolesModulos_SP");
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
		/// <param name="_tblCLI_RolesModulos"></param>
		/// <returns></returns>
		public bool Update(ExRolesModulos _tblCLI_RolesModulos)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Update, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_rol_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol_modulo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_modulo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				NoQuery(parametros, "tblCLI_RolesModulos_SP");
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
		/// <param name="_tblCLI_RolesModulos"></param>
		/// <returns></returns>
		public bool Delete(ExRolesModulos _tblCLI_RolesModulos)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Delete, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_RolesModulos.id_rol_modulo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol_modulo" });
				NoQuery(parametros, "tblCLI_RolesModulos_SP");
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
		/// <returns>List of tblCLI_RolesModulos</returns>
		public List<ExRolesModulos> Get()
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Get, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				List<ExRolesModulos> _tblCLI_RolesModuloss = new List<ExRolesModulos>();
				DataTable dt = Select(parametros, "tblCLI_RolesModulos_SP");
				foreach (DataRow dr in dt.Rows)
				{
					ExRolesModulos _tblCLI_RolesModulos = new ExRolesModulos();
					_tblCLI_RolesModulos.id_rol_modulo = Convert.ToInt32(dr["id_rol_modulo"]);
					_tblCLI_RolesModulos.id_rol = Convert.ToInt32(dr["id_rol"]);
					_tblCLI_RolesModulos.id_modulo = Convert.ToInt32(dr["id_modulo"]);
					_tblCLI_RolesModulos.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_RolesModulos.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_RolesModulos.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_RolesModulos.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
					_tblCLI_RolesModuloss.Add(_tblCLI_RolesModulos);
				}
				return _tblCLI_RolesModuloss;
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
		public ExRolesModulos GetByID(int id)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.GetByID, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VClaveEntidad" });
				ExRolesModulos _tblCLI_RolesModulos = new ExRolesModulos();
				DataTable dt = Select(parametros, "tblCLI_RolesModulos_SP");
				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					_tblCLI_RolesModulos.id_rol_modulo = Convert.ToInt32(dr["id_rol_modulo"]);
					_tblCLI_RolesModulos.id_rol = Convert.ToInt32(dr["id_rol"]);
					_tblCLI_RolesModulos.id_modulo = Convert.ToInt32(dr["id_modulo"]);
					_tblCLI_RolesModulos.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_RolesModulos.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_RolesModulos.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_RolesModulos.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
				}
				return _tblCLI_RolesModulos;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
