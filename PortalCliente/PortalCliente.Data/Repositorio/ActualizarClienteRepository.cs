using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PortalCliente.Data.BD;
using PortalCliente.Data.ENT;
using PortalCliente.Data.Interfaz;

namespace PortalCliente.Data.Repositorio
{
    public class ActualizarClienteRepository : DataBaseAcces, IActualizarClienteRepository
    {
        #region "Guardar Dato Operacion en Tablas Temporales"
        public int? GuardarDatoOperacion(TabuladorDTO tabuladores)
        {
            var parametro = new List<SqlParameter>();

            var tTabulador = TablaTabulador(tabuladores);
            var tInformacionContacto = TablaInformacionContacto(tabuladores.InformacionContacto, tabuladores.IdPrecliente);
            var tTarifaServicio = TablaTarifaServicio(tabuladores.TarifaServicio, tabuladores.IdPrecliente);

            parametro.Add(new SqlParameter
            {
                Value = tTabulador,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@Tabulador"
            });
            parametro.Add(new SqlParameter
            {
                Value = tTarifaServicio,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@Tarifas"
            });
            parametro.Add(new SqlParameter
            {
                Value = tInformacionContacto,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@Contactos"
            });

            var resultado = ExecuteNoQuery(parametro, "dbo.csp_tblCLI_GuardarDatosTabuladores_TMP");

            TablaTabuladorDinamico(tabuladores.TabuladorDinamico, tabuladores.IdPrecliente);

            return resultado;
        }
        
        public int? GuardarTabuladorEmpresa(List<EmpresaTabuladorDTO> empresa, int? id_tabulador_tab)
        {
            var parametro = new List<SqlParameter>();

            var tEmpresa = TablaTabuladorEmpresa(empresa, id_tabulador_tab);

            parametro.Add(new SqlParameter
            {
                Value = tEmpresa,
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@Empresa"
            });
            var resultado = ExecuteNoQuery(parametro, "dbo.csp_tblCLI_GuardarTabuladorEmpresa_TMP");
            return resultado;
        }
       
        public int? GuardarTab(TabuladorDinamicoDTO dinamico, int numeroTab, int IDPrecliente)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = IDPrecliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@IDPrecliente"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.TipoOperacion,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@TipoOperacion"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.Aduana.ID,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@Aduana"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.ClavePedimento.ID,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@ClavePedimento"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.Moneda,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@Moneda"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.Facturacion,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@Facturacion"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.DiasLibres,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@DiasLibres"
            });
            parametro.Add(new SqlParameter
            {
                Value = numeroTab,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@NumeroTab"
            });
            parametro.Add(new SqlParameter
            {
                Value = dinamico.IdTab,
                SqlDbType = SqlDbType.VarChar,
                ParameterName = "@IdTab"
            });
            var salida = Select(parametro, "csp_tblCLI_GuardarTab_TMP");
            int resultado = 0;

            //foreach (DataRow row in salida.Rows)
            //{
            //    resultado = Convert.ToInt32(row["ID"]);
            //}
            return resultado;
        }

        #region "Generadores de Estructuras para actualizar dato de operacion"
        private void TablaTabuladorDinamico(List<TabuladorDinamicoDTO> dinamico, int IDPrecliente)
        {
            int numTab = 0;

            foreach (var item in dinamico)
            {
                numTab++;
                int? id_tabulador_tab = GuardarTab(item, numTab, IDPrecliente);
                GuardarTabuladorEmpresa(item.Empresa, item.IdTab);
            }
        }

        private DataTable TablaTabuladorEmpresa(List<EmpresaTabuladorDTO> empresa, int? id_tabulador_tab)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("id_tabulador_tab");
            tabla.Columns.Add("Empresa");
            tabla.Columns.Add("ConceptoFacturacion");
            tabla.Columns.Add("ConceptoAutoFacturacion");
            tabla.Columns.Add("TarifaVenta");
            tabla.Columns.Add("TarifaVentaMoneda");
            tabla.Columns.Add("TarifaCompra");
            tabla.Columns.Add("TarifaCompraMoneda");

            foreach (var item in empresa)
            {
                var fila = tabla.NewRow();
                fila["id_tabulador_tab"] = id_tabulador_tab;
                fila["Empresa"] = item.Empresa;
                fila["ConceptoFacturacion"] = item.ConceptoFacturacion.ID;
                fila["ConceptoAutoFacturacion"] = item.ConceptoAutoFacturacion.ID;
                fila["TarifaVenta"] = item.TarifaVenta;
                fila["TarifaVentaMoneda"] = item.TarifaVentaMoneda;
                fila["TarifaCompra"] = item.TarifaCompra;
                fila["TarifaCompraMoneda"] = item.TarifaCompraMoneda;
                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        private DataTable TablaTabulador(TabuladorDTO tabuladores)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("IdPrecliente");
            tabla.Columns.Add("IdUsuario");
            tabla.Columns.Add("EquipoOperacion");
            tabla.Columns.Add("TipoCliente");
            tabla.Columns.Add("RFC");
            tabla.Columns.Add("NombreClienteAlta");
            tabla.Columns.Add("Cliente");
            tabla.Columns.Add("ConSitio");
            tabla.Columns.Add("PaginaWeb");
            tabla.Columns.Add("Usuario");
            tabla.Columns.Add("Password");
            tabla.Columns.Add("ConEntregaFisica");
            tabla.Columns.Add("DiasRevision");
            tabla.Columns.Add("HorarioRevision");
            tabla.Columns.Add("PersonasRecibenFacturas");
            tabla.Columns.Add("NumeroJuegoCopias");
            tabla.Columns.Add("CalleNumero");
            tabla.Columns.Add("Colonia");
            tabla.Columns.Add("ID_Estado");
            tabla.Columns.Add("ID_Ciudad");
            tabla.Columns.Add("CodigoPostal");
            tabla.Columns.Add("ConCtePedComprobados");
            tabla.Columns.Add("ConCtePedCtaAmericana");
            tabla.Columns.Add("ConCtePedHonorarios");
            tabla.Columns.Add("ConCtePedImpuestos");
            tabla.Columns.Add("ConCeteFactComprobados");
            tabla.Columns.Add("ConCeteFactCtaAmericana");
            tabla.Columns.Add("ConCeteFactHonorarios");
            tabla.Columns.Add("ConCeteFactImpuestos");
            tabla.Columns.Add("EmpresaFacturaComprobados");
            tabla.Columns.Add("EmpresaFacturaCtaAmericana");
            tabla.Columns.Add("EmpresaFacturaHonorarios");
            tabla.Columns.Add("EmpresaFacturaImpuestos");
            tabla.Columns.Add("CtaAmeTC");
            tabla.Columns.Add("CtaAmeExpedidaPor");
            tabla.Columns.Add("CtaAmeSeCobraEn");
            tabla.Columns.Add("CtaAmeExpedidoPor");
            tabla.Columns.Add("ConImpuestosPECA");
            tabla.Columns.Add("DatosAdicionales");
            tabla.Columns.Add("MetodoPago");
            tabla.Columns.Add("DigitosCuenta");
            tabla.Columns.Add("InstruccionesEspeciales");
            tabla.Columns.Add("CondicionesPago");
            tabla.Columns.Add("PeriodoGracia");
            tabla.Columns.Add("DiasPago");
            tabla.Columns.Add("HorarioPago");
            tabla.Columns.Add("ConSuspensionCliente");
            tabla.Columns.Add("ConFondo");
            tabla.Columns.Add("MontoFondo");
            tabla.Columns.Add("ConFinanciamiento");
            tabla.Columns.Add("MontoFinanciamiento");
            tabla.Columns.Add("ParaUsoEn");
            tabla.Columns.Add("PuntoReorden");
            tabla.Columns.Add("Recuperacion");
            tabla.Columns.Add("Plazo");
            tabla.Columns.Add("Condiciones");
            tabla.Columns.Add("VentasMensual");
            tabla.Columns.Add("banco");
            tabla.Columns.Add("id_banco");

            var fila = tabla.NewRow();
            fila["IdPrecliente"] = tabuladores.IdPrecliente;
            fila["IdUsuario"] = tabuladores.IdUsuario;
            fila["EquipoOperacion"] = tabuladores.EquipoOperativo;
            fila["TipoCliente"] = tabuladores.TipoCliente;
            fila["RFC"] = tabuladores.RFC;
            fila["NombreClienteAlta"] = tabuladores.NombreCliente;
            fila["Cliente"] = tabuladores.ClientePedimento;
            fila["ConSitio"] = tabuladores.SitioFTP;
            fila["PaginaWeb"] = tabuladores.DireccionPaginaWeb;
            fila["Usuario"] = tabuladores.Usuario;
            fila["Password"] = tabuladores.Contrasena;
            fila["ConEntregaFisica"] = tabuladores.EntregaFisica;
            fila["DiasRevision"] = tabuladores.DiasRevision;
            fila["HorarioRevision"] = tabuladores.HorarioRevision;
            fila["PersonasRecibenFacturas"] = tabuladores.PersonasReciben;
            fila["NumeroJuegoCopias"] = tabuladores.NumJuegoCopia;
            fila["CalleNumero"] = tabuladores.CalleNumero;
            fila["Colonia"] = tabuladores.Colonia;
            fila["ID_Estado"] = tabuladores.Estado;
            fila["ID_Ciudad"] = tabuladores.Ciudad;
            fila["CodigoPostal"] = tabuladores.CP;
            fila["ConCtePedComprobados"] = tabuladores.ComprobadosCtePed;
            fila["ConCeteFactComprobados"] = tabuladores.ComprobadosCeteFact;
            fila["EmpresaFacturaComprobados"] = tabuladores.ComprobadosEmpresaFactura;
            fila["ConCtePedCtaAmericana"] = tabuladores.CtaAmericanaCtePed;
            fila["ConCeteFactCtaAmericana"] = tabuladores.CtaAmericanaCeteFact;
            fila["EmpresaFacturaCtaAmericana"] = tabuladores.CtaAmericanaEmpresaFactura;
            fila["ConCtePedHonorarios"] = tabuladores.HonorariosCtePed;
            fila["ConCeteFactHonorarios"] = tabuladores.HonorariosCeteFact;
            fila["EmpresaFacturaHonorarios"] = tabuladores.HonorariosEmpresaFactura;
            fila["ConCtePedImpuestos"] = tabuladores.ImpuestosCtePed;
            fila["ConCeteFactImpuestos"] = tabuladores.ImpuestosCeteFact;
            fila["EmpresaFacturaImpuestos"] = tabuladores.ImpuestosEmpresaFactura;
            fila["CtaAmeTC"] = tabuladores.CtaAMEFactura;
            fila["CtaAmeExpedidaPor"] = tabuladores.CtaAMEExpedida;
            fila["CtaAmeSeCobraEn"] = tabuladores.CtaAMECobra;
            fila["CtaAmeExpedidoPor"] = tabuladores.CtaAMEExpedidor;
            fila["ConImpuestosPECA"] = tabuladores.ImpuestoPeca;
            fila["DatosAdicionales"] = tabuladores.DatoAdicional;
            fila["MetodoPago"] = tabuladores.MetodoPago;
            fila["DigitosCuenta"] = tabuladores.UltimosDigitos;
            fila["InstruccionesEspeciales"] = tabuladores.Intrucciones;
            fila["CondicionesPago"] = tabuladores.CondicionPago;
            fila["PeriodoGracia"] = tabuladores.PeriodoGracia;
            fila["DiasPago"] = tabuladores.DiasPago;
            fila["HorarioPago"] = tabuladores.HorarioPago;
            fila["ConSuspensionCliente"] = tabuladores.SuspenderCliente;
            fila["ConFondo"] = tabuladores.Fondo;
            fila["MontoFondo"] = tabuladores.MontoFondo;
            fila["ConFinanciamiento"] = tabuladores.Financiamiento;
            fila["MontoFinanciamiento"] = tabuladores.Monto;
            fila["ParaUsoEn"] = tabuladores.ParaUso;
            fila["PuntoReorden"] = tabuladores.PuntoReorden;
            fila["Recuperacion"] = tabuladores.Recuperacion;
            fila["Plazo"] = tabuladores.Plazo;
            fila["Condiciones"] = tabuladores.Condicion;
            fila["VentasMensual"] = tabuladores.EstimadoVenta;

            fila["banco"] = tabuladores.Banco;
            fila["id_banco"] = tabuladores.BancoId;
            tabla.Rows.Add(fila);

            return tabla;
        }

        private DataTable TablaInformacionContacto(List<InformacionContactoDTO> contactos, int IDPrecliente)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("IdPrecliente");
            tabla.Columns.Add("Contacto");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Puesto");
            tabla.Columns.Add("Telefono");
            tabla.Columns.Add("Email");

            foreach (var item in contactos)
            {
                var fila = tabla.NewRow();
                fila["IdPrecliente"] = IDPrecliente;
                fila["Contacto"] = item.Contacto;
                fila["Nombre"] = item.Nombre;
                fila["Puesto"] = item.Puesto;
                fila["Telefono"] = item.Telefono;
                fila["Email"] = item.Email;
                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        private DataTable TablaTarifaServicio(List<TarifaServicioDTO> tarifas, int IDPrecliente)
        {
            var tabla = new DataTable();

            tabla.Columns.Add("IdPrecliente");
            tabla.Columns.Add("Servicio");
            tabla.Columns.Add("Tarifa");
            tabla.Columns.Add("Notas");

            foreach (var item in tarifas)
            {
                var fila = tabla.NewRow();
                fila["IdPrecliente"] = IDPrecliente;
                fila["Servicio"] = item.Servicio;
                fila["Tarifa"] = item.Tarifa;
                fila["Notas"] = item.Notas;
                tabla.Rows.Add(fila);
            }

            return tabla;
        }
        #endregion
        #endregion

        public DataTable BuscarDatosTabuladores(string id_precliente, ref bool temporal)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, "dbo.csp_CLI_BuscarDatosTabuladores_TMP");
            temporal = true;
            if (resultado.Rows.Count == 0)
            {
                parametro = new List<SqlParameter>();

                parametro.Add(new SqlParameter
                {
                    Value = id_precliente,
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id_precliente"
                });

                resultado = Select(parametro, "dbo.csp_CLI_BuscarDatosTabuladores");
                temporal = false;
            }

            return resultado;
        }

        public DataTable BuscarDatosTabuladoresContactos(string id_precliente, bool temporal = false)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, (temporal ? "dbo.csp_CLI_BuscarDatosTabuladoresContactos_TMP" : "dbo.csp_CLI_BuscarDatosTabuladoresContactos"));
            return resultado;
        }

        public DataTable BuscarDatosTabuladoresTarifas(string id_precliente, bool temporal = false)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, (temporal ? "dbo.csp_CLI_BuscarDatosTabuladoresTarifas_TMP" : "dbo.csp_CLI_BuscarDatosTabuladoresTarifas"));
            return resultado;
        }

        public DataTable BuscarDatosTabuladoresTabs(string id_precliente, bool temporal = false)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_precliente,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_precliente"
            });

            var resultado = Select(parametro, (temporal ? "dbo.csp_CLI_BuscarDatosTabuladoresTabs_TMP" : "dbo.csp_CLI_BuscarDatosTabuladoresTabs"));
            return resultado;
        }

        public DataTable BuscarDatosTabuladoresEmpresa(string id_tabulador_tab, bool temporal = false)
        {
            var parametro = new List<SqlParameter>();

            parametro.Add(new SqlParameter
            {
                Value = id_tabulador_tab,
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id_tabulador_tab"
            });

            var resultado = Select(parametro, (temporal ? "dbo.csp_CLI_BuscarDatosTabuladoresEmpresa_TMP" : "dbo.csp_CLI_BuscarDatosTabuladoresEmpresa"));
            return resultado;
        }
    }
}
