using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalCliente.Business.Interfaz;
using PortalCliente.Data.ENT;
using PortalCliente.Data.DAC;
using System.Data;

namespace PortalCliente.Business
{
	public class TabuladorProcedimientoOperacionBussines : ITabuladorProcedimientoOperacionBussines
	{
		public List<ExApliacacionPreferencia> GetApliacacionPreferencia()
		{
			try
			{
				return new DxTabuladorProcOpCats().GetApliacacionPreferencia();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExIncoterm> GetExIncoterms()
		{
			try
			{
				return new DxTabuladorProcOpCats().GetIncoterm();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExMetodoValoracion> GetExMetodoValoracions()
		{
			try
			{
				return new DxTabuladorProcOpCats().GetMetodoValoracion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExFormaPago> GetFormaPagos()
		{
			try
			{
				return new DxTabuladorProcOpCats().GetFormaPago();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ExRegimen> GetRegimens()
		{
			try
			{
				return new DxTabuladorProcOpCats().GetRegimen();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool GuardaTabuladorProcedimientoOperacionBussines(ExTabuladorProcedimientoOperacion _ExTabuladorProcedimientoOperacion)
		{
			try
			{
				var dac = new DxTabuladorProcedimientoOperacion();
				//Actualiza
				if (_ExTabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion == 0)
				{
					dac.Save(_ExTabuladorProcedimientoOperacion);
				}
				else
				{
					dac.Update(_ExTabuladorProcedimientoOperacion);
				}
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public bool GuardaTabuladorProcedimientoOperacionBussines_TMP(ExTabuladorProcedimientoOperacion _ExTabuladorProcedimientoOperacion)
        {
            try
            {
                var dac = new DxTabuladorProcedimientoOperacion();
                //Actualiza
                if (_ExTabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion == 0)
                {
                    dac.SaveTMP(_ExTabuladorProcedimientoOperacion);
                }
                else
                {
                    dac.UpdateTMP(_ExTabuladorProcedimientoOperacion);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExTabuladorProcedimientoOperacion> GetByTabuladorTab(int idTabuladorTab)
		{
			return new DxTabuladorProcedimientoOperacion().GetByID(idTabuladorTab);
		}

        public bool puedeActualizar(int idprecliente)
        {
            return new DxTabuladorProcedimientoOperacion().puedeActualizar(idprecliente);
        }
    }
}
