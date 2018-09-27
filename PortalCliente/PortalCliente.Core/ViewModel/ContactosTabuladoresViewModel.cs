using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Core.ViewModel
{
    public class ContactosTabuladoresViewModel
    {
        [Required]
        public int IdPrecliente { get; set; }
        [Required]
        public string Contacto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Puesto { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
