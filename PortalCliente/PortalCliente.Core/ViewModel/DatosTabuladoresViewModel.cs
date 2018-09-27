using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Core.ViewModel
{
    public class DatosTabuladoresViewModel
    {
        public DatosTabuladoresViewModel()
        {

        }

        [Required]
        public int IdPrecliente { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string EjecutivoVenta { get; set; }
        [Required]
        public string EquipoOperativo { get; set; }
        [Required]
        public int TipoCliente { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public string ClientePedimento { get; set; }
        [Required]
        public bool SitioFTP { get; set; }
        [Required]
        public string DireccionPaginaWeb { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public bool EntregaFisica { get; set; }
        [Required]
        public string DiasRevicion { get; set; }
        [Required]
        public string HorarioRevision { get; set; }
        [Required]
        public string PersonasReciben { get; set; }
        [Required]
        public string NumJuegoCopia { get; set; }
        [Required]
        public string CalleNumero { get; set; }
        [Required]
        public string Colonia { get; set; }
        [Required]
        public CatalogoViewModel Estado { get; set; }
        [Required]
        public CatalogoViewModel Ciudad { get; set; }
        [Required]
        public string CP { get; set; }
        [Required]
        public bool ComprobadosCtePed { get; set; }
        [Required]
        public bool ComprobadosCeteFact { get; set; }
        [Required]
        public string ComprobadosEmpresaFactura { get; set; }

        [Required]
        public bool CtaAmericanaCtePed { get; set; }
        [Required]
        public bool CtaAmericanaCeteFact { get; set; }
        [Required]
        public string CtaAmericanaEmpresaFactura { get; set; }

        [Required]
        public bool HonorariosCtePed { get; set; }
        [Required]
        public bool HonorariosCeteFact { get; set; }
        [Required]
        public string HonorariosEmpresaFactura { get; set; }

        [Required]
        public bool ImpuestosCtePed { get; set; }
        [Required]
        public bool ImpuestosCeteFact { get; set; }
        [Required]
        public string ImpuestosEmpresaFactura { get; set; }

        [Required]
        public string CtaAMEFactura { get; set; }
        [Required]
        public string CtaAMEExpedida { get; set; }
        [Required]
        public string CtaAMECobra { get; set; }
        [Required]
        public string CtaAMEExpedidor { get; set; }

        [Required]
        public bool ImpuestoPeca { get; set; }

        [Required]
        public List<TabuladorDinamicoViewModel> TabuladorDinamico { get; set; }

        [Required]
        public string DatoAdicional { get; set; }
        [Required]
        public string MetodoPago { get; set; }
        [Required]
        public string UltimosDigitos { get; set; }
        [Required]
        public string Intrucciones { get; set; }

        [Required]
        public string CondicionPago { get; set; }
        [Required]
        public string PeriodoGracia { get; set; }
        [Required]
        public string DiasPago { get; set; }
        [Required]
        public string HorarioPago { get; set; }
        [Required]
        public bool SuspenderCliente { get; set; }

        [Required]
        public List<InformacionContacto> InformacionContacto { get; set; }
        [Required]
        public bool Fondo { get; set; }
        [Required]
        public int MontoFondo { get; set; }
        [Required]
        public bool Financiamiento { get; set; }
        [Required]
        public int Monto { get; set; }
        [Required]
        public string ParaUso { get; set; }
        [Required]
        public string PuntoReorden { get; set; }
        [Required]
        public string Recuperacion { get; set; }
        [Required]
        public string Plazo { get; set; }
        [Required]
        public string Condicion { get; set; }

        [Required]
        public List<TarifaServicio> TarifaServicio { get; set; }
        [Required]
        public int EstimadoVenta { get; set; }

    }
}
