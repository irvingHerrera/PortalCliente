using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Core
{
    public class LoginMensaje
    {
        public String Mensaje { get; set; }

        private static readonly Lazy<LoginMensaje> Objeto =
        new Lazy<LoginMensaje>(() => new LoginMensaje()
        {
            Mensaje = ""
        });

        public static LoginMensaje Instancia { get { return Objeto.Value; } }
    }
}
