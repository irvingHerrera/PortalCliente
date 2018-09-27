using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel.RegistroCliente;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System.Collections.Generic;
using PortalCliente.Core.ViewModel;
using System;
using System.Data;
using PortalCliente.Core.Enum;

namespace PortalCliente.Business
{
    public class DatosUsuarioBusiness : IDatosUsuarioRepository
    {
        private readonly IDatosUsuarioRepository repositorio;

        #region Metodo Privador

        private DatosUsuarioViewModel ObtenerUsuarioViewModel(DataTable usuario)
        {
            var usuarioVM = new DatosUsuarioViewModel();
            DataRow fila = usuario.Rows[0];


            usuarioVM.IdUsuario = fila["id_usuario"].ToString().Trim();
            usuarioVM.Rol = (TipoRol)Enum.Parse(typeof(TipoRol), fila["id_rol"].ToString());
            usuarioVM.Nombre = fila["nombre"].ToString().Trim();
            usuarioVM.Usuario = fila["usuario"].ToString().Trim();
            usuarioVM.Correo = fila["correo"].ToString().Trim();
            usuarioVM.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            usuarioVM.IdPrecliente = fila["id_precliente"].ToString().Trim();

            return usuarioVM;
        }

        #endregion

        public DatosUsuarioBusiness()
        {
            repositorio = new DatosUsuarioRepository();
        }

        public DataTable ObtenerDatosUsuario(string usuario)
        {
            var lista = new DataTable();
            try
            {
                DatosUsuarioRepository obj = new DatosUsuarioRepository();
                lista = obj.ObtenerDatosUsuario(usuario);
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        public DatosUsuarioViewModel ObtenerDatosUsuarioModelo(string usuario)
        {
            var user = new DatosUsuarioViewModel();
            try
            {
                DatosUsuarioRepository obj = new DatosUsuarioRepository();
                var tabla = obj.ObtenerDatosUsuario(usuario);
                user = ObtenerUsuarioViewModel(tabla);
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public DataTable ValidarLogin(string usuario, string password)
        {
            var lista = new DataTable();
            try
            {
                DatosUsuarioRepository obj = new DatosUsuarioRepository();
                lista = obj.ValidarLogin(usuario, password);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

    }
}
