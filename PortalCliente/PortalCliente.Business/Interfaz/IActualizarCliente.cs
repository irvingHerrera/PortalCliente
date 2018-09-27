using PortalCliente.Core.ViewModel.Tabuladores;
using PortalCliente.Data.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Business.Interfaz
{
    public interface IActualizarClienteBussiness
    {
        bool GuardarDatoOperacion(TabuladorViewModel modelo);
        List<ExTabuladorProcedimientoOperacion> GetByTabuladorTab(int idTabuladorTab);
        DataTable BuscarDatosTabuladores(string id_precliente, ref bool temporal);
        DataTable BuscarDatosTabuladoresContactos(string id_precliente, bool temporal);
        DataTable BuscarDatosTabuladoresTarifas(string id_precliente, bool temporal);
        DataTable BuscarDatosTabuladoresTabs(string id_precliente, bool temporal);
        DataTable BuscarDatosTabuladoresEmpresa(string id_tabulador_tab, bool temporal);
    }
}
