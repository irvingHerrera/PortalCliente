using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
    public class ExModulos
	{
		public int id_modulo { get; set; }
		public string descripcion { get; set; }
		public DateTime fecha_creacion { get; set; }
		public string usuario_creacion { get; set; }
		public DateTime? fecha_modificacion { get; set; }
		public string usuario_modificacion { get; set; }
	}
}
