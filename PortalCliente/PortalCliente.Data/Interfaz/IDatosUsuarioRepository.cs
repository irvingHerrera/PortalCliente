using PortalCliente.Data.ENT;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface IDatosUsuarioRepository
    {
        DataTable ObtenerDatosUsuario(string usuario);
        DataTable ValidarLogin(string usuario, string password);
    }
}
