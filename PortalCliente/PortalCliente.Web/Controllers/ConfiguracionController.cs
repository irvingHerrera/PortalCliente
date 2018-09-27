using PortalCliente.Business;
using PortalCliente.Business.Interfaz;
using PortalCliente.Data.DAC;
using PortalCliente.Data.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class ConfiguracionController : Controller
    {
        private readonly IConfiguracionBusiness configuracionBusiness;

        public ConfiguracionController()
        {
            configuracionBusiness = new ConfiguracionBusiness();
        }

        // GET: Configuracion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerEquipoOperativo()
        {
            try
            {
                var listaEquipo = configuracionBusiness.ObtenerEquipoOperativo();

                if(listaEquipo != null)
                    return Json(new { resultado = true, data = listaEquipo }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

		[HttpPost]
		public ActionResult GuardaUsuario(ExUsuarios usuario)
		{
			try
			{

				var dac = new DxUsuarios();
			    var  existe = dac.Get().ToList().Where(x => x.usuario.ToLower().Trim() == usuario.usuario.ToLower().Trim()).FirstOrDefault();
				if (existe != null)
				{
					return Json(new { Resultado = false, Mensaje = "El usuario ya existe" });
				}
				usuario.fecha_creacion = DateTime.Now;
				usuario.fecha_modificacion = DateTime.Now;
				usuario.usuario_creacion = "";
                usuario.usuario_modificacion = "";
				dac.Save(usuario); 
				return Json(new { Resultado = true });
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpPost]
		public ActionResult UpdateUsuario(ExUsuarios usuario)
		{
			try
			{
				var dac = new DxUsuarios(); 
				var usuarioactual = dac.GetByID(usuario.id_usuario);
				usuarioactual.fecha_modificacion = DateTime.Now;
				usuarioactual.contrasenia = usuario.contrasenia;
				usuarioactual.correo = usuario.correo;
				usuarioactual.id_rol = usuario.id_rol;
				usuarioactual.nombre = usuario.nombre;
				usuarioactual.usuario = usuario.usuario;
                usuarioactual.Activo = usuario.Activo;
                usuarioactual.grupo = usuario.grupo; 
				dac.Update(usuarioactual);
				return Json(new { Resultado = true });
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpPost]
		public ActionResult DeleteUsuario(int id,bool activar)
		{
			try
			{
				var dac = new DxUsuarios();
				var usuarioactual = dac.GetByID(id);
                usuarioactual.Activo = activar;
				dac.Delete(usuarioactual); 
				return Json(new { Resultado = true });
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpGet]
		public ActionResult GetUsuarios()
		{
			var dac = new DxUsuarios();
			var _usuarios = dac.Get();
			return Json(new { usuarios = _usuarios }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult GetUsuarioById(int id)
		{

			var dac = new DxUsuarios();
			var usuarioactual = dac.GetByID(id);
			return Json(new { usuario = usuarioactual }, JsonRequestBehavior.AllowGet);

		}

		[HttpGet]
		public ActionResult GetRoles()
		{
			try
			{
				DxRoles dac = new DxRoles();
				var roles = dac.Get();
				return Json(roles, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}			
		}

		[HttpPost]
		public ActionResult AddRol(ExRoles rol)
		{
			try
			{
                var modulos = rol.descripcion.Split('#')[1].Split('|');
                rol.fecha_creacion = DateTime.Now;
				rol.fecha_modificacion = DateTime.Now;
				rol.usuario_creacion = "";
				rol.usuario_modificacion = "";
                rol.descripcion = rol.descripcion.Split('#')[0];
				var idrol = new DxRoles().Save(rol);
                var dacrel = new DxRolesModulos();
                foreach (var v in modulos)
                {
                    dacrel.Save(new ExRolesModulos { fecha_creacion = DateTime.Now, fecha_modificacion = DateTime.Now, id_modulo = Convert.ToInt32(v), id_rol = idrol, usuario_creacion = "admin", usuario_modificacion = "admin" });
                }


                return Json(new { Resultado = true });
			}
			catch (Exception ex)
			{
			    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpPost]
		public ActionResult EditRol(ExRoles rol)
		{
			try
			{
				var modulos = rol.descripcion.Split('#')[1].Split('|');
				//var dac = new DxRoles();
				//var rolactual = dac.GetByID(rol.id_rol);
				//rolactual.fecha_modificacion = DateTime.Now;
				//rolactual.descripcion = rol.descripcion.Split('#')[0];
				//dac.Update(rolactual);

				var mod = new DxRolesModulos();
				var todos = mod.Get();
			    var borrar = todos.Where(x => x.id_rol == rol.id_rol).ToList();
				foreach (var v in borrar)
				{
					mod.Delete(v);
				}

				foreach (var v in modulos)
				{
					mod.Save(new ExRolesModulos { fecha_creacion = DateTime.Now, fecha_modificacion = DateTime.Now, id_modulo = Convert.ToInt32(v), id_rol = rol.id_rol, usuario_creacion = "admin", usuario_modificacion = "admin" });
				}
				return Json(new { Resultado = true });
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpGet]
		public ActionResult GetRolByID(int id)
		{
			try
			{
				var rol = new DxRoles().GetByID(id);
				return Json(rol, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message });
			}
		}

		[HttpGet]
		public ActionResult GetModulos()
		{
			try
			{
				var _modulos = new DxModulos().Get();
				return Json(new { modulos = _modulos }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public ActionResult GetModulosByRol(int idrol)
		{
			try
			{
			   var rolmod = new DxRolesModulos().Get().Where(x => x.id_rol == idrol);
				List<ExModulos> _modulos = new List<ExModulos>();
				var dac = new DxModulos();
				foreach (var v in rolmod)
				{
					var m = dac.GetByID(v.id_modulo);
					_modulos.Add(m);
				}
				return Json(new { modulos = _modulos }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message },JsonRequestBehavior.AllowGet);
			}
		}


		[HttpGet]
		public ActionResult Getnextprecliente()
		{
			try
			{
				var user = new DxUsuarios().getnextprecliente();
				return Json(new { next = user.id_usuario }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				return Json(new { Resultado = false, Error = ex.Message }, JsonRequestBehavior.AllowGet);
			}
		}

        [HttpGet]
        public ActionResult ExisteAuda(string usuario)
        {
            try
            {
                var existe = new DxUsuarios().ExisteEnAudasis(usuario);
                return Json(new { res = existe  }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { Resultado = false, Error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }





    }
}