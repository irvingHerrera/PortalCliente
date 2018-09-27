using System.Collections.Generic;

namespace PortalCliente.Core.ViewModel.Tabuladores
{
    public class TabuladorDinamicoViewModel
    {
        public int IdTab { get; set; }
        public string TipoOperacion { get; set; }
        public CatalogoViewModel Aduana { get; set; }
        public CatalogoViewModel ClavePedimento { get; set; }
        public string Moneda { get; set; }
        public string Facturacion { get; set; }
        public string DiasLibres { get; set; }
        public List<EmpresaTabulador> Empresa { get; set; }
    }
}
