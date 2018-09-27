using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
    public class DatosUsuarioDTO
    {
        public string id_usuario { get; set; }
        public string id_rol { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
    }
}
