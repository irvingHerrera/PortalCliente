using PortalCliente.Business.Interfaz;
using PortalCliente.Core;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.Tabuladores;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business
{
    public class ConsultaBusiness : IConsultaBusiness
    {
        private readonly IConsultaRepository consultaRepository;

        public ConsultaBusiness()
        {
            consultaRepository = new ConsultaRepository();
        }

        private string GenerarIdPreclienteVisual(string idPrecliente)
        {
            var precliente = "PRE_00000";

            precliente = precliente.Substring(0, (precliente.Length - 1) - (idPrecliente.Trim().Length - 1));

            return precliente + idPrecliente;
        }

        #region

        private List<PreclientePendienteViewModel> ObtenerListaModelo(DataTable precliente)
        {
            var listaModelo = new List<PreclientePendienteViewModel>();

            foreach (DataRow fila in precliente.Rows)
            {
                listaModelo.Add(
                    new PreclientePendienteViewModel
                    {
                        Asignatario = fila["asignatario"].ToString(),
                        IdPrecliente = Convert.ToInt32(fila["id_precliente"].ToString()),
                        IdUsuario = Convert.ToInt32(fila["id_usuario"].ToString()),
                        NombreCliente = fila["nombre_comercial"].ToString(),
                        UsuarioTramite = fila["usuario_creacion"].ToString(),
                        IdPreclienteVisual = GenerarIdPreclienteVisual(fila["id_precliente"].ToString()),
                        InicioTramite = Convert.ToDateTime(fila["fecha_creacion"].ToString()),
                        Estatus = (EstatusCliente)Enum.Parse(typeof(EstatusCliente), fila["estatus"].ToString()),
                        DescripcionEstatus = ((EstatusCliente)Enum.Parse(typeof(EstatusCliente), fila["estatus"].ToString())).GetDescription()
                    }
                 );
            }

            return listaModelo;
        }

        #endregion

        public List<PreclientePendienteViewModel> ObtenerListaPreclientePendiente()
        {
            var tabla = consultaRepository.ObtenerListaPreclientesPendientes();
            var listaPrecliente = ObtenerListaModelo(tabla);

            return listaPrecliente;
        }

        public DataTable ObtenerInfoTabuladoresTEMP(int id_precliente)
        {
            var tabla = consultaRepository.ObtenerInfoTabuladoresTEMP(id_precliente);

            return tabla;
        }
        public DataTable ObtenerAprobacionDePreAltaCliente(int id_precliente)
        {
            var tabla = consultaRepository.ObtenerAprobacionDePreAltaCliente(id_precliente);

            return tabla;
        }
        public DataTable ObtenerAprobacionDeAltaCliente(int id_precliente)
        {
            var tabla = consultaRepository.ObtenerAprobacionDeAltaCliente(id_precliente);

            return tabla;
        }
        
    }
}
