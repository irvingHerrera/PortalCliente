using PortalCliente.Data.ENT;
using System.Data;


namespace PortalCliente.Data.Interfaz
{
    public interface IActualizarClienteRepository
    {
        int? GuardarDatoOperacion(TabuladorDTO tabuladores);
        DataTable BuscarDatosTabuladores(string id_precliente,ref bool temporal);
        DataTable BuscarDatosTabuladoresContactos(string id_precliente, bool temporal=false);
        DataTable BuscarDatosTabuladoresTarifas(string id_precliente, bool temporal = false);
        DataTable BuscarDatosTabuladoresTabs(string id_precliente, bool temporal = false);
        DataTable BuscarDatosTabuladoresEmpresa(string id_tabulador_tab, bool temporal = false);
    }
}
