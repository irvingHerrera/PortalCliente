using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
	public class ExTabuladorProcedimientoOperacion
	{

		public int Id_abuladorProcedimientoOperacion { get; set; }
		public int Id_Tabulador { get; set; }
		public string DescripcionOperacion { get; set; }
		public string FormaConsigueMenrcancia { get; set; }
		public string ContactoOperativo { get; set; }
		public string ContactoCliente { get; set; }
		public string ObservacionesEspecificas { get; set; }
		public string AperturaConsolidados { get; set; }
		public string EnvioInformacionDocumentos { get; set; }
		public string Clasificacion { get; set; }
		public int Id_TipodePedimento { get; set; }
		public int Id_Regimen { get; set; }
		public int Id_ManejodePedimento { get; set; }
		public int Id_Incoterm { get; set; }
		public int Id_MetodoValoracion { get; set; }
		public int Id_FormaPago { get; set; }
		public bool Vinculacion { get; set; }
		public int Id_AplicacionPreferencias { get; set; }
		public bool AplicacionTLCAN { get; set; }
		public bool Incrementables { get; set; }
		public bool EnvioProformaAutorizacion { get; set; }
		public bool GrupoGeneralEEI { get; set; }
		public string ObservacionesEspecificasDM { get; set; }
		public string Recibo { get; set; }
		public string Descarga { get; set; }
		public string Previo { get; set; }
		public string ReporteDanos { get; set; }
		public string Carga { get; set; }
		public string CoordinacionTransporte { get; set; }
		public string EntregaMercancias { get; set; }
		public string ServiciosExtraordinarios { get; set; }
		public Decimal? Monto { get; set; }
		public string Parausoen { get; set; }
		public string PuntoReorden { get; set; }
		public string Recuperacion { get; set; }
		public int? Plazo { get; set; }
		public string Condiciones { get; set; }
		public string Facturacion { get; set; }
		public string Cobranza { get; set; }
		public string IndicadoresDesempeno { get; set; }
		public string KPI { get; set; }
		public string Reportes { get; set; }
		public string HCMVDos { get; set; }
		public string PostVenta { get; set; }
        public string ObservacionesEspecificasEP { get; set; }

        //descripcionesdecatalogos 
        public string Id_AplicacionPreferenciasDES { get; set; }
        public string Id_IncotermDES { get; set; }
        public string Id_MetodoValoracionDES { get; set; }
        public string Id_FormaPagoDES { get; set; }
        public string Id_RegimenDES { get; set; }
        public string Id_TipodePedimentoDES { get; set; }
        public string Id_ManejodePedimentoDES { get; set; }

        public List<ExContactoGruposEI> ContactosEI { get; set; } 



    }
}
