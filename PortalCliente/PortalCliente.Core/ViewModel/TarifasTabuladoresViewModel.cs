using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Core.ViewModel
{
    public class TarifasTabuladoresViewModel
    {
        [Required]
        public int IdPrecliente { get; set; }
        [Required]
        public string Servicio { get; set; }
        [Required]
        public string Notas { get; set; }
        [Required]
        public string Tarifa { get; set; }
    }
}
