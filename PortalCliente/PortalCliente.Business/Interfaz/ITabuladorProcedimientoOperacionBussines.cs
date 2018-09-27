using PortalCliente.Data.ENT;
using PortalCliente.Data.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
	interface ITabuladorProcedimientoOperacionBussines
	{
		bool GuardaTabuladorProcedimientoOperacionBussines(ExTabuladorProcedimientoOperacion _ExTabuladorProcedimientoOperacion);
		List<ExApliacacionPreferencia> GetApliacacionPreferencia();
		List<ExFormaPago> GetFormaPagos();
		List<ExIncoterm> GetExIncoterms();
		List<ExMetodoValoracion> GetExMetodoValoracions();
		List<ExRegimen> GetRegimens();
		List<ExTabuladorProcedimientoOperacion> GetByTabuladorTab(int idTabuladorTab);
    }
}
