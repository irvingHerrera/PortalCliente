using PortalCliente.Core.ViewModel;
using System.Collections.Generic;

namespace PortalCliente.Business.Interfaz
{
    public interface IImpresionBusiness
    {
        DocumentoViewModel ObtenerExpedienteCliente(int idPrecliente);
        DocumentoViewModel ReporteSolicitudCliente(int idPrecliente, int idUsuario, string path);
        DocumentoViewModel ReporteProcedimientoOperacion(int idPrecliente, int idUsuario, string path);
        DocumentoViewModel ReporteTabulador(int idPrecliente, string path);
        List<DocumentoViewModel> ObtenerDocumentoCliente(int idPrecliente);
        List<DocumentoViewModel> ObtenerDocumentoClienteExpediente(int idPrecliente);

    }
}
