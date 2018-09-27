using System.Data;

namespace PortalCliente.Data.Interfaz
{
    public interface ICatalogoRepository
    {
        DataTable ObtenerPais();
        DataTable ObtenerEstado(string IdPais);
        DataTable ObtenerCiudad(string IdEstado);
        DataTable ObtenerAduanas();
        DataTable ObtenerClavePedimento();
        DataTable ObtenerConceptoFacturacion(string empresa);
        DataTable ObtenerConceptoAutoFacturacion();
    }
}
