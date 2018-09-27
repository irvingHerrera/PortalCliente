using System.ComponentModel;

namespace PortalCliente.Core.Enum
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
