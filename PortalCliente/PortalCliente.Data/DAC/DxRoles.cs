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
    public	class DxRoles: DataBaseAcces
	{
		enum Opciones
		{
			Save = 1,
			Update = 2,
			Delete = 3,
			Get = 4,
			GetByID = 5
		}


		public DxRoles()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_Roles"></param>
		/// <returns>True or False</returns>
		public int Save(ExRoles _tblCLI_Roles)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.descripcion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vdescripcion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				int? resultado = NoQuery(parametros, "tblCLI_Roles_SP");
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
		/// <param name="_tblCLI_Roles"></param>
		/// <returns></returns>
		public bool Update(ExRoles _tblCLI_Roles)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Update, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.descripcion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vdescripcion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				NoQuery(parametros, "tblCLI_Roles_SP");
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
		/// <param name="_tblCLI_Roles"></param>
		/// <returns></returns>
		public bool Delete(ExRoles _tblCLI_Roles)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Delete, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Roles.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VClaveEntidad" });
				NoQuery(parametros, "tblCLI_Roles_SP");
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
		/// <returns>List of tblCLI_Roles</returns>
		public List<ExRoles> Get()
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Get, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				List<ExRoles> _tblCLI_Roless = new List<ExRoles>();
				DataTable dt = Select(parametros, "tblCLI_Roles_SP");
				foreach (DataRow dr in dt.Rows)
				{
					ExRoles _tblCLI_Roles = new ExRoles();
					_tblCLI_Roles.id_rol = Convert.ToInt32(dr["id_rol"]);
					_tblCLI_Roles.descripcion = dr["descripcion"].ToString();
					_tblCLI_Roles.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_Roles.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_Roles.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_Roles.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
					_tblCLI_Roless.Add(_tblCLI_Roles);
				}
				return _tblCLI_Roless;
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
		public ExRoles GetByID(int id)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.GetByID, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				ExRoles _tblCLI_Roles = new ExRoles();
				DataTable dt = Select(parametros, "tblCLI_Roles_SP");
				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					_tblCLI_Roles.id_rol = Convert.ToInt32(dr["id_rol"]);
					_tblCLI_Roles.descripcion = dr["descripcion"].ToString();
					_tblCLI_Roles.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_Roles.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_Roles.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_Roles.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
				}
				return _tblCLI_Roles;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
