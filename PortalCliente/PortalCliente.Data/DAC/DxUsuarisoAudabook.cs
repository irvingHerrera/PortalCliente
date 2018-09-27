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
	public class DxUsuarisoAudabook : DataBaseAcces
	{
		enum Opciones
		{
			Save = 1,
            GetByIdPrecliente = 2,
            deleteporprecliente = 3 
		}


		public DxUsuarisoAudabook()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="_tblCLI_UsuariosAduabook"></param>
		/// <returns>True or False</returns>
		public int Save(ExUsuariosAudabook _tblCLI_UsuariosAduabook)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.id_usuario_aduabook, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_usuario_aduabook" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.id_precliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_precliente" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.nombre, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vnombre" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.puesto_departamento, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vpuesto_departamento" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.telefono, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vtelefono" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.correo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vcorreo" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.admon, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vadmon" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.oper, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Voper" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.fecha_creacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.usuario_creacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_creacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.fecha_modificacion, SqlDbType = System.Data.SqlDbType.Date, ParameterName = "@Vfecha_modificacion" });
				parametros.Add(new SqlParameter { Value = _tblCLI_UsuariosAduabook.usuario_modificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vusuario_modificacion" });
				int? resultado = NoQuery(parametros, "tblCLI_UsuariosAduabook_SP");
				return (int)resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<ExUsuariosAudabook> GetByPreCliente(int id)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.GetByIdPrecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_precliente" });

                List<ExUsuariosAudabook> lista = new List<ExUsuariosAudabook>();
                DataTable dt = Select(parametros, "tblCLI_UsuariosAduabook_SP");
                foreach (DataRow dr in dt.Rows)
                {
                    ExUsuariosAudabook usuarios = new ExUsuariosAudabook();
                    usuarios.id_precliente = Convert.ToInt32(dr["id_precliente"]);
                    usuarios.nombre = dr["nombre"].ToString();
                    usuarios.puesto_departamento = dr["puesto_departamento"].ToString();
                    usuarios.telefono = dr["telefono"].ToString();
                    usuarios.correo = dr["correo"].ToString();
                    usuarios.admon = dr["admon"].ToString();
                    usuarios.oper = dr["oper"].ToString();
                    lista.Add(usuarios);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deletePorPrecliente(int id)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.deleteporprecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_precliente" });
                NoQuery(parametros, "tblCLI_UsuariosAduabook_SP");
                return true; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

	}
}
