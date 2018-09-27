using System.Collections.Generic;
using System.Data;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;

namespace PortalCliente.Business
{
    public class AltaClienteBusiness : IAltaClienteBusiness
    {
        private readonly IAltaClienteRepository altaClienteRepository;

        public AltaClienteBusiness()
        {
            altaClienteRepository = new AltaClienteRepository();
        }

        public string GenerarExpediente(List<string> archivos, int idPreCliente, string rutaServidor, string usuarioCreacion)
        {
            try
            {
                var expediente = new ExpedienteCliente();
                string rutaExpediente = expediente.GenerarExpediente(archivos, idPreCliente, rutaServidor);

                GuardarExpediente(idPreCliente, rutaExpediente, usuarioCreacion);

                return rutaExpediente;
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
        }

        public bool GuardarExpediente(int idPrecliente, string rutaExpediente, string usuarioCreacion)
        {
            var resultado = altaClienteRepository.GuardarExpediente(idPrecliente, rutaExpediente, usuarioCreacion);

            if (resultado != null)
            {
                if (resultado.Value > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public DataTable GuardarSistemasOperativos(SistemasOperativosViewModel modelo)
        {
            var dto = ObtenerDTOSistemasOperativos(modelo);

            try
            {
                var resultado = altaClienteRepository.GuardarSistemasOperativos(dto);
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private SistemasOperativosDTO ObtenerDTOSistemasOperativos(SistemasOperativosViewModel modelo)
        {
            var dto = new SistemasOperativosDTO();
            dto.ID_precliente = modelo.ID_precliente;
            dto.ADUASIS = modelo.ADUASIS;
            dto.GP = modelo.GP;
            dto.Equipo = modelo.Equipo.IdEquipo.ToString();
            dto.Correos = modelo.Correos;
            return dto;
        }
    }
}
