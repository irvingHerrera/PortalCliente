using System.ComponentModel;

namespace PortalCliente.Core.Enum
{
    public enum EstatusCliente
    {
        [Description("En Registro")]
        EnRegistro = 1,
        [Description("En Captura")]
        EnCaptura = 2,
        [Description("Para Aprobacion PreAlta")]
        ParaAprobacionPreAlta = 3,
        [Description("Revalidacion PreAlta")]
        RevalidacionPreAlta = 4,
        [Description("Aprobado Sin Procedimiento PreAlta")]
        AprobadoSinProcedimientoPreAlta = 5,
        [Description("No Aprobado")]
        NoAprobado = 6,
        [Description("Aprobado PreAlta")]
        AprobadoPreAlta = 7,
        [Description("Cliente Sin Procedimiento")]
        ClienteSinProcedimiento = 8,
        [Description("Cliente")]
        Cliente = 9,
        [Description("Para Aprobacion Procedimiento Prealta")]
        ParaAprobacionProcedimientoPrealta = 10,
        [Description("Para Aprobacion Procedimiento Cliente")]
        ParaAprobacionProcedimientoCliente = 11,
        [Description("Revalidacion Procedimiento Prealta")]
        RevalidacionProcedimientoPrealta = 12,
        [Description("Revalidacion Procedimiento Cliente")]
        RevalidacionProcedimientoCliente = 13,
        [Description("Activo")]
        Activo = 14,
        [Description("Inactivo")]
        Inactivo = 15,
        [Description("Para Aprobar Actualización")]
        ParaAprobarActualización = 16,
        [Description("Revalidación De Actualización")]
        RevalidaciónDeActualización = 17,
        [Description("Actualizado")]
        Actualizado = 18
    }
}
