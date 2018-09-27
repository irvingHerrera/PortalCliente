using PortalCliente.Data.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.Interfaz
{
    public interface ICapturaClienteRepository
    {
        DataTable ObtenerInfoCliente(string id_usuario);
        DataTable ObtenerContactosCliente(string id_precliente);
        DataTable ObtenerCtasBancPECACliente(string id_precliente);
        DataTable ObtenerUsrAduabookCliente(string id_precliente);
        DataTable ObtenerCuestionarioCliente(string id_precliente);
        DataTable ObtenerNumeroTabuladores(int idUsuario, int idPrecliente);
        DataTable ObtenerDocumentosCliente(string id_precliente);
        DataTable ObtenerDocumentosClienteExpediente(string id_precliente);
        DataTable GuardarRevisionDocumentosCliente(string id_precliente, string id_usuario);
        DataTable ValidaNumeroDocumentosRevisados(string id_precliente);
        int? GuardarTabuladores(TabuladorDTO tabuladores);
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
