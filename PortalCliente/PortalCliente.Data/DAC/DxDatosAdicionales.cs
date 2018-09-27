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
	public class DxDatosAdicionales : DataBaseAcces
	{
		
		public int GuardaDatosADicionales(ExDatosAdicionales _ExDatosAdicionales)
		{
			try
			{
				//DAC _Dac = new DAC(); 
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.correoarribo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@vcorreoarribo" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.id_precliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vid_precliente" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.frecuencia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vfrecuencia" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.giro, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vgiro" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.numero_empleados, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vnumero_empleados" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.pagina_web, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vpagina_web" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.patemtes_operacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@vpatemtes_operacion" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.Telefono, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VTelefono" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.tiempo_establecido, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@Vtiempo_establecido" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.ventas_anuales, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@Vventas_anuales" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.vucemC, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@vvucem_cliente" });
				parametros.Add(new SqlParameter { Value = _ExDatosAdicionales.vucemG, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@vvucem_grupoei" });


				int? resultado = NoQuery(parametros, "tblCLI_GuardaDatosAdicionales_SP");
                return 0;//(int)resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
	  	}




	}
}
