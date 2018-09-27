using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
    public class EmpresaTabuladorDTO
    {
        public string Empresa { get; set; }
        public CatalogoDTO ConceptoFacturacion { get; set; }
        public CatalogoDTO ConceptoAutoFacturacion { get; set; }
        public string TarifaVenta { get; set; }
        public string TarifaVentaMoneda { get; set; }
        public string TarifaCompra { get; set; }
        public string TarifaCompraMoneda { get; set; }
    }
}
