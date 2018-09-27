namespace PortalCliente.Core.ViewModel
{
    public class SistemasOperativosViewModel 
    {
        public int ID_precliente { get; set; }
        public bool ADUASIS { get; set; }
        public bool GP { get; set; }
        public EquipoOperativoViewModel Equipo { get; set; }
        public string Correos { get; set; }
    }
}
