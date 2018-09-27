using System.Collections.Generic;

namespace PortalCliente.Data.ENT
{
    public class TabuladorDinamicoDTO
    {
        public int IdTab { get; set; }
        public string TipoOperacion { get; set; }
        public CatalogoDTO Aduana { get; set; }
        public CatalogoDTO ClavePedimento { get; set; }
        public string Moneda { get; set; }
        public string Facturacion { get; set; }
        public string DiasLibres { get; set; }
        public List<EmpresaTabuladorDTO> Empresa { get; set; }
    }
}
