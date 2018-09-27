using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
	public class ExContactoGruposEI
	{
		public int id_contacto_grupoei { get; set; }
		public int id_precliente { get; set; }
		public int id_tabulador_tab { get; set; }
		public string nombre { get; set; }
		public string correo { get; set; }
		public string telefono { get; set; }
		public string puesto_departamento { get; set; }
		public DateTime fecha_creacion { get; set; }
		public string usuario_creacion { get; set; }
		public DateTime? fecha_modificacion { get; set; }
		public string usuario_modificacion { get; set; }
	}
}
