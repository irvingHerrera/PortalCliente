using PortalCliente.Core;
using System.Collections.Generic;

namespace PortalCliente.Business.Interfaz
{
    public interface ICatalogoBusiness
    {        
        List<CatalogoViewModel> ObtenerPais();
        List<CatalogoViewModel> ObtenerEstado(string IdPais);
        List<CatalogoViewModel> ObtenerCiudad(string IdEstado);
        List<CatalogoViewModel> ObtenerAduanas();
        List<CatalogoViewModel> ObtenerClavePedimento();
        List<CatalogoViewModel> ObtenerConceptoFacturacion(string empresa);
        List<CatalogoViewModel> ObtenerConceptoAutoFacturacion();
    }
}
