using PortalCliente.Core;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public class CatalogoBusiness : ICatalogoBusiness
    {
        private readonly ICatalogoRepository catalogoRepository;

        public CatalogoBusiness()
        {
            catalogoRepository = new CatalogoRepository();
        }

        #region Metodos Privados}

        private List<CatalogoViewModel> ObtenerViewModel(DataTable catalogo)
        {
            var viewModel = new List<CatalogoViewModel>();

            foreach (DataRow fila in catalogo.Rows)
            {
                viewModel.Add(new CatalogoViewModel
                {
                    id = fila[0].ToString().Trim(),
                    Descripcion = fila[1].ToString().Trim(),
                });
            }

            return viewModel;
        }

        #endregion

        public List<CatalogoViewModel> ObtenerCiudad(string IdEstado)
        {
            var table = catalogoRepository.ObtenerCiudad(IdEstado);
            var listaCiudades = ObtenerViewModel(table);
            return listaCiudades;
        }

        public List<CatalogoViewModel> ObtenerEstado(string IdPais)
        {
            var table = catalogoRepository.ObtenerEstado(IdPais);
            var listaEstado = ObtenerViewModel(table);
            return listaEstado;
        }

        public List<CatalogoViewModel> ObtenerPais()
        {
            var table = catalogoRepository.ObtenerPais();
            var listaPais = ObtenerViewModel(table);
            return listaPais;
        }

        public List<CatalogoViewModel> ObtenerAduanas()
        {
            var lista = new List<CatalogoViewModel>();
            try
            {
                var tabla = catalogoRepository.ObtenerAduanas();
                lista = ObtenerViewModel(tabla);
            }
            catch (System.Exception ex)
            {

            }

            return lista;
        }

        public List<CatalogoViewModel> ObtenerClavePedimento()
        {
            var lista = new List<CatalogoViewModel>();
            try
            {
                var tabla = catalogoRepository.ObtenerClavePedimento();
                lista = ObtenerViewModel(tabla);
            }
            catch (System.Exception ex)
            {

            }

            return lista;
        }

        public List<CatalogoViewModel> ObtenerConceptoFacturacion(string empresa)
        {
            var lista = new List<CatalogoViewModel>();
            try
            {
                var tabla = catalogoRepository.ObtenerConceptoFacturacion(empresa);
                lista = ObtenerViewModel(tabla);
            }
            catch (System.Exception ex)
            {

            }

            return lista;
        }

        public List<CatalogoViewModel> ObtenerConceptoAutoFacturacion()
        {
            var lista = new List<CatalogoViewModel>();
            try
            {
                var tabla = catalogoRepository.ObtenerConceptoAutoFacturacion();
                lista = ObtenerViewModel(tabla);

            }
            catch (System.Exception ex)
            {

            }

            return lista;
        }
    }
}
