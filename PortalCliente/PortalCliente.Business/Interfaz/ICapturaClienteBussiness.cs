using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.RegistroCliente;
using PortalCliente.Core.ViewModel.Tabuladores;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public interface ICapturaClienteBussiness
    {
        DataTable ObtenerInfoCliente(string id_usuario);
        DataTable ObtenerContactosCliente(string id_precliente);
        DataTable ObtenerCtasBancPECACliente(string id_precliente);
        DataTable ObtenerUsrAduabookCliente(string id_precliente);
        DataTable ObtenerCuestionarioCliente(string id_precliente);
        List<CuentaViewModel> ObtenerCtasBancaria(string idPrecliente);
        int ObtenerNumeroTabuladores(int idUsuario, int idPrecliente);
        List<PreclienteAprobadorViewModel> ObtenerRelacionPreclieteAprobador(int idPrecliente);
        DataTable ObtenerDocumentosCliente(string id_precliente);
        DataTable GuardarRevisionDocumentosCliente(string id_precliente, string id_usuario);
        DataTable ValidaNumeroDocumentosRevisados(string id_precliente);
        bool GuardarTabuladores(TabuladorViewModel modelo);
        bool ActualizarRegistroCliente(CapturaClienteViewModel modelo, bool isCambioEstatus);
        DataTable ObtieneTabsPrecliente(int idPrecliente);
        DataTable BuscarDatosTabuladores(string id_precliente);
        DataTable BuscarDatosTabuladoresContactos(string id_precliente);
        DataTable BuscarDatosTabuladoresTarifas(string id_precliente);
        DataTable BuscarDatosTabuladoresTabs(string id_precliente);
        DataTable BuscarDatosTabuladoresEmpresa(string id_tabulador_tab);
        DataTable GuardarTerminarProcedimientoOperacion(string id_precliente);
        DataTable ActivarCliente(string id_precliente);
        DataTable InactivarCliente(string id_precliente);
    }
}
