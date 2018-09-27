using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PortalCliente.Business;
using System.Data;
using PortalCliente.Core;

namespace PortalCliente.Web.Controllers
{
    public class LoginController : Controller
    {
        private DatosUsuarioBusiness obj;

        public LoginController()
        {
            obj = new DatosUsuarioBusiness();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        #region Metodo Privados

        private void ObtenerDatosUsuario(string usuarioLogin)
        {
            var user = obj.ObtenerDatosUsuarioModelo(usuarioLogin);
            AplicacionDatoUsuario.Instancia.Usuario = user;
        }

        #endregion

        public ActionResult ValidarLogin(string user, string pass)
        {
            var salida = obj.ValidarLogin(user, pass);
            string resultado = "";
            foreach (DataRow row in salida.Rows)
            {
                resultado = row["Resultado"].ToString();
            }
            if (resultado == "1")
            {
                var vista = string.Empty;
                var controlador = string.Empty;

                ObtenerDatosUsuario(user);

                if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.Cliente)
                {
                    vista = "Index";
                    controlador = "RegistroCliente";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.EjecutivoVenta)
                {
                    vista = "Index";
                    controlador = "CapturaCliente";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.AltaCliente)
                {
                    vista = "Index";
                    controlador = "AltaCliente";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.Aprobacion ||
                    AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.GerenteComercial ||
                    AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.Lider)
                {
                    vista = "Index";
                    controlador = "Aprobacion";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.EjecutivoVenta ||
                    AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.GerenteComercial ||
                    AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.Aprobacion ||
                    AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.AltaCliente)
                {
                    vista = "Index";
                    controlador = "Consulta";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.AltaCliente)
                {
                    vista = "Index";
                    controlador = "ActualizarCliente";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.AltaCliente ||
                    AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.EjecutivoVenta)
                {
                    vista = "Index";
                    controlador = "Impresion";
                }
                else if (AplicacionDatoUsuario.Instancia.Usuario.Rol == Core.Enum.TipoRol.Administrador)
                {
                    vista = "Index";
                    controlador = "Configuracion";
                }
                return RedirectToAction(vista, controlador);
            }
            else if(resultado == "2")
            {
                LoginMensaje.Instancia.Mensaje = "Precliente con documentación en revisión.";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginMensaje.Instancia.Mensaje = "Usuario y/o contraseña erróneos, verifica.";
                return RedirectToAction("Index", "Login");
            }
        }
    }

}