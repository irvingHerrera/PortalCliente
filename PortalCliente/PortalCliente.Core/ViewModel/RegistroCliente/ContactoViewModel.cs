using System.ComponentModel.DataAnnotations;

namespace PortalCliente.Core.ViewModel.RegistroCliente
{
    public class ContactoViewModel
    {
        [Required]
        public int IdPrecliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string PuestoDepartamento { get; set; }
        [Required]
        public string UsuarioCreacion { get; set; }

    }
}
