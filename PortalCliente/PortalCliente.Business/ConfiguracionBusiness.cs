using System;
using System.Collections.Generic;
using System.Data;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;

namespace PortalCliente.Business
{
    public class ConfiguracionBusiness : IConfiguracionBusiness
    {
        private readonly IConfiguracionRepository configuracionRepository;

        public ConfiguracionBusiness()
        {
            configuracionRepository = new ConfiguracionRepository();
        }

        #region Metodos Privados

        private List<EquipoOperativoViewModel> ObtenerModeloEquipo(DataTable tabla)
        {
            var lista = new List<EquipoOperativoViewModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new EquipoOperativoViewModel
                {
                    IdEquipo = Convert.ToInt32(fila["id_equipo"].ToString()),
                    CorreoLider = fila["correo_lider"].ToString(),
                    Descripcion = fila["descripcion"].ToString(),
                    
                });
            }

            return lista;

        }

        #endregion

        public List<EquipoOperativoViewModel> ObtenerEquipoOperativo()
        {
            try
            {
                var tabla = configuracionRepository.ObtenerEquipoOperativo();
                var lista = ObtenerModeloEquipo(tabla);

                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
