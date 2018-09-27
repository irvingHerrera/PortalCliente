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
    public	class DxUsuarios : DataBaseAcces
	{
		enum Opciones
		{
			Save = 1,
			Update = 2,
			Delete = 3,
			Get = 4,
			GetByID = 5,
			GetNextPrecliente = 6 
		}


		public DxUsuarios()
		{

        }

		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_Usuarios"></param>
		/// <returns>True or False</returns>
		public int Save(ExUsuarios _tblCLI_Usuarios)
		{
			try
			{

				if (String.IsNullOrEmpty(_tblCLI_Usuarios.contrasenia))
				{
					_tblCLI_Usuarios.contrasenia = "";
				}
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.id_usuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_usuario" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.nombre, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vnombre" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.usuario, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.contrasenia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcontrasenia" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.correo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcorreo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.Activo, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@Vactivo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.grupo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vgrupo" });
				int? resultado = NoQuery(parametros, "tblCLI_Usuarios_SP");
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
		/// <param name="_tblCLI_Usuarios"></param>
		/// <returns></returns>
		public bool Update(ExUsuarios _tblCLI_Usuarios)
		{
			try
			{
                if (String.IsNullOrEmpty(_tblCLI_Usuarios.contrasenia))
                {
                    _tblCLI_Usuarios.contrasenia = "";
                }
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Update, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.id_usuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_usuario" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.id_rol, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_rol" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.nombre, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vnombre" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.usuario, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.contrasenia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcontrasenia" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.correo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcorreo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.Activo, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@Vactivo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.grupo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vgrupo" });
				NoQuery(parametros, "tblCLI_Usuarios_SP");
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
		/// <param name="_tblCLI_Usuarios"></param>
		/// <returns></returns>
		public bool Delete(ExUsuarios _tblCLI_Usuarios)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Delete, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.id_usuario, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_usuario" });
                parametros.Add(new SqlParameter { Value = _tblCLI_Usuarios.Activo, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@Vactivo" });
                NoQuery(parametros, "tblCLI_Usuarios_SP");
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
		/// <returns>List of tblCLI_Usuarios</returns>
		public List<ExUsuarios> Get()
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Get, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				List<ExUsuarios> _tblCLI_Usuarioss = new List<ExUsuarios>();
				DataTable dt = Select(parametros, "tblCLI_Usuarios_SP");
				foreach (DataRow dr in dt.Rows)
				{
					ExUsuarios _tblCLI_Usuarios = new ExUsuarios();
					_tblCLI_Usuarios.id_usuario = Convert.ToInt32(dr["id_usuario"]);
					_tblCLI_Usuarios.id_rol = Convert.ToInt32(dr["id_rol"]);
					_tblCLI_Usuarios.nombre = dr["nombre"].ToString();
					_tblCLI_Usuarios.usuario = dr["usuario"].ToString();
					_tblCLI_Usuarios.contrasenia = dr["contrasenia"].ToString();
					_tblCLI_Usuarios.correo = dr["correo"].ToString();
					_tblCLI_Usuarios.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_Usuarios.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_Usuarios.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_Usuarios.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
                    _tblCLI_Usuarios.Activo = dr["activo"] == DBNull.Value ? false : Convert.ToBoolean(dr["activo"]);
					_tblCLI_Usuarios.grupo = dr["grupo"] == DBNull.Value ? "" : dr["grupo"].ToString();
					_tblCLI_Usuarioss.Add(_tblCLI_Usuarios);
				}
				return _tblCLI_Usuarioss;
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
		public ExUsuarios GetByID(int id)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.GetByID, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_usuario" });
				ExUsuarios _tblCLI_Usuarios = new ExUsuarios();
				DataTable dt = Select(parametros, "tblCLI_Usuarios_SP");
				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					_tblCLI_Usuarios.id_usuario = Convert.ToInt32(dr["id_usuario"]);
					_tblCLI_Usuarios.id_rol = Convert.ToInt32(dr["id_rol"]);
					_tblCLI_Usuarios.nombre = dr["nombre"].ToString();
					_tblCLI_Usuarios.usuario = dr["usuario"].ToString();
					_tblCLI_Usuarios.contrasenia = dr["contrasenia"].ToString();
					_tblCLI_Usuarios.correo = dr["correo"].ToString();
					_tblCLI_Usuarios.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_Usuarios.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_Usuarios.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_Usuarios.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
                    _tblCLI_Usuarios.grupo = dr["grupo"] == DBNull.Value ? "" : dr["grupo"].ToString();
                    _tblCLI_Usuarios.Activo = dr["activo"] == DBNull.Value ? false : Convert.ToBoolean(dr["activo"]);
                }
				return _tblCLI_Usuarios;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ExUsuarios getnextprecliente()
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.GetNextPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				ExUsuarios _tblCLI_Usuarios = new ExUsuarios();
				DataTable dt = Select(parametros, "tblCLI_Usuarios_SP");
				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					_tblCLI_Usuarios.id_usuario = Convert.ToInt32(dr["Id_PreclienteNext"]);
				}
				return _tblCLI_Usuarios;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public bool ExisteEnAudasis(string usaurio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { Value = usaurio, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@usuariodesc" });
            
            DataTable dt = Select(parametros, "csp_CLIValidaAudasis_SP");
            int cuantos = 0;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                cuantos = Convert.ToInt32(dr["CANT"]);
            }
            if (cuantos > 0) return true;
            else return false;
            
        }

	}
}
