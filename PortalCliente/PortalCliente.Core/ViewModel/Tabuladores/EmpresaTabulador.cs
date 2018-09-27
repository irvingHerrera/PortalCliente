namespace PortalCliente.Core.ViewModel.Tabuladores
{
    //grid del tabulador dinamico
    public class EmpresaTabulador
    {
        public string Empresa { get; set; }
        public CatalogoViewModel ConceptoFacturacion { get; set; }
        public CatalogoViewModel ConceptoAutoFacturacion { get; set; }
        public string TarifaVenta { get; set; }
        public string TarifaVentaMoneda { get; set; }
        public string TarifaCompra { get; set; }
        public string TarifaCompraMoneda { get; set; }
    }
}
