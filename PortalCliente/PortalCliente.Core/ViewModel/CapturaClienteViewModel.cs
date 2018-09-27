using PortalCliente.Core.ViewModel.RegistroCliente;
using System.Collections.Generic;

namespace PortalCliente.Core.ViewModel
{
    public class CapturaClienteViewModel
    {
        public DatoClienteViewModel DatosCliente { get; set; }
        public DatosAdicionalesViewModel DatoAdicional { get; set; }
        public List<UsuariosAudabookViewModel> UsuarioAudabook { get; set; }
        public CuestionarioViewModel Cuestionario { get; set; }
    }
}
