using PortalCliente.Data.ENT;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business.Impresion
{
    public class ProcedimientoModelo
    {
        public DataTable Cuentas { get; set; }
        public DataTable Dirreccion { get; set; }
        public ExTabuladorProcedimientoOperacion DatoProcedimiento { get; set; }
        public List<ContactoDTO> Contactos { get; set; }
        public List<SeccionesDTO> Titulo { get; set; }
    }
}
