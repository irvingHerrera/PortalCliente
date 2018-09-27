using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.ENT
{
    public class TabuladoresDTO
    {
        public TabuladoresDTO()
        {
            Contactos = new List<ContactosTabuladoresDTO>();
            Tarifas = new List<TarifasTabuladoresDTO>();
        }

        public int IdPrecliente { get; set; }
        public int IdUsuario { get; set; }
        public string EjecutivoVenta { get; set; }
        public string EquipoOperativo { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string RFC { get; set; }
        public string NombreCliente { get; set; }
        public string ClientePedimento { get; set; }
        public bool SitioFTP { get; set; }
        public string DireccionPaginaWeb { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool EntregaFisica { get; set; }
        public string DiasRevicion { get; set; }
        public string HorarioRevision { get; set; }
        public string PersonasReciben { get; set; }
        public string NumJuegoCopia { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public CatalogoViewModel Estado { get; set; }
        public CatalogoViewModel Ciudad { get; set; }
        public string CP { get; set; }
        public bool ComprobadosCtePed { get; set; }
        public bool ComprobadosCeteFact { get; set; }
        public string ComprobadosEmpresaFactura { get; set; }

        public bool CtaAmericanaCtePed { get; set; }
        public bool CtaAmericanaCeteFact { get; set; }
        public string CtaAmericanaEmpresaFactura { get; set; }

        public bool HonorariosCtePed { get; set; }
        public bool HonorariosCeteFact { get; set; }
        public string HonorariosEmpresaFactura { get; set; }

        public bool ImpuestosCtePed { get; set; }
        public bool ImpuestosCeteFact { get; set; }
        public string ImpuestosEmpresaFactura { get; set; }

        public string CtaAMEFactura { get; set; }
        public string CtaAMEExpedida { get; set; }
        public string CtaAMECobra { get; set; }
        public string CtaAMEExpedidor { get; set; }

        public bool ImpuestoPeca { get; set; }

        public List<TabuladorDinamicoViewModel> TabuladorDinamico { get; set; }

        public string DatoAdicional { get; set; }
        public string MetodoPago { get; set; }
        public string UltimosDigitos { get; set; }
        public string Intrucciones { get; set; }

        public string CondicionPago { get; set; }
        public string PeriodoGracia { get; set; }
        public string DiasPago { get; set; }
        public string HorarioPago { get; set; }
        public bool SuspenderCliente { get; set; }

        public List<InformacionContacto> InformacionContacto { get; set; }
        public bool Fondo { get; set; }
        public int MontoFondo { get; set; }
        public bool Financiamiento { get; set; }
        public int Monto { get; set; }
        public string ParaUso { get; set; }
        public string PuntoReorden { get; set; }
        public string Recuperacion { get; set; }
        public string Plazo { get; set; }
        public string Condicion { get; set; }

        public List<TarifaServicio> TarifaServicio { get; set; }
        public int EstimadoVenta { get; set; }
    }
}
