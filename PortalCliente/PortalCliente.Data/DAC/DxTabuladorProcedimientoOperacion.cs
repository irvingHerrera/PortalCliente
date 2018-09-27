using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Data.DAC
{
    public class DxTabuladorProcedimientoOperacion : DataBaseAcces
    {
        enum Opciones
        {
            Save = 1,
            Update = 2,
            Delete = 3,
            Get = 4,
            GetByID = 5,
            puedeactualizar = 6
        }




        /// <summary>
        ///
        /// </summary>
        /// <param name="ExTabuladorProcedimientoOperacion"></param>
        /// <returns>True or False</returns>
        public int Save(ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_abuladorProcedimientoOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Tabulador" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescripcionOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFormaConsigueMenrcancia" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoOperativo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoCliente" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificas" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VAperturaConsolidados" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEnvioInformacionDocumentos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Clasificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VClasificacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_TipodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Regimen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_ManejodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Incoterm" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_MetodoValoracion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_FormaPago" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Vinculacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VVinculacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_AplicacionPreferencias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VAplicacionTLCAN" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Incrementables, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VIncrementables" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VEnvioProformaAutorizacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VGrupoGeneralEEI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasDM" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recibo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecibo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Descarga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Previo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPrevio" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReporteDanos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Carga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCoordinacionTransporte" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEntregaMercancias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VServiciosExtraordinarios" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Monto, SqlDbType = System.Data.SqlDbType.Decimal, ParameterName = "@VMonto" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Parausoen, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VParausoen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPuntoReorden" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recuperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecuperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Plazo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VPlazo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Condiciones, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCondiciones" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Facturacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFacturacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Cobranza, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCobranza" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VIndicadoresDesempeno" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.KPI, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VKPI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Reportes, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReportes" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.HCMVDos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VHCMVDos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PostVenta, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPostVenta" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasEP, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasEP" });

                int? resultado = NoQuery(parametros, "csp_CLI_TabuladorProcedimientoOperacion");


                //guarda contactosEI 

                //borra antes de guardar por si se esta editando
                var dacContactosEI = new DxContactoGruposEI();
                dacContactosEI.Delete(_tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador);

                foreach (var v in _tblCLI_TabuladorProcedimientoOperacion.ContactosEI)
                {
                    v.id_precliente = 0; // temporal aunque no tiene sentido que la tabla tenga ese campo 
                    v.id_tabulador_tab = _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador;
                    v.usuario_creacion = "admin";
                    v.usuario_modificacion = "admin";
                    v.fecha_creacion = DateTime.Now;
                    v.fecha_modificacion = DateTime.Now;
                    dacContactosEI.Save(v);
                }


                return (int)resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveTMP(ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Save, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_abuladorProcedimientoOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Tabulador" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescripcionOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFormaConsigueMenrcancia" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoOperativo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoCliente" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificas" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VAperturaConsolidados" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEnvioInformacionDocumentos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Clasificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VClasificacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_TipodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Regimen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_ManejodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Incoterm" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_MetodoValoracion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_FormaPago" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Vinculacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VVinculacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_AplicacionPreferencias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VAplicacionTLCAN" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Incrementables, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VIncrementables" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VEnvioProformaAutorizacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VGrupoGeneralEEI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasDM" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recibo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecibo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Descarga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Previo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPrevio" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReporteDanos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Carga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCoordinacionTransporte" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEntregaMercancias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VServiciosExtraordinarios" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Monto, SqlDbType = System.Data.SqlDbType.Decimal, ParameterName = "@VMonto" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Parausoen, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VParausoen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPuntoReorden" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recuperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecuperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Plazo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VPlazo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Condiciones, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCondiciones" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Facturacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFacturacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Cobranza, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCobranza" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VIndicadoresDesempeno" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.KPI, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VKPI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Reportes, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReportes" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.HCMVDos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VHCMVDos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PostVenta, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPostVenta" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasEP, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasEP" });

                int? resultado = ExecuteNoQuery(parametros, "csp_CLI_TabuladorProcedimientoOperacion_TMP");


                //guarda contactosEI 

                //borra antes de guardar por si se esta editando
                var dacContactosEI = new DxContactoGruposEI();
                dacContactosEI.DeleteTMP(_tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador);

                foreach (var v in _tblCLI_TabuladorProcedimientoOperacion.ContactosEI ?? new List<ExContactoGruposEI>())
                {
                    v.id_precliente = 0; // temporal aunque no tiene sentido que la tabla tenga ese campo 
                    v.id_tabulador_tab = _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador;
                    v.usuario_creacion = "admin";
                    v.usuario_modificacion = "admin";
                    v.fecha_creacion = DateTime.Now;
                    v.fecha_modificacion = DateTime.Now;
                    dacContactosEI.SaveTMP(v);
                }


                return (int)resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ExTabuladorProcedimientoOperacion"></param>
        /// <returns></returns>
        public bool Update(ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Update, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_abuladorProcedimientoOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Tabulador" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescripcionOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFormaConsigueMenrcancia" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoOperativo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoCliente" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificas" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VAperturaConsolidados" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEnvioInformacionDocumentos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Clasificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VClasificacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_TipodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Regimen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_ManejodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Incoterm" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_MetodoValoracion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_FormaPago" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Vinculacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VVinculacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_AplicacionPreferencias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VAplicacionTLCAN" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Incrementables, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VIncrementables" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VEnvioProformaAutorizacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VGrupoGeneralEEI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasDM" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recibo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecibo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Descarga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Previo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPrevio" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReporteDanos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Carga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCoordinacionTransporte" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEntregaMercancias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VServiciosExtraordinarios" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Monto, SqlDbType = System.Data.SqlDbType.Decimal, ParameterName = "@VMonto" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Parausoen, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VParausoen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPuntoReorden" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recuperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecuperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Plazo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VPlazo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Condiciones, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCondiciones" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Facturacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFacturacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Cobranza, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCobranza" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VIndicadoresDesempeno" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.KPI, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VKPI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Reportes, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReportes" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.HCMVDos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VHCMVDos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PostVenta, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPostVenta" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PostVenta, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasEP" });
                NoQuery(parametros, "csp_CLI_TabuladorProcedimientoOperacion");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateTMP(ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Update, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_abuladorProcedimientoOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Tabulador" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescripcionOperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFormaConsigueMenrcancia" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoOperativo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VContactoCliente" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificas" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VAperturaConsolidados" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEnvioInformacionDocumentos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Clasificacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VClasificacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_TipodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Regimen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_ManejodePedimento" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Incoterm" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_MetodoValoracion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_FormaPago" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Vinculacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VVinculacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_AplicacionPreferencias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VAplicacionTLCAN" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Incrementables, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VIncrementables" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VEnvioProformaAutorizacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI, SqlDbType = System.Data.SqlDbType.Bit, ParameterName = "@VGrupoGeneralEEI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasDM" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recibo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecibo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Descarga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VDescarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Previo, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPrevio" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReporteDanos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Carga, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCarga" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCoordinacionTransporte" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VEntregaMercancias" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VServiciosExtraordinarios" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Monto, SqlDbType = System.Data.SqlDbType.Decimal, ParameterName = "@VMonto" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Parausoen, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VParausoen" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPuntoReorden" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Recuperacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VRecuperacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Plazo, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VPlazo" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Condiciones, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCondiciones" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Facturacion, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VFacturacion" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Cobranza, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VCobranza" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VIndicadoresDesempeno" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.KPI, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VKPI" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Reportes, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VReportes" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.HCMVDos, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VHCMVDos" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PostVenta, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VPostVenta" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.PostVenta, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "@VObservacionesEspecificasEP" });
                NoQuery(parametros, "csp_CLI_TabuladorProcedimientoOperacion_TMP");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="_tblCLI_TabuladorProcedimientoOperacion"></param>
        /// <returns></returns>
        public bool Delete(ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Delete, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_abuladorProcedimientoOperacion" });
                NoQuery(parametros, "csp_CLI_TabuladorProcedimientoOperacion");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///
        /// </summary>
        /// <returns>List of tblCLI_TabuladorProcedimientoOperacion</returns>
        public List<ExTabuladorProcedimientoOperacion> Get()
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.Get, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                List<ExTabuladorProcedimientoOperacion> _tblCLI_TabuladorProcedimientoOperacions = new List<ExTabuladorProcedimientoOperacion>();
                DataTable dt = Select(parametros, "csp_CLI_TabuladorProcedimientoOperacion");
                foreach (DataRow dr in dt.Rows)
                {
                    ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion = new ExTabuladorProcedimientoOperacion();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion = Convert.ToInt32(dr["Id_abuladorProcedimientoOperacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador = Convert.ToInt32(dr["Id_Tabulador"]);
                    _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion = dr["DescripcionOperacion"] == DBNull.Value ? (string)null : dr["DescripcionOperacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia = dr["FormaConsigueMenrcancia"] == DBNull.Value ? (string)null : dr["FormaConsigueMenrcancia"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo = dr["ContactoOperativo"] == DBNull.Value ? (string)null : dr["ContactoOperativo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente = dr["ContactoCliente"] == DBNull.Value ? (string)null : dr["ContactoCliente"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas = dr["ObservacionesEspecificas"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificas"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados = dr["AperturaConsolidados"] == DBNull.Value ? (string)null : dr["AperturaConsolidados"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos = dr["EnvioInformacionDocumentos"] == DBNull.Value ? (string)null : dr["EnvioInformacionDocumentos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Clasificacion = dr["Clasificacion"] == DBNull.Value ? (string)null : dr["Clasificacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento = Convert.ToInt32(dr["Id_TipodePedimento"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen = Convert.ToInt32(dr["Id_Regimen"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento = Convert.ToInt32(dr["Id_ManejodePedimento"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm = Convert.ToInt32(dr["Id_Incoterm"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion = Convert.ToInt32(dr["Id_MetodoValoracion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago = Convert.ToInt32(dr["Id_FormaPago"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Vinculacion = Convert.ToBoolean(dr["Vinculacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias = Convert.ToInt32(dr["Id_AplicacionPreferencias"]);
                    _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN = Convert.ToBoolean(dr["AplicacionTLCAN"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Incrementables = Convert.ToBoolean(dr["Incrementables"]);
                    _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion = Convert.ToBoolean(dr["EnvioProformaAutorizacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI = Convert.ToBoolean(dr["GrupoGeneralEEI"]);
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM = dr["ObservacionesEspecificasDM"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificasDM"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Recibo = dr["Recibo"] == DBNull.Value ? (string)null : dr["Recibo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Descarga = dr["Descarga"] == DBNull.Value ? (string)null : dr["Descarga"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Previo = dr["Previo"] == DBNull.Value ? (string)null : dr["Previo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos = dr["ReporteDanos"] == DBNull.Value ? (string)null : dr["ReporteDanos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Carga = dr["Carga"] == DBNull.Value ? (string)null : dr["Carga"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte = dr["CoordinacionTransporte"] == DBNull.Value ? (string)null : dr["CoordinacionTransporte"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias = dr["EntregaMercancias"] == DBNull.Value ? (string)null : dr["EntregaMercancias"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios = dr["ServiciosExtraordinarios"] == DBNull.Value ? (string)null : dr["ServiciosExtraordinarios"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Monto = dr["Monto"] == DBNull.Value ? (Decimal?)null : Convert.ToDecimal(dr["Monto"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Parausoen = dr["Parausoen"] == DBNull.Value ? (string)null : dr["Parausoen"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden = dr["PuntoReorden"] == DBNull.Value ? (string)null : dr["PuntoReorden"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Recuperacion = dr["Recuperacion"] == DBNull.Value ? (string)null : dr["Recuperacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Plazo = dr["Plazo"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["Plazo"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Condiciones = dr["Condiciones"] == DBNull.Value ? (string)null : dr["Condiciones"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Facturacion = dr["Facturacion"] == DBNull.Value ? (string)null : dr["Facturacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Cobranza = dr["Cobranza"] == DBNull.Value ? (string)null : dr["Cobranza"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno = dr["IndicadoresDesempeno"] == DBNull.Value ? (string)null : dr["IndicadoresDesempeno"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.KPI = dr["KPI"] == DBNull.Value ? (string)null : dr["KPI"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Reportes = dr["Reportes"] == DBNull.Value ? (string)null : dr["Reportes"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.HCMVDos = dr["HCMVDos"] == DBNull.Value ? (string)null : dr["HCMVDos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.PostVenta = dr["PostVenta"] == DBNull.Value ? (string)null : dr["PostVenta"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasEP = dr["ObservacionesEspecificasEP"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificasEP"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacions.Add(_tblCLI_TabuladorProcedimientoOperacion);
                }
                return _tblCLI_TabuladorProcedimientoOperacions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<ExTabuladorProcedimientoOperacion> GetByID(int id)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.GetByID, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Tabulador" });
                List<ExTabuladorProcedimientoOperacion> _tblCLI_TabuladorProcedimientoOperacions = new List<ExTabuladorProcedimientoOperacion>();
                DataTable dt = Select(parametros, "csp_CLI_TabuladorProcedimientoOperacion");
                foreach (DataRow dr in dt.Rows)
                {
                    ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion = new ExTabuladorProcedimientoOperacion();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion = Convert.ToInt32(dr["Id_abuladorProcedimientoOperacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador = Convert.ToInt32(dr["Id_Tabulador"]);
                    _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion = dr["DescripcionOperacion"] == DBNull.Value ? (string)null : dr["DescripcionOperacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia = dr["FormaConsigueMenrcancia"] == DBNull.Value ? (string)null : dr["FormaConsigueMenrcancia"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo = dr["ContactoOperativo"] == DBNull.Value ? (string)null : dr["ContactoOperativo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente = dr["ContactoCliente"] == DBNull.Value ? (string)null : dr["ContactoCliente"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas = dr["ObservacionesEspecificas"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificas"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados = dr["AperturaConsolidados"] == DBNull.Value ? (string)null : dr["AperturaConsolidados"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos = dr["EnvioInformacionDocumentos"] == DBNull.Value ? (string)null : dr["EnvioInformacionDocumentos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Clasificacion = dr["Clasificacion"] == DBNull.Value ? (string)null : dr["Clasificacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento = Convert.ToInt32(dr["Id_TipodePedimento"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen = Convert.ToInt32(dr["Id_Regimen"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento = Convert.ToInt32(dr["Id_ManejodePedimento"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm = Convert.ToInt32(dr["Id_Incoterm"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion = Convert.ToInt32(dr["Id_MetodoValoracion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago = Convert.ToInt32(dr["Id_FormaPago"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Vinculacion = Convert.ToBoolean(dr["Vinculacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias = Convert.ToInt32(dr["Id_AplicacionPreferencias"]);
                    _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN = Convert.ToBoolean(dr["AplicacionTLCAN"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Incrementables = Convert.ToBoolean(dr["Incrementables"]);
                    _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion = Convert.ToBoolean(dr["EnvioProformaAutorizacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI = Convert.ToBoolean(dr["GrupoGeneralEEI"]);
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM = dr["ObservacionesEspecificasDM"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificasDM"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Recibo = dr["Recibo"] == DBNull.Value ? (string)null : dr["Recibo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Descarga = dr["Descarga"] == DBNull.Value ? (string)null : dr["Descarga"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Previo = dr["Previo"] == DBNull.Value ? (string)null : dr["Previo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos = dr["ReporteDanos"] == DBNull.Value ? (string)null : dr["ReporteDanos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Carga = dr["Carga"] == DBNull.Value ? (string)null : dr["Carga"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte = dr["CoordinacionTransporte"] == DBNull.Value ? (string)null : dr["CoordinacionTransporte"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias = dr["EntregaMercancias"] == DBNull.Value ? (string)null : dr["EntregaMercancias"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios = dr["ServiciosExtraordinarios"] == DBNull.Value ? (string)null : dr["ServiciosExtraordinarios"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Monto = dr["Monto"] == DBNull.Value ? (Decimal?)null : Convert.ToDecimal(dr["Monto"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Parausoen = dr["Parausoen"] == DBNull.Value ? (string)null : dr["Parausoen"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden = dr["PuntoReorden"] == DBNull.Value ? (string)null : dr["PuntoReorden"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Recuperacion = dr["Recuperacion"] == DBNull.Value ? (string)null : dr["Recuperacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Plazo = dr["Plazo"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["Plazo"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Condiciones = dr["Condiciones"] == DBNull.Value ? (string)null : dr["Condiciones"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Facturacion = dr["Facturacion"] == DBNull.Value ? (string)null : dr["Facturacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Cobranza = dr["Cobranza"] == DBNull.Value ? (string)null : dr["Cobranza"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno = dr["IndicadoresDesempeno"] == DBNull.Value ? (string)null : dr["IndicadoresDesempeno"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.KPI = dr["KPI"] == DBNull.Value ? (string)null : dr["KPI"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Reportes = dr["Reportes"] == DBNull.Value ? (string)null : dr["Reportes"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.HCMVDos = dr["HCMVDos"] == DBNull.Value ? (string)null : dr["HCMVDos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.PostVenta = dr["PostVenta"] == DBNull.Value ? (string)null : dr["PostVenta"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasEP = dr["ObservacionesEspecificasEP"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificasEP"].ToString();
                    //descripciones de catalogos 
                    _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferenciasDES = dr["Id_AplicacionPreferenciasDES"] == DBNull.Value ? (string)null : dr["Id_AplicacionPreferenciasDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_IncotermDES = dr["Id_IncotermDES"] == DBNull.Value ? (string)null : dr["Id_IncotermDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracionDES = dr["Id_MetodoValoracionDES"] == DBNull.Value ? (string)null : dr["Id_MetodoValoracionDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPagoDES = dr["Id_FormaPagoDES"] == DBNull.Value ? (string)null : dr["Id_FormaPagoDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_RegimenDES = dr["Id_RegimenDES"] == DBNull.Value ? (string)null : dr["Id_RegimenDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimentoDES = dr["Id_TipodePedimentoDES"] == DBNull.Value ? (string)null : dr["Id_TipodePedimentoDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimentoDES = dr["Id_ManejodePedimentoDES"] == DBNull.Value ? (string)null : dr["Id_ManejodePedimentoDES"].ToString();



                    _tblCLI_TabuladorProcedimientoOperacions.Add(_tblCLI_TabuladorProcedimientoOperacion);

                    _tblCLI_TabuladorProcedimientoOperacion.ContactosEI = new DxContactoGruposEI().GetbyTabuladorTab(_tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador);

                }
                return _tblCLI_TabuladorProcedimientoOperacions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExTabuladorProcedimientoOperacion> GetByIDTMP(int id)
        {
            try
            {
                //DAC _Dac = new DAC(); 
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter { Value = Opciones.GetByID, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
                parametros.Add(new SqlParameter { Value = id, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VId_Tabulador" });
                List<ExTabuladorProcedimientoOperacion> _tblCLI_TabuladorProcedimientoOperacions = new List<ExTabuladorProcedimientoOperacion>();
                DataTable dt = Select(parametros, "csp_CLI_TabuladorProcedimientoOperacion_TMP");
                foreach (DataRow dr in dt.Rows)
                {
                    ExTabuladorProcedimientoOperacion _tblCLI_TabuladorProcedimientoOperacion = new ExTabuladorProcedimientoOperacion();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_abuladorProcedimientoOperacion = Convert.ToInt32(dr["Id_abuladorProcedimientoOperacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador = Convert.ToInt32(dr["Id_Tabulador"]);
                    _tblCLI_TabuladorProcedimientoOperacion.DescripcionOperacion = dr["DescripcionOperacion"] == DBNull.Value ? (string)null : dr["DescripcionOperacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.FormaConsigueMenrcancia = dr["FormaConsigueMenrcancia"] == DBNull.Value ? (string)null : dr["FormaConsigueMenrcancia"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ContactoOperativo = dr["ContactoOperativo"] == DBNull.Value ? (string)null : dr["ContactoOperativo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ContactoCliente = dr["ContactoCliente"] == DBNull.Value ? (string)null : dr["ContactoCliente"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificas = dr["ObservacionesEspecificas"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificas"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.AperturaConsolidados = dr["AperturaConsolidados"] == DBNull.Value ? (string)null : dr["AperturaConsolidados"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.EnvioInformacionDocumentos = dr["EnvioInformacionDocumentos"] == DBNull.Value ? (string)null : dr["EnvioInformacionDocumentos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Clasificacion = dr["Clasificacion"] == DBNull.Value ? (string)null : dr["Clasificacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimento = Convert.ToInt32(dr["Id_TipodePedimento"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Regimen = Convert.ToInt32(dr["Id_Regimen"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimento = Convert.ToInt32(dr["Id_ManejodePedimento"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_Incoterm = Convert.ToInt32(dr["Id_Incoterm"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracion = Convert.ToInt32(dr["Id_MetodoValoracion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPago = Convert.ToInt32(dr["Id_FormaPago"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Vinculacion = Convert.ToBoolean(dr["Vinculacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferencias = Convert.ToInt32(dr["Id_AplicacionPreferencias"]);
                    _tblCLI_TabuladorProcedimientoOperacion.AplicacionTLCAN = Convert.ToBoolean(dr["AplicacionTLCAN"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Incrementables = Convert.ToBoolean(dr["Incrementables"]);
                    _tblCLI_TabuladorProcedimientoOperacion.EnvioProformaAutorizacion = Convert.ToBoolean(dr["EnvioProformaAutorizacion"]);
                    _tblCLI_TabuladorProcedimientoOperacion.GrupoGeneralEEI = Convert.ToBoolean(dr["GrupoGeneralEEI"]);
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasDM = dr["ObservacionesEspecificasDM"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificasDM"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Recibo = dr["Recibo"] == DBNull.Value ? (string)null : dr["Recibo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Descarga = dr["Descarga"] == DBNull.Value ? (string)null : dr["Descarga"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Previo = dr["Previo"] == DBNull.Value ? (string)null : dr["Previo"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ReporteDanos = dr["ReporteDanos"] == DBNull.Value ? (string)null : dr["ReporteDanos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Carga = dr["Carga"] == DBNull.Value ? (string)null : dr["Carga"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.CoordinacionTransporte = dr["CoordinacionTransporte"] == DBNull.Value ? (string)null : dr["CoordinacionTransporte"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.EntregaMercancias = dr["EntregaMercancias"] == DBNull.Value ? (string)null : dr["EntregaMercancias"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ServiciosExtraordinarios = dr["ServiciosExtraordinarios"] == DBNull.Value ? (string)null : dr["ServiciosExtraordinarios"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Monto = dr["Monto"] == DBNull.Value ? (Decimal?)null : Convert.ToDecimal(dr["Monto"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Parausoen = dr["Parausoen"] == DBNull.Value ? (string)null : dr["Parausoen"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.PuntoReorden = dr["PuntoReorden"] == DBNull.Value ? (string)null : dr["PuntoReorden"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Recuperacion = dr["Recuperacion"] == DBNull.Value ? (string)null : dr["Recuperacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Plazo = dr["Plazo"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["Plazo"]);
                    _tblCLI_TabuladorProcedimientoOperacion.Condiciones = dr["Condiciones"] == DBNull.Value ? (string)null : dr["Condiciones"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Facturacion = dr["Facturacion"] == DBNull.Value ? (string)null : dr["Facturacion"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Cobranza = dr["Cobranza"] == DBNull.Value ? (string)null : dr["Cobranza"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.IndicadoresDesempeno = dr["IndicadoresDesempeno"] == DBNull.Value ? (string)null : dr["IndicadoresDesempeno"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.KPI = dr["KPI"] == DBNull.Value ? (string)null : dr["KPI"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Reportes = dr["Reportes"] == DBNull.Value ? (string)null : dr["Reportes"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.HCMVDos = dr["HCMVDos"] == DBNull.Value ? (string)null : dr["HCMVDos"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.PostVenta = dr["PostVenta"] == DBNull.Value ? (string)null : dr["PostVenta"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.ObservacionesEspecificasEP = dr["ObservacionesEspecificasEP"] == DBNull.Value ? (string)null : dr["ObservacionesEspecificasEP"].ToString();
                    //descripciones de catalogos 
                    _tblCLI_TabuladorProcedimientoOperacion.Id_AplicacionPreferenciasDES = dr["Id_AplicacionPreferenciasDES"] == DBNull.Value ? (string)null : dr["Id_AplicacionPreferenciasDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_IncotermDES = dr["Id_IncotermDES"] == DBNull.Value ? (string)null : dr["Id_IncotermDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_MetodoValoracionDES = dr["Id_MetodoValoracionDES"] == DBNull.Value ? (string)null : dr["Id_MetodoValoracionDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_FormaPagoDES = dr["Id_FormaPagoDES"] == DBNull.Value ? (string)null : dr["Id_FormaPagoDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_RegimenDES = dr["Id_RegimenDES"] == DBNull.Value ? (string)null : dr["Id_RegimenDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_TipodePedimentoDES = dr["Id_TipodePedimentoDES"] == DBNull.Value ? (string)null : dr["Id_TipodePedimentoDES"].ToString();
                    _tblCLI_TabuladorProcedimientoOperacion.Id_ManejodePedimentoDES = dr["Id_ManejodePedimentoDES"] == DBNull.Value ? (string)null : dr["Id_ManejodePedimentoDES"].ToString();



                    _tblCLI_TabuladorProcedimientoOperacions.Add(_tblCLI_TabuladorProcedimientoOperacion);

                    _tblCLI_TabuladorProcedimientoOperacion.ContactosEI = new DxContactoGruposEI().GetbyTabuladorTabTMP(_tblCLI_TabuladorProcedimientoOperacion.Id_Tabulador);

                }
                return _tblCLI_TabuladorProcedimientoOperacions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool puedeActualizar(int idprecliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { Value = Opciones.puedeactualizar, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@VOPCION" });
            parametros.Add(new SqlParameter { Value = idprecliente, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "@idprecliente" });
            var res = Select(parametros, "csp_CLI_TabuladorProcedimientoOperacion");
            return Convert.ToBoolean(res.Rows[0]["respuesta"]);
        }
    }
}
