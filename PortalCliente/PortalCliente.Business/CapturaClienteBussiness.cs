using PortalCliente.Business.Interfaz;
using PortalCliente.Core;
using PortalCliente.Core.Enum;
using PortalCliente.Core.ViewModel;
using PortalCliente.Core.ViewModel.RegistroCliente;
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
    public class CapturaClienteBussiness : ICapturaClienteBussiness
    {
        private readonly ICapturaClienteRepository repositorioRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IRegistroClienteRepository registroClienteRepository;
        private readonly INotificacionRepository notificacionRepository;

        public CapturaClienteBussiness()
        {
            repositorioRepository = new CapturaClienteRepository();
            clienteRepository = new ClienteRepository();
            registroClienteRepository = new RegistroClienteRepository();
            notificacionRepository = new NotificacionRepository();
        }

        #region Metodos Privados

        private List<CuentaViewModel> ObtenerListaCuenta(DataTable tabla)
        {
            var lista = new List<CuentaViewModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new CuentaViewModel
                {
                    IdBanco = Convert.ToInt32(fila["id_banco"].ToString().Trim()),
                    IdPrecliente = Convert.ToInt32(AplicacionDatoUsuario.Instancia.Usuario.IdPrecliente),
                    NumeroCuenta = Convert.ToInt32(fila["numero_cuenta"].ToString().Trim()),
                    Aduana = fila["aduana"].ToString().Trim(),
                    Banco = fila["banco"].ToString().Trim(),
                    PatentesAutorizadas = fila["patentes_autorizadas"].ToString().Trim(),
                    Identificador = fila["identificador"].ToString().Trim(),
                });
            }

            return lista;
        }

        private List<PreclienteAprobadorViewModel> ListaAprobador(DataTable tabla)
        {
            var listaAprobador = new List<PreclienteAprobadorViewModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                listaAprobador.Add(new PreclienteAprobadorViewModel
                {
                    IdPrecliente = Convert.ToInt32(fila["precliente"].ToString()),
                    IdUsuario = Convert.ToInt32(fila["usuario"].ToString()),
                    Aprobador = fila["aprobador"].ToString().Trim(),
                    Observacion = fila["observacion"].ToString().Trim()
                });
            }

            return listaAprobador;
        }

        private CuestionarioDTO ObtenerDTOCuestionario(CuestionarioViewModel cuestionario)
        {
            var dto = new CuestionarioDTO();

            dto.id_precliente = cuestionario.id_precliente;
            dto.id_usuario = cuestionario.id_usuario;
            dto.respuesta01 = cuestionario.respuesta01;
            dto.respuesta02 = cuestionario.respuesta02;
            dto.respuesta03 = cuestionario.respuesta03;
            dto.respuesta04 = cuestionario.respuesta04;
            dto.respuesta05 = cuestionario.respuesta05;
            dto.respuesta06 = cuestionario.respuesta06;
            dto.respuesta07 = cuestionario.respuesta07;
            dto.respuesta08 = cuestionario.respuesta08;
            dto.respuesta09 = cuestionario.respuesta09;
            dto.respuesta10 = cuestionario.respuesta10;
            dto.respuesta11 = cuestionario.respuesta11;
            dto.respuesta12 = cuestionario.respuesta12;
            dto.respuesta13 = cuestionario.respuesta13;
            dto.respuesta14 = cuestionario.respuesta14;
            dto.respuesta15 = cuestionario.respuesta15;
            dto.respuesta16 = cuestionario.respuesta16;
            dto.respuesta17 = cuestionario.respuesta17;
            dto.respuesta18 = cuestionario.respuesta18;
            dto.respuesta19 = cuestionario.respuesta19;
            dto.respuesta20 = cuestionario.respuesta20;
            dto.observacion01 = cuestionario.observacion01;
            dto.observacion02 = cuestionario.observacion02;
            dto.observacion03 = cuestionario.observacion03;
            dto.observacion04 = cuestionario.observacion04;
            dto.observacion05 = cuestionario.observacion05;
            dto.observacion06 = cuestionario.observacion06;
            dto.observacion07 = cuestionario.observacion07;
            dto.observacion08 = cuestionario.observacion08;
            dto.observacion09 = cuestionario.observacion09;
            dto.observacion10 = cuestionario.observacion10;
            dto.observacion11 = cuestionario.observacion11;
            dto.observacion12 = cuestionario.observacion12;
            dto.observacion13 = cuestionario.observacion13;
            dto.observacion14 = cuestionario.observacion14;
            dto.observacion15 = cuestionario.observacion15;
            dto.observacion16 = cuestionario.observacion16;
            dto.observacion17 = cuestionario.observacion17;
            dto.observacion18 = cuestionario.observacion18;
            dto.observacion19 = cuestionario.observacion19;
            dto.observacion20 = cuestionario.observacion20;
            dto.certificacion1 = cuestionario.certificacion1;
            dto.certificacion2 = cuestionario.certificacion2;
            dto.numero_puertos = cuestionario.numero_puertos;

            return dto;
        }

        private List<CuentaDTO> ObtenerDTOCuenta(List<CuentaViewModel> cuentas)
        {
            var dto = new List<CuentaDTO>();

            foreach (var cuenta in cuentas)
            {
                dto.Add(new CuentaDTO
                {
                    IdPreCliente = cuenta.IdPrecliente,
                    Banco = cuenta.Banco,
                    NumeroCuenta = cuenta.NumeroCuenta,
                    Identificador = cuenta.Identificador,
                    PatentesAutorizadas = cuenta.PatentesAutorizadas,
                    Aduana = cuenta.Aduana,
                    UsuarioCreacion = AplicacionDatoUsuario.Instancia.Usuario.IdUsuario
                });
            }

            return dto;
        }

        private List<ContactoDTO> ObtenerDTOContacto(List<ContactoViewModel> contactos)
        {
            var dto = new List<ContactoDTO>();

            foreach (var contacto in contactos)
            {
                dto.Add(new ContactoDTO
                {
                    IdPreCliente = contacto.IdPrecliente,
                    Nombre = contacto.Nombre,
                    Correo = contacto.Correo,
                    Telefono = contacto.Telefono,
                    Area = contacto.Area,
                    PuestoDepartamento = contacto.PuestoDepartamento,
                    UsuarioCreacion = AplicacionDatoUsuario.Instancia.Usuario.IdUsuario
                });
            }

            return dto;
        }

        private ClienteDTO ObtenerDTOCliente(DatoClienteViewModel datoCliente)
        {
            var dto = new ClienteDTO();

            dto.Contacto = ObtenerDTOContacto(datoCliente.Contacto);
            dto.Cuenta = ObtenerDTOCuenta(datoCliente.Cuenta);
            //TODO: Cambiar id pasi, estado, ciudad
            dto.IdPreCliente = datoCliente.IdPrecliente;
            dto.NombreFiscal = datoCliente.NombreFiscal;
            dto.RFC = datoCliente.RFC;
            dto.NombreComercial = datoCliente.NombreComercial;
            dto.Calle = datoCliente.Calle;
            dto.NoExt = datoCliente.NoExt;
            dto.NoInt = datoCliente.NoInt;
            dto.Colonia = datoCliente.Colonia;
            dto.IdCiudad = datoCliente.Ciudad.id;
            //dto.IdCiudad = "0925";
            dto.CP = datoCliente.CP;
            dto.IdEstado = datoCliente.Estado.id;
            //dto.IdEstado = "19";
            dto.IdPais = datoCliente.Pais.id;
            //dto.IdPais = "N3";
            dto.Telefono = datoCliente.Telefono;
            dto.Banco = datoCliente.Banco;
            dto.NumeroCuenta = datoCliente.NumeroCuenta;
            dto.ClabeInterbancaria = datoCliente.ClabeInterbancaria;
            dto.Moneda = datoCliente.Moneda;
            dto.SucursalBanco = datoCliente.SucursalBanco;
            dto.CiudadBanco = datoCliente.CiudadBanco;
            dto.UsuarioModificacion = AplicacionDatoUsuario.Instancia.Usuario.IdUsuario;
            dto.RepresentanteLegal = datoCliente.RepresentanteLegal;

            return dto;
        }

        private List<ExUsuariosAudabook> ObtenerUsuarioAudabook(List<UsuariosAudabookViewModel> usuarios, int idPrecliente)
        {
            var listaUsuario = new List<ExUsuariosAudabook>();
            foreach (var usuario in usuarios)
            {
                listaUsuario.Add(new ExUsuariosAudabook
                {
                    admon = usuario.Admon,
                    correo = usuario.Correo,
                    fecha_creacion = DateTime.Now,
                    fecha_modificacion = DateTime.Now,
                    id_precliente = idPrecliente,
                    id_usuario_aduabook = usuario.IdUsuarioAduabook,
                    nombre = usuario.Nombre,
                    oper = usuario.Oper,
                    puesto_departamento = usuario.PuestoDepartamento,
                    telefono = usuario.Telefono,
                    usuario_creacion = AplicacionDatoUsuario.Instancia.Usuario.IdUsuario,
                    usuario_modificacion = AplicacionDatoUsuario.Instancia.Usuario.IdUsuario
                });
            }

            return listaUsuario;
        }

        private ExDatosAdicionales ObtenerDatoAdicional(DatosAdicionalesViewModel dato, int idPrecliente)
        {
            var dto = new ExDatosAdicionales();

            dto.correoarribo = dato.CorreoArribo;
            dto.frecuencia = dato.Frecuencia;
            dto.giro = dato.Giro;
            dto.id_precliente = idPrecliente;
            dto.nombrecomer = dato.Nombrecomer;
            dto.numero_empleados = dato.NumeroEmpleados;
            dto.pagina_web = dato.PaginaWeb;
            dto.patemtes_operacion = dato.PatemtesOperacion;
            dto.Telefono = dato.Telefono;
            dto.tiempo_establecido = dato.TiempoEstablecido;
            dto.ventas_anuales = dato.VentasAnuales;
            dto.vucemC = dato.VucemC;
            dto.vucemG = dato.VucemG;

            return dto;
        }

        #endregion

        public DataTable ObtenerInfoCliente(string id_usuario)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerInfoCliente(id_usuario);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }
        public DataTable ObtenerContactosCliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerContactosCliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }
        public DataTable ObtenerCtasBancPECACliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerCtasBancPECACliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }
        public DataTable ObtenerUsrAduabookCliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerUsrAduabookCliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }
        public DataTable ObtenerCuestionarioCliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerCuestionarioCliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public List<CuentaViewModel> ObtenerCtasBancaria(string idPrecliente)
        {
            var listaModelo = new List<CuentaViewModel>();
            try
            {
                var tabla = repositorioRepository.ObtenerCtasBancPECACliente(idPrecliente);
                listaModelo = ObtenerListaCuenta(tabla);
            }
            catch (System.Exception ex)
            {
                listaModelo = null;
            }

            return listaModelo;
        }

        public int ObtenerNumeroTabuladores(int idUsuario, int idPrecliente)
        {
            try
            {
                var tabla = repositorioRepository.ObtenerNumeroTabuladores(idUsuario, idPrecliente);
                var numeroTab = Convert.ToInt32(tabla.Rows[0][0].ToString());
                return numeroTab;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PreclienteAprobadorViewModel> ObtenerRelacionPreclieteAprobador(int idPrecliente)
        {
            try
            {
                var tabla = clienteRepository.ObtenerRelacionPreclienteAprobador(idPrecliente);
                var listaAprobador = ListaAprobador(tabla);

                return listaAprobador;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDocumentosCliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerDocumentosCliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable GuardarRevisionDocumentosCliente(string id_precliente, string id_usuario)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.GuardarRevisionDocumentosCliente(id_precliente, id_usuario);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public bool GuardarTabuladores(TabuladorViewModel tabulador)
        {
            var dto = ObtenerDTOTabuladores(tabulador);

            try
            {
                var resultado = repositorioRepository.GuardarTabuladores(dto);

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

        public DataTable BuscarDatosTabuladores(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.BuscarDatosTabuladores(id_precliente);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresContactos(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.BuscarDatosTabuladoresContactos(id_precliente);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresTarifas(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.BuscarDatosTabuladoresTarifas(id_precliente);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresTabs(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.BuscarDatosTabuladoresTabs(id_precliente);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable BuscarDatosTabuladoresEmpresa(string id_tabulador_tab)
        {
            var dto = new DataTable();
            List<EmpresaTabuladorDTO> empresas = new List<EmpresaTabuladorDTO>();
            EmpresaTabuladorDTO empresa;
            try
            {
                dto = repositorioRepository.BuscarDatosTabuladoresEmpresa(id_tabulador_tab);
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

        private TabuladorDTO ObtenerDTOTabuladores(TabuladorViewModel tabulador)
        {
            var dto = new TabuladorDTO();

            dto.InformacionContacto = ObtenerDTOContactosTabuladores(tabulador.InformacionContacto);
            dto.TarifaServicio = ObtenerDTOTarifasTabuladores(tabulador.TarifaServicio);
            dto.TabuladorDinamico = ObtenerDTOTabuladorDinamicoTabuladores(tabulador.TabuladorDinamico);

            dto.IdPrecliente = tabulador.IdPrecliente;
            dto.IdUsuario = tabulador.IdUsuario;
            dto.EjecutivoVenta = tabulador.EjecutivoVenta;
            dto.EquipoOperativo = tabulador.EquipoOperativo.IdEquipo.ToString();
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

            dto.Banco = tabulador.Banco;
            dto.BancoId = tabulador.BancoId;

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

            return dto;
        }

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
                    Empresa = ObtenerDTOEmpresasTabuladores(dinamico.Empresa),
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

        public bool ActualizarRegistroCliente(CapturaClienteViewModel modelo, bool isCambioEstatus = true)
        {
            try
            {
                //cuestionadio
                var cuestionario = ObtenerDTOCuestionario(modelo.Cuestionario);
                var resultadoCuestionario = registroClienteRepository.GuardarCuestionario(cuestionario);

                //datos cliente
                var cliente = ObtenerDTOCliente(modelo.DatosCliente);
                var resultadoDatoCliente = registroClienteRepository.GuardarDatoCliente(cliente);

                //datos adicionales
                var datosAdicionales = ObtenerDatoAdicional(modelo.DatoAdicional, modelo.DatosCliente.IdPrecliente);
                var resultadoDatoAdicional = new DxDatosAdicionales().GuardaDatosADicionales(datosAdicionales);

                //usuarios Audabook
                var dac = new DxUsuarisoAudabook();
                dac.deletePorPrecliente(modelo.DatosCliente.IdPrecliente);

                var listaUsuario = ObtenerUsuarioAudabook(modelo.UsuarioAudabook, modelo.DatosCliente.IdPrecliente);

                foreach (var usuario in listaUsuario)
                {
                    dac.Save(usuario);
                }


                if (isCambioEstatus)
                {
                    //cambiar estatus

                    //var cambioEstatus = clienteRepository.ActualizarEstatus(modelo.DatosCliente.IdUsuario, (int)EstatusCliente.ParaAprobacionPreAlta); VRF

                    //enviar notificacion
                    var notificacon = notificacionRepository.EnvioCorreoNotificacion(modelo.DatosCliente.IdPrecliente);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable ValidaNumeroDocumentosRevisados(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ValidaNumeroDocumentosRevisados(id_precliente);
            }
            catch (System.Exception ex)
            {

            }
            return dto;
        }

        public DataTable ObtieneTabsPrecliente(int idPrecliente)
        {
            var dto = new DataTable();
            try
            {
                dto = clienteRepository.ObtieneTabsPrecliente(idPrecliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable GuardarTerminarProcedimientoOperacion(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.GuardarTerminarProcedimientoOperacion(id_precliente);
            }
            catch (System.Exception ex)
            {
            }
            return dto;
        }

        public DataTable ActivarCliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ActivarCliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable InactivarCliente(string id_precliente)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.InactivarCliente(id_precliente);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }
    }
}
