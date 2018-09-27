using PortalCliente.Business.Interfaz;
using PortalCliente.Core.ViewModel.RegistroCliente;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;
using PortalCliente.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace PortalCliente.Business
{
    public class RegistroClienteBusiness : IRegistroClienteBusiness
    {
        private readonly IRegistroClienteRepository repositorioRepository;
        private readonly IClienteRepository clienteRepository;

        public RegistroClienteBusiness()
        {
            repositorioRepository = new RegistroClienteRepository();
            clienteRepository = new ClienteRepository();
        }

        #region MetodosPrivados

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
                    UsuarioCreacion = cuenta.UsuarioCreacion
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
                    UsuarioCreacion = contacto.UsuarioCreacion
                });
            }

            return dto;
        }

        private ClienteDTO ObtenerDTOCliente(DatoClienteViewModel datoCliente)
        {
            var dto = new ClienteDTO();

            dto.Contacto = ObtenerDTOContacto(datoCliente.Contacto);
            dto.Cuenta = ObtenerDTOCuenta(datoCliente.Cuenta);

            dto.IdPreCliente = datoCliente.IdPrecliente;
            dto.NombreFiscal = datoCliente.NombreFiscal;
            dto.RFC = datoCliente.RFC;
            dto.NombreComercial = datoCliente.NombreComercial;
            dto.Calle = datoCliente.Calle;
            dto.NoExt = datoCliente.NoExt;
            dto.NoInt = datoCliente.NoInt;
            dto.Colonia = datoCliente.Colonia;
            dto.IdCiudad = datoCliente.Ciudad.id;
            dto.CP = datoCliente.CP;
            dto.IdEstado = datoCliente.Estado.id;
            dto.IdPais = datoCliente.Pais.id;
            dto.Telefono = datoCliente.Telefono;
            dto.Banco = datoCliente.Banco;
            dto.NumeroCuenta = datoCliente.NumeroCuenta;
            dto.ClabeInterbancaria = datoCliente.ClabeInterbancaria;
            dto.Moneda = datoCliente.Moneda;
            dto.SucursalBanco = datoCliente.SucursalBanco;
            dto.CiudadBanco = datoCliente.CiudadBanco;
            dto.UsuarioModificacion = datoCliente.UsuarioModificacion;
            dto.RepresentanteLegal = datoCliente.RepresentanteLegal;

            return dto;
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

        private ClienteDTO ObtenerModeloCartaEncomienda(DataTable dato)
        {
            var cliente = new ClienteDTO();

            cliente.IdPreCliente = Convert.ToInt32(dato.Rows[0]["id_precliente"].ToString());
            cliente.IdUsuario = Convert.ToInt32(dato.Rows[0]["id_usuario"].ToString());
            cliente.Calle = dato.Rows[0]["calle"].ToString();
            cliente.NoExt = dato.Rows[0]["no_ext"].ToString();
            cliente.NoInt = dato.Rows[0]["no_int"].ToString();
            cliente.Colonia = dato.Rows[0]["colonia"].ToString();
            cliente.Ciudad = dato.Rows[0]["ciudad"].ToString();
            cliente.Estado = dato.Rows[0]["estado"].ToString();
            cliente.CP = dato.Rows[0]["cp"].ToString();
            cliente.RepresentanteLegal = dato.Rows[0]["representante_legal"].ToString(); ;
            cliente.RFC = dato.Rows[0]["rfc"].ToString();
            cliente.NombreFiscal = dato.Rows[0]["nombre_fiscal"].ToString();

            return cliente;
        }

        #endregion

        /// <summary>
        /// Genera la carta encomienda con los datos guardados del precliente y 
        /// los datos adicionales de la ventana emergente
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public string GenerarCartaEncomienda(CartaEncomiendaViewModel modelo, string rutaFisica)
        {
            var table = clienteRepository.ObtenerDatoCliente(modelo.IdUsuario);
            var modeloDTO = ObtenerModeloCartaEncomienda(table);
            CartaEncomienda.CartaEncomienda carta = new CartaEncomienda.CartaEncomienda();
            var nombreCarta = carta.GenerarCartaEncomienda(modelo, modeloDTO, rutaFisica);

            return nombreCarta;
        }

        public bool GuardarDatoCliente(DatoClienteViewModel datoCliente)
        {
            var dto = ObtenerDTOCliente(datoCliente);

            try
            {
                var resultado = repositorioRepository.GuardarDatoCliente(dto);

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

        public bool GuardarCuestionario(CuestionarioViewModel cuestionario)
        {
            var dto = ObtenerDTOCuestionario(cuestionario);

            try
            {
                var resultado = repositorioRepository.GuardarCuestionario(dto);

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

        public bool CerrarPrecliente(int id_usuario, bool con_carta_encomienda, string motivo_sin_carta_encomienda)
        {
            try
            {
                var resultado = repositorioRepository.CerrarPrecliente(id_usuario, con_carta_encomienda, motivo_sin_carta_encomienda);

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

        public DatoClienteViewModel ObtenerDatoCliente()
        {
            throw new System.NotImplementedException();
        }

        public DataTable ObtenerPaises()
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerPaises();
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable ObtenerEstados(string id_pais)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerEstados(id_pais);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable ObtenerCiudades(string id_estado)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerCiudades(id_estado);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public int? GuardarCamposCartaEnc(
            string id_usuario,
            string domicilio_fiscal_calle,
            string domicilio_fiscal_ciudad,
            string domicilio_fiscal_colonia,
            string domicilio_fiscal_cp,
            string domicilio_fiscal_estado,
            string domicilio_fiscal_municipio,
            string domicilio_fiscal_no_ext,
            string domicilio_fiscal_no_int,
            string numero_escritura,
            string nombre_notario,
            string numero_notaria,
            string ciudad_notariado,
            string estado_notariado,
            string membrete_empresa,
            DateTime periodo_compredido_inicio,
            DateTime periodo_compredido_fin,
            string patente_carta_encomienda)
        {
            int? dto = null;
            try
            {
                dto = repositorioRepository.GuardarCamposCartaEnc(id_usuario, domicilio_fiscal_calle,
             domicilio_fiscal_ciudad,
             domicilio_fiscal_colonia,
             domicilio_fiscal_cp,
             domicilio_fiscal_estado,
             domicilio_fiscal_municipio,
             domicilio_fiscal_no_ext,
             domicilio_fiscal_no_int,
             numero_escritura,
             nombre_notario,
             numero_notaria,
             ciudad_notariado,
             estado_notariado,
             membrete_empresa,
             periodo_compredido_inicio,
             periodo_compredido_fin,
            patente_carta_encomienda);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable ObtenerPatentes()
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerPatentes();
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }

        public DataTable ObtenerDatosCartaEnc(int id_usuario)
        {
            var dto = new DataTable();
            try
            {
                dto = repositorioRepository.ObtenerDatosCartaEnc(id_usuario);
            }
            catch (System.Exception ex)
            {

            }

            return dto;
        }
    }
}
