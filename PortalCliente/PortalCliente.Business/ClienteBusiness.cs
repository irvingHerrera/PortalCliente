using System;
using System.Collections.Generic;
using System.Data;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;

namespace PortalCliente.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteBusiness()
        {
            clienteRepository = new ClienteRepository();
        }

        public string GenerarIdPreclienteVisual(string idPrecliente)
        {
            var precliente = "PRE_00000";

            precliente = precliente.Substring(0, (precliente.Length - 1) - (idPrecliente.Trim().Length - 1));

            return precliente + idPrecliente;
        }

        #region Metodos Privados

        private List<BusquedaPreclienteViewModel> ObtenerListaBusqueda(DataTable tabla)
        {
            var listaBusqueda = new List<BusquedaPreclienteViewModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                listaBusqueda.Add(new BusquedaPreclienteViewModel
                {
                    IdPrecliente = Convert.ToInt32(fila["id_precliente"].ToString()),
                    IdUsuario = Convert.ToInt32(fila["id_usuario"].ToString()),
                    IdPreclienteVisual = GenerarIdPreclienteVisual(fila["id_precliente"].ToString()),
                    NombreComercial = fila["nombre_comercial"].ToString().Trim(),
                    Estatus = (EstatusCliente)Enum.Parse(typeof(EstatusCliente), fila["estatus"].ToString()),
                });
            }

            return listaBusqueda;
        }

        public ClienteViewModel ObtenerModeloDireccion(DataTable tabla)
        {
            var direccion = new ClienteViewModel();
            var fila = tabla.Rows[0];

            direccion.Direccion = fila["direccion"].ToString();
            direccion.NombreComercial = fila["nombre_comercial"].ToString();

            return direccion;
        }

        #endregion


        public List<BusquedaPreclienteViewModel> ObtenerListaPrecliente(string banderilla)
        {
            var tabla = clienteRepository.ObtenerListaPreCliente(banderilla);
            var listaBusqueda = ObtenerListaBusqueda(tabla);
            return listaBusqueda;
        }

        public List<BusquedaPreclienteViewModel> ObtenerListaCliente(int GrupoEstatus)
        {
            var tabla = clienteRepository.ObtenerListaCliente(GrupoEstatus);
            var listaBusqueda = ObtenerListaBusqueda(tabla);
            return listaBusqueda;
        }

        public List<BusquedaPreclienteViewModel> ObtenerListaClienteAprobacion(int GrupoEstatus, int Rol, int id_usuario)
        {
            var tabla = clienteRepository.ObtenerListaClienteAprobacion(GrupoEstatus, Rol, id_usuario);
            var listaBusqueda = ObtenerListaBusqueda(tabla);
            return listaBusqueda;
        }

        public List<BusquedaPreclienteViewModel> ObtenerListaSoloClientes()
        {
            var tabla = clienteRepository.ObtenerListaSoloClientes();
            var listaBusqueda = ObtenerListaBusqueda(tabla);
            return listaBusqueda;
        }

        public List<BusquedaPreclienteViewModel> ObtenerListaSoloPreclientes()
        {
            var tabla = clienteRepository.ObtenerListaSoloPreclientes();
            var listaBusqueda = ObtenerListaBusqueda(tabla);
            return listaBusqueda;
        }

        public List<BusquedaPreclienteViewModel> ObtenerListaPreclienteActivo()
        {
            var tabla = clienteRepository.ObtenerListaPreClienteActivo();
            var listaBusqueda = ObtenerListaBusqueda(tabla);
            return listaBusqueda;
        }

        public ClienteViewModel ObtenerDirecionCliente(int idPreliente)
        {
            var tabla = clienteRepository.ObtenerDirecionCliente(idPreliente);
            var modelo = ObtenerModeloDireccion(tabla);
            return modelo;
        }

        public int? ActualizarEstatus(int idUsuario, int nuevoestatus)
        {
            var resultado = clienteRepository.ActualizarEstatus(idUsuario, nuevoestatus);
            return resultado;
        }

        public DataTable ObtenerUsrsCambioEstatus(int idPrecliente, int idEstatus)
        {
            var resultado = clienteRepository.ObtenerRelacionPreclienteAprobador(idPrecliente, idEstatus);
            return resultado;
        }
    }
}
