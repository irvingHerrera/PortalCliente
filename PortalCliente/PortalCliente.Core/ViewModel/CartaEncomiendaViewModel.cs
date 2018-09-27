using System;

namespace PortalCliente.Business
{
    public class CartaEncomiendaViewModel
    {
        public int IdPrecliente { get; set; }
        public int IdUsuario { get; set; }
        public string MembreteEmpresa { get; set; }
        public string NumeroEscritura { get; set; }
        public string NombreNotarioPublico { get; set; }
        public string EstadoNotariado { get; set; }
        public string CiudadNotariado { get; set; }
        public string NumeroNotaria { get; set; }
        public string NombreAgenteAduanal { get; set; }
        public string Patente { get; set; }
        public string DirreccionPatente { get; set; }
        public DateTime PeriodoCompredidoInicio { get; set; }
        public DateTime PeriodoCompredidoFin { get; set; }

    }
}
