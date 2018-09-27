using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
	public class ExUsuarios
	{
		public int id_usuario { get; set; }
		public int id_rol { get; set; }
		public string nombre { get; set; }
		public string usuario { get; set; }
		public string contrasenia { get; set; }
		public string correo { get; set; }
		public DateTime fecha_creacion { get; set; }
		public string usuario_creacion { get; set; }
		public DateTime? fecha_modificacion { get; set; }
		public string usuario_modificacion { get; set; }
        public bool Activo { get; set; }
		public string grupo { get; set; }
	}
}
