using System;
using System.Collections.Generic;

namespace PortalCliente.Data.ENT
{
    public class ClienteDTO
    {
        public ClienteDTO()
        {
            Contacto = new List<ContactoDTO>();
            Cuenta = new List<CuentaDTO>();
        }

        public int IdPreCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdClienteAduasis { get; set; }
        public int IdClienteGP { get; set; }
        public bool EsCliente { get; set; }
        public string RepresentanteLegal { get; set; }
        public string NombreFiscal { get; set; }
        public string RFC { get; set; }
        public string NombreComercial { get; set; }
        public string Calle { get; set; }
        public string NoExt { get; set; }
        public string NoInt { get; set; }
        public string Colonia { get; set; }
        public string IdCiudad { get; set; }
        public string CP { get; set; }
        public string IdEstado { get; set; }
        public string IdPais { get; set; }
        public string Telefono { get; set; }
        public string Giro { get; set; }
        public string TiempoEstablecido { get; set; }
        public int NumeroEmpleado { get; set; }
        public decimal VentaAnual { get; set; }
        public string PaginaWeb { get; set; }
        public string PatentesOperacion { get; set; }
        public string FrecuentaEmbarques { get; set; }
        public bool VucemCliente { get; set; }
        public bool VucemGrupoei { get; set; }
        public string CorreosArriboEmbarque { get; set; }
        public string Banco { get; set; }
        public string NumeroCuenta { get; set; }
        public string ClabeInterbancaria { get; set; }
        public string Moneda { get; set; }
        public string SucursalBanco { get; set; }
        public string CiudadBanco { get; set; }
        public string Certificacion { get; set; }
        public string Certificacion2 { get; set; }
        public string NumeroPuertos { get; set; }
        public bool ConCartaEncomiendaRespaldo { get; set; }
        public string MotivoSinCartaEncomiendaRespaldo { get; set; }
        public bool Banderilla { get; set; }
        public int Estatus { get; set; }
        public bool AceptacionTerminosCondiciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

		public string domicilio_fiscal_calle { get; set; }

		public string domicilio_fiscal_ciudad { get; set; }

		public string domicilio_fiscal_colonia { get; set; }

		public string domicilio_fiscal_cp { get; set; }

		public string domicilio_fiscal_estado { get; set; }

		public string domicilio_fiscal_municipio { get; set; }

		public string domicilio_fiscal_no_ext { get; set; }

		public string domicilio_fiscal_no_int { get; set; }




		public List<CuentaDTO> Cuenta { get; set; }
        public List<ContactoDTO> Contacto { get; set; }
        public CuestionarioDTO Cuestionario { get; set; }
        public List<ExUsuariosAudabook> Usuarios { get; set; }
		public List<ExDocumentos> Documentos { get; set; }


        public string ObtenerDomicilioFiscal
        {
            get
            {
                return string.Join(", ", Calle, NoExt, NoInt,
                                         Colonia, Ciudad, CP,
                                         Ciudad,Estado);
            }
        }
    }
}
