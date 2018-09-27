using PortalCliente.Core.ViewModel.RegistroCliente;
using System;
using System.Data;

namespace PortalCliente.Business.Interfaz
{
    public interface IRegistroClienteBusiness
    {
        bool GuardarDatoCliente(DatoClienteViewModel datoCliente);
        bool GuardarCuestionario(CuestionarioViewModel cuestionario);
        DatoClienteViewModel ObtenerDatoCliente();
        DataTable ObtenerPaises();
        DataTable ObtenerEstados(string id_pais);
        DataTable ObtenerCiudades(string id_estado);
        bool CerrarPrecliente(int id_usuario, bool con_carta_encomienda, string motivo_sin_carta_encomienda);

        string GenerarCartaEncomienda(CartaEncomiendaViewModel modelo, string rutaFisica);

        int? GuardarCamposCartaEnc(
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
            string patente_carta_encomienda);

        DataTable ObtenerPatentes();

        DataTable ObtenerDatosCartaEnc(int id_usuario);
    }
}
