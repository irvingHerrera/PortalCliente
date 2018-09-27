using PortalCliente.Business.Impresion;
using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel;
using PortalCliente.Data.DAC;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PortalCliente.Business
{
    public class ImpresionBusiness : IImpresionBusiness
    {
        private readonly IImpresionRepository impresionRepository;
        private readonly ICapturaClienteRepository capturaClienteRepository;
        private readonly IClienteRepository clienteRepository;

        public ImpresionBusiness()
        {
            impresionRepository = new ImpresionRepository();
            capturaClienteRepository = new CapturaClienteRepository();
            clienteRepository = new ClienteRepository();
        }

        private DataTable ObtenerTablaEmpresa()
        {
            var tabla = new DataTable();

            tabla.Columns.Add("empresa");
            tabla.Columns.Add("concepto_facturacion");
            tabla.Columns.Add("concepto_auto_facturacion");
            tabla.Columns.Add("tarifa_venta");
            tabla.Columns.Add("tarifa_venta_tipo_moneda");
            tabla.Columns.Add("tarifa_compra");
            tabla.Columns.Add("tarifa_compra_tipo_moneda");
            tabla.Columns.Add("id_tabulador_tab");
            tabla.Columns.Add("descripcion_autofacturacion");
            tabla.Columns.Add("descripcion_facturacion");

            return tabla;
        }

        #region Metodos Privados

        private DocumentoViewModel ObtenerModeloDocumento(DataTable tablaDocumento)
        {
            var modeloDocumento = new DocumentoViewModel();
            if (tablaDocumento.Rows.Count > 0)
            {
                var fila = tablaDocumento.Rows[0];

                modeloDocumento.IdDocumento = Convert.ToInt32(fila["id_precliente"].ToString());
                modeloDocumento.IdPrecliente = Convert.ToInt32(fila["id_documento"].ToString());
                modeloDocumento.RutaLocal = fila["ruta_local"].ToString();
                modeloDocumento.ExisteDocumento = true;
            }
            else
            {
                modeloDocumento.ExisteDocumento = false;
            }

            return modeloDocumento;
        }

        private TabuladorModelo ObtenerModeloTabulador(int idPrecliente)
        {
            var modelo = new TabuladorModelo();

            var empresas = ObtenerTablaEmpresa();
            var tabulador = capturaClienteRepository.BuscarDatosTabuladores(idPrecliente.ToString());
            var tabuladorContacto = capturaClienteRepository.BuscarDatosTabuladoresContactos(idPrecliente.ToString());
            var tabuladorTarifa = capturaClienteRepository.BuscarDatosTabuladoresTarifas(idPrecliente.ToString());
            var tabuladorTabs = capturaClienteRepository.BuscarDatosTabuladoresTabs(idPrecliente.ToString());
            

            foreach (DataRow tab in tabuladorTabs.Rows)
            {
                var empresa = capturaClienteRepository.BuscarDatosTabuladoresEmpresa(tab["id_tabulador_tab"].ToString());

                foreach (DataRow item in empresa.Rows)
                {
                    empresas.Rows.Add(item.ItemArray);
                }
            }

            modelo.Tabulador = tabulador;
            modelo.TabuladorContacto = tabuladorContacto;
            modelo.TabuladorTarifa = tabuladorTarifa;
            modelo.TabuladorTabs = tabuladorTabs;
            modelo.TabuladorEmpresa = empresas;
            
            return modelo;
        }

        private List<ProcedimientoModelo> ObtenerModeloProcedimientoOperacion(int idPrecliente, int idUsuario)
        {
            var cuentasPeca = capturaClienteRepository.ObtenerCtasBancPECACliente(idPrecliente.ToString());
            var dirreccion = clienteRepository.ObtenerDirecionCliente(idPrecliente);
            var numeroTabs = capturaClienteRepository.ObtenerNumeroTabuladores(idUsuario, idPrecliente);
            var numeroTab = Convert.ToInt32(numeroTabs.Rows[0][0].ToString());
            var datosProcedimiento = new DxTabuladorProcedimientoOperacion().GetByID(idPrecliente);
            var contacto = clienteRepository.ObtieneContactosPorPrecliente(idPrecliente.ToString());
            var titulo = new ClienteRepository().ObtenerTituloSecciones(idPrecliente);


            var listaModelo = new List<ProcedimientoModelo>();


            for (int i = 0; i < numeroTab; i++)
            {
                listaModelo.Add(new ProcedimientoModelo
                {
                    Cuentas = cuentasPeca,
                    Dirreccion = dirreccion,
                    Contactos = contacto,
                    DatoProcedimiento = datosProcedimiento[i],
                    Titulo = titulo
                });
            }

            return listaModelo;
        }

        private List<DocumentoViewModel> ObtenerListaDocumento(DataTable tabla)
        {
            var listaDocumento = new List<DocumentoViewModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                listaDocumento.Add(new DocumentoViewModel
                {
                    ExisteDocumento = true,
                    IdDocumento = Convert.ToInt32(fila["id_documento"].ToString()),
                    IdPrecliente = Convert.ToInt32(fila["id_precliente"].ToString()),
                    RutaLocal = fila["ruta_local"].ToString()
                });
            }

            return listaDocumento;
        }

        #endregion

        public DocumentoViewModel ObtenerExpedienteCliente(int idPrecliente)
        {
            var tabla = impresionRepository.ObtenerExpedienteCliente(idPrecliente);
            if (tabla != null)
            {
                var documento = ObtenerModeloDocumento(tabla);
                return documento;
            }
            else
            {
                return null;
            }

        }

        public DocumentoViewModel ReporteSolicitudCliente(int idPrecliente, int idUsuario, string path)
        {
            var resultado = string.Empty;
            ReporteImpresion reporte = new ReporteImpresion();

            var tablaInformacionCliente = capturaClienteRepository.ObtenerInfoCliente(idUsuario.ToString());
            var tablaContacto = capturaClienteRepository.ObtenerContactosCliente(idPrecliente.ToString());
            var tablaBanco = capturaClienteRepository.ObtenerCtasBancPECACliente(idPrecliente.ToString());
            var modeloReporte = new SolicitudClienteModelo()
            {
                InformacionCliente = tablaInformacionCliente,
                InformacionContacto = tablaContacto,
                InformacionCuenta = tablaBanco
            };

            resultado = reporte.ReporteSolicitudCliente(modeloReporte, path);

            var documento = new DocumentoViewModel()
            {
                ExisteDocumento = string.IsNullOrEmpty(resultado) ?  false : true,
                RutaLocal = resultado
            };

            return documento;
        }

        public DocumentoViewModel ReporteProcedimientoOperacion(int idPrecliente, int idUsuario, string path)
        {
            var resultado = string.Empty;
            ReporteImpresion reporte = new ReporteImpresion();

            try
            {
                var listaModelo = ObtenerModeloProcedimientoOperacion(idPrecliente, idUsuario);
                resultado = reporte.ReporteProcedimientoOperacion(listaModelo, path);

                var documento = new DocumentoViewModel()
                {
                    ExisteDocumento = string.IsNullOrEmpty(resultado) ? false : true,
                    RutaLocal = resultado
                };

                return documento;
            }
            catch (Exception ex)
            {
                return new DocumentoViewModel { ExisteDocumento = false };
            }
        }

        public DocumentoViewModel ReporteTabulador(int idPrecliente, string path)
        {
            var resultado = string.Empty;
            ReporteImpresion reporte = new ReporteImpresion();

            try
            {
                var modelo = ObtenerModeloTabulador(idPrecliente);

                resultado = reporte.ReporteTabulador(modelo, path);

                var documento = new DocumentoViewModel()
                {
                    ExisteDocumento = string.IsNullOrEmpty(resultado) ? false : true,
                    RutaLocal = resultado
                };

                return documento;
            }
            catch (Exception ex)
            {
                return new DocumentoViewModel { ExisteDocumento = false };
            }
        }

        public List<DocumentoViewModel> ObtenerDocumentoCliente(int idPrecliente)
        {
            try
            {
                var tabla = capturaClienteRepository.ObtenerDocumentosCliente(idPrecliente.ToString());
                var listaDocumento = ObtenerListaDocumento(tabla);

                listaDocumento = listaDocumento.Where(l => l.IdDocumento != 11).ToList();

                return listaDocumento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DocumentoViewModel> ObtenerDocumentoClienteExpediente(int idPrecliente)
        {
            try
            {
                var tabla = capturaClienteRepository.ObtenerDocumentosClienteExpediente(idPrecliente.ToString());
                var listaDocumento = ObtenerListaDocumento(tabla);

                listaDocumento = listaDocumento.Where(l => l.IdDocumento != 11).ToList();

                return listaDocumento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
