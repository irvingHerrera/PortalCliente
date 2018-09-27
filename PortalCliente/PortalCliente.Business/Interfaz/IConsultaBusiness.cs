using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.Tabuladores;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public interface IConsultaBusiness
    {
        List<PreclientePendienteViewModel> ObtenerListaPreclientePendiente();
        DataTable ObtenerInfoTabuladoresTEMP(int id_precliente);
        DataTable ObtenerAprobacionDePreAltaCliente(int id_precliente);
        DataTable ObtenerAprobacionDeAltaCliente(int id_precliente);
    }
}
