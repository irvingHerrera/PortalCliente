using System.ComponentModel.DataAnnotations;

namespace PortalCliente.Core.ViewModel.RegistroCliente
{
    public class CuentaViewModel
    {
        public int IdBanco { get; set; }
        [Required]
        public int IdPrecliente { get; set; }
        [Required]
        public string Banco { get; set; }
        [Required]
        public int NumeroCuenta { get; set; }
        [Required]
        public string Identificador { get; set; }
        [Required]
        public string PatentesAutorizadas { get; set; }
        [Required]
        public string Aduana { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}
