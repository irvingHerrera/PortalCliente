using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
	public class ExDocumentos
	{
		public int id_documento { get; set; }
		public int id_precliente { get; set; }
		public bool activo { get; set; }
		public string ruta_local { get; set; }
		public DateTime fecha_creacion { get; set; }
		public string usuario_creacion { get; set; }
		public DateTime fecha_modificacion { get; set; }
		public string usuario_modificacion { get; set; }
	}
}
