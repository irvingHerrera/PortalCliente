using System.ComponentModel;

namespace PortalCliente.Core.Enum
{
    public enum GrupoEstatus
    {
        [Description("CapturaCliente")]
        CapturaCliente = 1,
        [Description("Aprobaciones")]
        Aprobaciones = 2,
        [Description("Altacliente")]
        AltaCliente = 3,
        [Description("ActualizarCliente")]
        ActualizarCliente = 4,
    }
}
