using System;

namespace PortalCliente.Data.ENT
{
    public class ContactoDTO
    {
        public int IdContacto { get; set; }
        public int IdPreCliente { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Area { get; set; }
        public string PuestoDepartamento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
