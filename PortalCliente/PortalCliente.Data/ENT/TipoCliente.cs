using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
    public enum TipoCliente
    {
        [Description("Pedimento")]
        Pedimiento = 1,
        [Description("Factura")]
        Factura = 2,
        [Description("Pedimento-Factura")]
        PedimientoFactura = 3
    }
}
