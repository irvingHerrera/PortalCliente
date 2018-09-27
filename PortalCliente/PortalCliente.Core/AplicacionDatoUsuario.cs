using PortalCliente.Core.ViewModel;
using System;

namespace PortalCliente.Core
{
    public class AplicacionDatoUsuario
    {
        public DatosUsuarioViewModel Usuario { get; set; }

        private static readonly Lazy<AplicacionDatoUsuario> Objeto =
        new Lazy<AplicacionDatoUsuario>(() => new AplicacionDatoUsuario()
        {
            Usuario = new DatosUsuarioViewModel()
        });

        public static AplicacionDatoUsuario Instancia { get { return Objeto.Value; } }
    }
}
