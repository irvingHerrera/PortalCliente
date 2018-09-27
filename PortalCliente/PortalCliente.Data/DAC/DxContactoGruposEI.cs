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
	public class DxContactoGruposEI : DataBaseAcces
	{

		enum Opciones
		{
			Save = 1,
			DeleteByTabuladorTab = 2,
			GetbyTabuladorTab = 3,
		}


		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_ContactosGrupoEI"></param>
		/// <returns>True or False</returns>
		public int Save(ExContactoGruposEI _tblCLI_ContactosGrupoEI)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.id_precliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_precliente" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.id_tabulador_tab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_tabulador_tab" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.nombre, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vnombre" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.correo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcorreo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.telefono, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vtelefono" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.puesto_departamento, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vpuesto_departamento" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				int? resultado = NoQuery(parametros, "tblCLI_ContactosGrupoEI_SP");
				return (int)resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int SaveTMP(ExContactoGruposEI _tblCLI_ContactosGrupoEI)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.id_precliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_precliente" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.id_tabulador_tab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_tabulador_tab" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.nombre, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vnombre" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.correo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcorreo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.telefono, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vtelefono" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.puesto_departamento, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vpuesto_departamento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_ContactosGrupoEI.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
                int? resultado = NoQuery(parametros, "tblCLI_ContactosGrupoEI_SP_TMP");
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
        /// <param name="_tblCLI_ContactosGrupoEI"></param>
        /// <returns></returns>
        public bool Delete(int idTabuladorTab)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.DeleteByTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = idTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_tabulador_tab" });
				NoQuery(parametros, "tblCLI_ContactosGrupoEI_SP");
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public bool DeleteTMP(int idTabuladorTab)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.DeleteByTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = idTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_tabulador_tab" });
                NoQuery(parametros, "tblCLI_ContactosGrupoEI_SP_TMP");
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
        /// <returns>List of tblCLI_ContactosGrupoEI</returns>
        public List<ExContactoGruposEI> GetbyTabuladorTab(int idTabuladorTab)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.GetbyTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = idTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_tabulador_tab" });
				List<ExContactoGruposEI> _tblCLI_ContactosGrupoEIs = new List<ExContactoGruposEI>();
				DataTable dt = Select(parametros, "tblCLI_ContactosGrupoEI_SP");
				foreach (DataRow dr in dt.Rows)
				{
					ExContactoGruposEI _tblCLI_ContactosGrupoEI = new ExContactoGruposEI();
					_tblCLI_ContactosGrupoEI.id_contacto_grupoei = Convert.ToInt32(dr["id_contacto_grupoei"]);
					_tblCLI_ContactosGrupoEI.id_precliente = Convert.ToInt32(dr["id_precliente"]);
					_tblCLI_ContactosGrupoEI.id_tabulador_tab = Convert.ToInt32(dr["id_tabulador_tab"]);
					_tblCLI_ContactosGrupoEI.nombre = dr["nombre"].ToString();
					_tblCLI_ContactosGrupoEI.correo = dr["correo"].ToString();
					_tblCLI_ContactosGrupoEI.telefono = dr["telefono"].ToString();
					_tblCLI_ContactosGrupoEI.puesto_departamento = dr["puesto_departamento"].ToString();
					_tblCLI_ContactosGrupoEI.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
					_tblCLI_ContactosGrupoEI.usuario_creacion = dr["usuario_creacion"].ToString();
					_tblCLI_ContactosGrupoEI.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
					_tblCLI_ContactosGrupoEI.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
					_tblCLI_ContactosGrupoEIs.Add(_tblCLI_ContactosGrupoEI);
				}
				return _tblCLI_ContactosGrupoEIs;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<ExContactoGruposEI> GetbyTabuladorTabTMP(int idTabuladorTab)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.GetbyTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = idTabuladorTab, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_tabulador_tab" });
                List<ExContactoGruposEI> _tblCLI_ContactosGrupoEIs = new List<ExContactoGruposEI>();
                DataTable dt = Select(parametros, "tblCLI_ContactosGrupoEI_SP_TMP");
                foreach (DataRow dr in dt.Rows)
                {
                    ExContactoGruposEI _tblCLI_ContactosGrupoEI = new ExContactoGruposEI();
                    _tblCLI_ContactosGrupoEI.id_contacto_grupoei = Convert.ToInt32(dr["id_contacto_grupoei"]);
                    _tblCLI_ContactosGrupoEI.id_precliente = Convert.ToInt32(dr["id_precliente"]);
                    _tblCLI_ContactosGrupoEI.id_tabulador_tab = Convert.ToInt32(dr["id_tabulador_tab"]);
                    _tblCLI_ContactosGrupoEI.nombre = dr["nombre"].ToString();
                    _tblCLI_ContactosGrupoEI.correo = dr["correo"].ToString();
                    _tblCLI_ContactosGrupoEI.telefono = dr["telefono"].ToString();
                    _tblCLI_ContactosGrupoEI.puesto_departamento = dr["puesto_departamento"].ToString();
                    _tblCLI_ContactosGrupoEI.fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]);
                    _tblCLI_ContactosGrupoEI.usuario_creacion = dr["usuario_creacion"].ToString();
                    _tblCLI_ContactosGrupoEI.fecha_modificacion = dr["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_modificacion"]);
                    _tblCLI_ContactosGrupoEI.usuario_modificacion = dr["usuario_modificacion"] == DBNull.Value ? (string)null : dr["usuario_modificacion"].ToString();
                    _tblCLI_ContactosGrupoEIs.Add(_tblCLI_ContactosGrupoEI);
                }
                return _tblCLI_ContactosGrupoEIs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
