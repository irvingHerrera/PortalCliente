using PortalCliente.Core;
using System.Collections.Generic;

namespace PortalCliente.Business.Interfaz
{
    public interface IConfiguracionBusiness
    {
        List<EquipoOperativoViewModel> ObtenerEquipoOperativo();
    }
}
