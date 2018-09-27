using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalCliente.Core.ViewModel.RegistroCliente
{
    public class DatoClienteViewModel
    {
        public DatoClienteViewModel()
        {

        }

        [Required]
        public int IdPrecliente { get; set; }
        [Required]
        public string NombreFiscal { get; set; }
        [Required]
        public string RepresentanteLegal { get; set; }
        [Required]
        public string NombreComercial { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string NoExt { get; set; }
        [Required]
        public string NoInt { get; set; }
        [Required]
        public string Colonia { get; set; }
        [Required]
        public CatalogoViewModel Ciudad { get; set; }
        [Required]
        public string CP { get; set; }
        [Required]
        public CatalogoViewModel Estado { get; set; }
        [Required]
        public CatalogoViewModel Pais { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Banco { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }
        [Required]
        public string ClabeInterbancaria { get; set; }
        [Required]
        public string Moneda { get; set; }
        [Required]
        public string SucursalBanco { get; set; }
        [Required]
        public string CiudadBanco { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        public string UsuarioModificacion { get; set; }

        [Required]
        public List<CuentaViewModel> Cuenta { get; set; }
        [Required]
        public List<ContactoViewModel> Contacto { get; set; }
    }
}
