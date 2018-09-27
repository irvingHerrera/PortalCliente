using System;

namespace PortalCliente.Data.ENT
{
    public class CuentaDTO
    {
        public int IdBanco { get; set; }
        public int IdPreCliente { get; set; }
        public string Banco { get; set; }
        public int NumeroCuenta { get; set; }
        public string Identificador { get; set; }
        public string PatentesAutorizadas { get; set; }
        public string Aduana { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
