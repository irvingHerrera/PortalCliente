using PortalCliente.Business.Interfaz;
using PortalCliente.Core;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.Tabuladores;
using PortalCliente.Data.DAC;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business
{
    public class ActualizarClienteBussiness : IActualizarClienteBussiness
    {
        private readonly IActualizarClienteRepository actualizaCteRepo;

        public ActualizarClienteBussiness()
        {
            actualizaCteRepo = new ActualizarClienteRepository();
        }
        public bool GuardarDatoOperacion(TabuladorViewModel tabulador)
        {
            var dto = ObtenerDTOTabuladores(tabulador);

            try
            {
                var resultado = actualizaCteRepo.GuardarDatoOperacion(dto);

                if (resultado != null)
                    return resultado.Value > 0 ? true : false;
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #region "Generadores de estructuras para guardar dato de operacion"
        private List<InformacionContactoDTO> ObtenerDTOContactosTabuladores(List<InformacionContacto> contactos)
        {
            var dto = new List<InformacionContactoDTO>();
            foreach (var contacto in contactos)
            {
                dto.Add(new InformacionContactoDTO
                {
                    Contacto = contacto.Contacto,
                    Nombre = contacto.Nombre,
                    Puesto = contacto.Puesto,
                    Telefono = contacto.Telefono,
                    Email = contacto.Email
                });
            }
            return dto;
        }

        private List<TarifaServicioDTO> ObtenerDTOTarifasTabuladores(List<TarifaServicio> tarifas)
        {
            var dto = new List<TarifaServicioDTO>();
            foreach (var tarifa in tarifas)
            {
                dto.Add(new TarifaServicioDTO
                {
                    Servicio = tarifa.Servicio,
                    Notas = tarifa.Notas,
                    Tarifa = tarifa.Tarifa
                });
            }
            return dto;
        }
        private List<TabuladorDinamicoDTO> ObtenerDTOTabuladorDinamicoTabuladores(List<TabuladorDinamicoViewModel> dinamicos)
        {
            var dto = new List<TabuladorDinamicoDTO>();

            foreach (var dinamico in dinamicos)
            {
                dto.Add(new TabuladorDinamicoDTO
                {
                    IdTab = dinamico.IdTab,
                    Empresa =  ObtenerDTOEmpresasTabuladores(dinamico.Empresa),
                    TipoOperacion = dinamico.TipoOperacion,
                    Aduana = ObtenerDTOCatalogo(dinamico.Aduana),
                    ClavePedimento = ObtenerDTOCatalogo(dinamico.ClavePedimento),
                    Moneda = dinamico.Moneda,
                    Facturacion = dinamico.Facturacion,
                    DiasLibres = dinamico.DiasLibres
                });
            }
            return dto;
        }
        private List<EmpresaTabuladorDTO> ObtenerDTOEmpresasTabuladores(List<EmpresaTabulador> empresas)
        {
            var dto = new List<EmpresaTabuladorDTO>();
            foreach (var empresa in empresas)
            {
                dto.Add(new EmpresaTabuladorDTO
                {
                    Empresa = empresa.Empresa,
                    ConceptoFacturacion = ObtenerDTOCatalogo(empresa.ConceptoFacturacion),
                    ConceptoAutoFacturacion = ObtenerDTOCatalogo(empresa.ConceptoAutoFacturacion),
                    TarifaVenta = empresa.TarifaVenta,
                    TarifaVentaMoneda = empresa.TarifaVentaMoneda,
                    TarifaCompra = empresa.TarifaCompra,
                    TarifaCompraMoneda = empresa.TarifaCompraMoneda
                });
            }
            return dto;
        }
        private CatalogoDTO ObtenerDTOCatalogo(CatalogoViewModel concepto)
        {
            var dto = new CatalogoDTO();
            dto.Descripcion = concepto.Descripcion;
            dto.ID = concepto.id;
            return dto;
        }
        private TabuladorDTO ObtenerDTOTabuladores(TabuladorViewModel tabulador)
        {
            var dto = new TabuladorDTO();

            dto.InformacionContacto = ObtenerDTOContactosTabuladores(tabulador.InformacionContacto);
            dto.TarifaServicio = ObtenerDTOTarifasTabuladores(tabulador.TarifaServicio);
            dto.TabuladorDinamico = ObtenerDTOTabuladorDinamicoTabuladores(tabulador.TabuladorDinamico);

            dto.IdPrecliente = tabulador.IdPrecliente;
            dto.IdUsuario = tabulador.IdUsuario;
            dto.EjecutivoVenta = tabulador.EjecutivoVenta;
            dto.EquipoOperativo = (tabulador.EquipoOperativo??new EquipoOperativoViewModel()).IdEquipo.ToString();
            dto.TipoCliente = tabulador.TipoCliente;
            dto.RFC = tabulador.RFC;
            dto.NombreCliente = tabulador.NombreCliente;
            dto.ClientePedimento = tabulador.ClientePedimento;
            dto.SitioFTP = tabulador.SitioFTP;
            dto.DireccionPaginaWeb = tabulador.DireccionPaginaWeb;
            dto.Usuario = tabulador.Usuario;
            dto.Contrasena = tabulador.Contrasena;
            dto.EntregaFisica = tabulador.EntregaFisica;
            dto.DiasRevision = tabulador.DiasRevision;
            dto.HorarioRevision = tabulador.HorarioRevision;
            dto.PersonasReciben = tabulador.PersonasReciben;
            dto.NumJuegoCopia = tabulador.NumJuegoCopia;
            dto.CalleNumero = tabulador.CalleNumero;
            dto.Colonia = tabulador.Colonia;
            /*
            dto.Estado.ID = tabulador.Estado.id;
            dto.Estado.Descripcion = tabulador.Estado.Descripcion;
            dto.Ciudad.ID = tabulador.Ciudad.id;
            dto.Ciudad.Descripcion = tabulador.Ciudad.Descripcion;
            */
            if (tabulador.Estado != null)
            {
                dto.Estado = tabulador.Estado.id;
            }
            else
            {
                dto.Estado = "0";
            }
            if (tabulador.Ciudad != null)
            {
                dto.Ciudad = tabulador.Ciudad.id;
            }
            else
            {
                dto.Ciudad = "0";
            }
            dto.CP = tabulador.CP;
            dto.ComprobadosCtePed = tabulador.ComprobadosCtePed;
            dto.ComprobadosCeteFact = tabulador.ComprobadosCeteFact;
            dto.ComprobadosEmpresaFactura = tabulador.ComprobadosEmpresaFactura;
            dto.CtaAmericanaCtePed = tabulador.CtaAmericanaCtePed;
            dto.CtaAmericanaCeteFact = tabulador.CtaAmericanaCeteFact;
            dto.CtaAmericanaEmpresaFactura = tabulador.CtaAmericanaEmpresaFactura;
            dto.HonorariosCtePed = tabulador.HonorariosCtePed;
            dto.HonorariosCeteFact = tabulador.HonorariosCeteFact;
            dto.HonorariosEmpresaFactura = tabulador.HonorariosEmpresaFactura;
            dto.ImpuestosCtePed = tabulador.ImpuestosCtePed;
            dto.ImpuestosCeteFact = tabulador.ImpuestosCeteFact;
            dto.ImpuestosEmpresaFactura = tabulador.ImpuestosEmpresaFactura;
            dto.CtaAMEFactura = tabulador.CtaAMEFactura;
            dto.CtaAMEExpedida = tabulador.CtaAMEExpedida;
            dto.CtaAMECobra = tabulador.CtaAMECobra;
            dto.CtaAMEExpedidor = tabulador.CtaAMEExpedidor;
            dto.ImpuestoPeca = tabulador.ImpuestoPeca;
            dto.DatoAdicional = tabulador.DatoAdicional;
            dto.MetodoPago = tabulador.MetodoPago;
            dto.UltimosDigitos = tabulador.UltimosDigitos;
            dto.Intrucciones = tabulador.Intrucciones;
            dto.CondicionPago = tabulador.CondicionPago;
            dto.PeriodoGracia = tabulador.PeriodoGracia;
            dto.DiasPago = tabulador.DiasPago;
            dto.HorarioPago = tabulador.HorarioPago;
            dto.SuspenderCliente = tabulador.SuspenderCliente;
            dto.Fondo = tabulador.Fondo;
            dto.MontoFondo = tabulador.MontoFondo;
            dto.Financiamiento = tabulador.Financiamiento;
            dto.Monto = tabulador.Monto;
            dto.ParaUso = tabulador.ParaUso;
            dto.PuntoReorden = tabulador.PuntoReorden;
            dto.Recuperacion = tabulador.Recuperacion;
            dto.Plazo = tabulador.Plazo;
            dto.Condicion = tabulador.Condicion;
            dto.EstimadoVenta = tabulador.EstimadoVenta;

            dto.Banco = tabulador.Banco;
            dto.BancoId = tabulador.BancoId;

            return dto;
        }
        #endregion

        public List<ExTabuladorProcedimientoOperacion> GetByTabuladorTab(int idTabuladorTab)
        {
            var tabuladores = new DxTabuladorProcedimientoOperacion().GetByIDTMP(idTabuladorTab);

            if (tabuladores.Count == 0) new DxTabuladorProcedimientoOperacion().GetByID(idTabuladorTab);

            return tabuladores;
        }

        public DataTable BuscarDatosTabuladores(string id_precliente, ref bool temporal)
        {
            var dto = new DataTable();
            try
            {
                dto = actualizaCteRepo.BuscarDatosTabuladores(id_precliente, ref temporal);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresContactos(string id_precliente, bool temporal)
        {
            var dto = new DataTable();
            try
            {
                dto = actualizaCteRepo.BuscarDatosTabuladoresContactos(id_precliente, temporal);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresTarifas(string id_precliente, bool temporal)
        {
            var dto = new DataTable();
            try
            {
                dto = actualizaCteRepo.BuscarDatosTabuladoresTarifas(id_precliente, temporal);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresTabs(string id_precliente, bool temporal)
        {
            var dto = new DataTable();
            try
            {
                dto = actualizaCteRepo.BuscarDatosTabuladoresTabs(id_precliente, temporal);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresEmpresa(string id_tabulador_tab, bool temporal)
        {
            var dto = new DataTable();
            List<EmpresaTabuladorDTO> empresas = new List<EmpresaTabuladorDTO>();
            EmpresaTabuladorDTO empresa;
            try
            {
                dto = actualizaCteRepo.BuscarDatosTabuladoresEmpresa(id_tabulador_tab, temporal);
                foreach (DataRow dr in dto.Rows)
                {
                    empresa = new EmpresaTabuladorDTO();
                    //empresa.Empresa = 

                    //list.Add(dr);

                }
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }
    }
}
