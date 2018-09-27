using PortalCliente.Business.Interfaz;
using PortalCliente.Core.Enum;
using PortalCliente.Data.Repositorio;
using System;
using System.Data;

namespace PortalCliente.Business
{
    public class AprobacionBusiness : IAprobacionBusiness
    {
        private readonly AprobacionRepository aprobacionRepository;

        public AprobacionBusiness()
        {
            aprobacionRepository = new AprobacionRepository();
        }

		public bool AprobadoSinProcedimientoPreAlta(int idPrecliente, int idUsuario, int idEstatus, string observacion)
		{
			try
			{
				aprobacionRepository.AprobadoSinProcedimientoPreAlta(idPrecliente,idUsuario,idEstatus, observacion);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool NoAprobado(int idPrecliente, int idUsuario, int idEstatus, string observacion)
		{
			try
			{
				aprobacionRepository.NoAprobado(idPrecliente, idUsuario, idEstatus, observacion);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool RealizarAprobacion(int idUsuario, int idPrecliente, EstatusCliente estatusCliente)
        {
            var resultadoRepository = aprobacionRepository.RealizarAprobacion(idUsuario, idPrecliente, (int)estatusCliente);
            if (resultadoRepository != null)
                return resultadoRepository.Value > 1 ? true : false;
            else
                return false;
        }

        public bool RealizarRevalidacion(int idPrecliente, int idUsuario, EstatusCliente estatusCliente, string observacion)
        {
            var resultadoRepository = aprobacionRepository.RealizarRevalidacion(idPrecliente, idUsuario, (int)estatusCliente, observacion);

            if (resultadoRepository != null)
                return resultadoRepository.Value > 0 ? true : false;
            else
                return false;
        }

        public bool PreAltaRevalidacion(int idUsuario,int idPrecliente, int idEstatus, string observacion)
        {
            try
            {
                aprobacionRepository.PreAltaRevalidacion( idUsuario,idPrecliente, idEstatus, observacion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable ObtenerInfoActCliente(int idPrecliente, int idUsuario)
        {
            try
            {
                return aprobacionRepository.ObtenerInfoActCliente(idPrecliente, idUsuario); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ObtenerContactoInfFin(int idPrecliente, int idUsuario)
        {
            try
            {
                return aprobacionRepository.ObtenerContactoInfFin(idPrecliente, idUsuario); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ObtenerEmpTabulador1(int idPrecliente, int idUsuario)
        {
            try
            {
                return aprobacionRepository.ObtenerEmpTabulador1(idPrecliente, idUsuario); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ObtenerTabuladores(int idPrecliente, int idUsuario)
        {
            try
            {
                return aprobacionRepository.ObtenerTabuladores(idPrecliente, idUsuario); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ObtenerTarifaServicio(int idPrecliente, int idUsuario)
        {
            try
            {
                return aprobacionRepository.ObtenerTarifaServicio(idPrecliente, idUsuario); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ObtenerContactosEI(int idPrecliente, int idUsuario)
        {
            try
            {
                return aprobacionRepository.ObtenerContactosEI(idPrecliente, idUsuario); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminaActulizaTemporal(string idUsuario, int idPrecliente)
        {
            var resultadoRepository = aprobacionRepository.EliminaActulizaTemporal(idUsuario, idPrecliente);
            if (resultadoRepository != null)
                return resultadoRepository.Value > 1 ? true : false;
            else
                return false;
        }
    }
}
