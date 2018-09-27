using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
    public class DatosFinanciamientoDTO
    {
        public string monto { get; set; }
        public string para_uso_en { get; set; }
        public string punto_reorden { get; set; }
        public string recuperacion { get; set; }
        public string plazo { get; set; }
        public string condiciones { get; set; }
        public string con_financiamiento { get; set; }
    }
}
