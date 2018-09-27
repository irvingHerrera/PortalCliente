using PortalCliente.Core.ViewModel;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public interface IAltaClienteBusiness
    {
        string GenerarExpediente(List<string> archivos, int idPreCliente, string rutaServidor, string usuarioCreacion);
        bool GuardarExpediente(int idPrecliente, string rutaExpediente, string usuarioCreacion);
        DataTable GuardarSistemasOperativos(SistemasOperativosViewModel modelo);
    }
}
