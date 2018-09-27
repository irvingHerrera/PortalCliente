using iTextSharp.text;
using iTextSharp.text.pdf;
using PortalCliente.Core;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;
using PortalCliente.Core.Enum;

namespace PortalCliente.Business.Impresion
{
    internal class ReporteImpresion
    {

        #region Metodos Privados

        private Document SaltoLinea(int saltos, Document doc)
        {
            for (int i = 0; i < saltos; i++)
            {
                doc.Add(Chunk.NEWLINE);
            }

            return doc;
        }

        private void EstiloCelda(PdfPCell pCell)
        {
            pCell.PaddingLeft = 5.0f;
            pCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            pCell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            pCell.Padding = 4;
            pCell.Border = Rectangle.NO_BORDER;
            pCell.UseAscender = true;
        }

        private void EstiloGrid(PdfPCell pCell)
        {
            pCell.PaddingLeft = 5.0f;
            pCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            pCell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            pCell.Padding = 5;
            pCell.Border = PdfPCell.BOTTOM_BORDER;
            pCell.UseAscender = true;
        }

        private PdfPTable Celda(PdfPTable tabla, string[] encabezado, bool tipo)
        {
            foreach (var item in encabezado)
            {
                PdfPCell cell = new PdfPCell(new Phrase(item, new Font(Font.FontFamily.UNDEFINED, 9.3f,
                    Font.NORMAL, tipo ? BaseColor.LIGHT_GRAY : BaseColor.BLACK)));
                EstiloCelda(cell);
                tabla.AddCell(cell);
            }

            return tabla;
        }

        private PdfPTable CeldaGrid(PdfPTable tabla, string[] encabezado, bool tipo)
        {
            foreach (var item in encabezado)
            {
                PdfPCell cell = new PdfPCell(new Phrase(item, new Font(Font.FontFamily.UNDEFINED, 9.3f,
                    tipo ? Font.BOLD : Font.NORMAL,
                    tipo ? new BaseColor(21, 67, 96) : BaseColor.BLACK)));
                EstiloGrid(cell);
                tabla.AddCell(cell);
            }

            return tabla;
        }

        private Document Titulo(Document documento, string titulo)
        {
            documento = SaltoLinea(3, documento);
            var parafor = new Paragraph(10.0f, " " + titulo, new Font(Font.FontFamily.UNDEFINED, 12.3f, Font.NORMAL, new BaseColor(52, 152, 219)));
            documento.Add(parafor);
            documento = SaltoLinea(2, documento);

            return documento;
        }

        private Document CrearSubtitulo(Document doc, string titulo, bool tipo, bool color)
        {
            doc.Add(new Paragraph(10.0f));
            doc = SaltoLinea(2, doc);
            var subtitulo = new Paragraph(7.0f, titulo, new Font(Font.FontFamily.UNDEFINED, 9.3f,
                    tipo ? Font.NORMAL : Font.BOLD, color ? BaseColor.LIGHT_GRAY : BaseColor.BLACK));
            doc.Add(subtitulo);
            doc = SaltoLinea(1, doc);

            return doc;
        }

        private string GenerarIdPreclienteVisual(string idPrecliente)
        {
            var precliente = "PRE_00000";

            precliente = precliente.Substring(0, (precliente.Length - 1) - (idPrecliente.Trim().Length - 1));

            return precliente + idPrecliente;
        }

        #endregion

        public string ReporteSolicitudCliente(SolicitudClienteModelo modelo, string path)
        {
            var rutaArchivo = string.Empty;

            try
            {
                if (modelo.InformacionCliente.Rows.Count == 0)
                    return string.Empty;

                var datoCliente = modelo.InformacionCliente.Rows[0];

                rutaArchivo = @"\Docs\solicitud" + new ArchivoHelper().GuiArchivo() + ".pdf";

                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(path + rutaArchivo, FileMode.Create));
                doc.AddTitle("Solicitud Cliente");
                doc.AddCreator("OneCore");
                doc.Open();

                PdfPTable tbInicio = new PdfPTable(2);
                tbInicio.SetWidths(new[] { 65, 75 });
                tbInicio.WidthPercentage = 100.0f;
                tbInicio = Celda(tbInicio, new string[] { "ID de Pre-cliente", "Representante y/o Apoderado Legal" }, true);
                tbInicio = Celda(tbInicio, new string[] { GenerarIdPreclienteVisual(datoCliente.Field<int>("id_precliente").ToString()),
                                                          datoCliente.Field<string>("representante_legal") }, false);
                doc.Add(tbInicio);

                doc.Add(new Paragraph(10.0f));

                //cliente -----
                doc = Titulo(doc, "Cliente");

                PdfPTable tbCliente = new PdfPTable(3);
                tbCliente.SetWidths(new[] { 60, 60, 60 });
                tbCliente.WidthPercentage = 100.0f;

                tbCliente = Celda(tbCliente, new string[] { "Nombre fiscal", "RFC", "" }, true);
                tbCliente = Celda(tbCliente, new string[] { datoCliente.Field<string>("nombre_fiscal"),
                                                            datoCliente.Field<string>("rfc"), "" }, false);

                tbCliente = Celda(tbCliente, new string[] { "Nombre comercial", "", "" }, true);
                tbCliente = Celda(tbCliente, new string[] { datoCliente.Field<string>("nombre_comercial"), "", "" }, false);

                tbCliente = Celda(tbCliente, new string[] { "Calle", "No. Ext.", "No. Int." }, true);
                tbCliente = Celda(tbCliente, new string[] { datoCliente.Field<string>("calle"),
                                                            datoCliente.Field<string>("no_ext"),
                                                            datoCliente.Field<string>("no_int") }, false);

                tbCliente = Celda(tbCliente, new string[] { "Colonia", "Ciudad", "C.P." }, true);
                tbCliente = Celda(tbCliente, new string[] { datoCliente.Field<string>("colonia"),
                                                            datoCliente.Field<string>("ciudad"),
                                                            datoCliente.Field<string>("cp") }, false);

                tbCliente = Celda(tbCliente, new string[] { "Estado", "País", "Teléfono" }, true);
                tbCliente = Celda(tbCliente, new string[] { datoCliente.Field<string>("estado"),
                                                            datoCliente.Field<string>("pais"),
                                                            datoCliente.Field<string>("telefono") }, false);

                doc.Add(tbCliente);

                //informacion contactos
                doc = Titulo(doc, "Información de contactos");

                PdfPTable tbContacto = new PdfPTable(5);
                tbContacto.SetWidths(new[] { 60, 60, 60, 60, 60 });
                tbContacto.WidthPercentage = 100.0f;

                tbContacto = CeldaGrid(tbContacto, new string[] { "Area", "Nombre", "Email", "Télefono", "Puesto/Dpto" }, true);

                foreach (DataRow fila in modelo.InformacionContacto.Rows)
                {
                    tbContacto = CeldaGrid(tbContacto, new string[] { fila.Field<string>("nombre"),
                                                                       fila.Field<string>("correo"),
                                                                       fila.Field<string>("telefono"),
                                                                       fila.Field<string>("area"),
                                                                        fila.Field<string>("puesto_departamento")}, false);
                }

                doc.Add(tbContacto);

                //DatosBancarios
                doc = Titulo(doc, "Datos bancarios");
                PdfPTable tbDatoBancario = new PdfPTable(3);
                tbDatoBancario.SetWidths(new[] { 60, 60, 60 });
                tbDatoBancario.WidthPercentage = 100.0f;

                tbDatoBancario = Celda(tbDatoBancario, new string[] { "Banco", "Cuenta", "Clabe" }, true);
                tbDatoBancario = Celda(tbDatoBancario, new string[] { datoCliente.Field<string>("banco"),
                                                                      datoCliente.Field<string>("numero_cuenta").ToString(),
                                                                      datoCliente.Field<string>("clabe_interbancaria").ToString()}, false);

                tbDatoBancario = Celda(tbDatoBancario, new string[] { "Moneda", "Sucursal", "Ciudad" }, true);
                tbDatoBancario = Celda(tbDatoBancario, new string[] { datoCliente.Field<string>("moneda"),
                                                                      datoCliente.Field<string>("sucursal_banco"),
                                                                      datoCliente.Field<string>("ciudad_banco")}, false);
                doc.Add(tbDatoBancario);

                doc.Add(new Paragraph(10.0f));
                doc = SaltoLinea(1, doc);
                var tituloPeca = new Paragraph(7.0f, "Cuenta bancaria autorizada para el pago de pedimentos y formularios múltiples (PECA)",
                    new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.LIGHT_GRAY));
                doc.Add(tituloPeca);
                doc = SaltoLinea(1, doc);

                PdfPTable tbPeca = new PdfPTable(5);
                tbPeca.SetWidths(new[] { 60, 60, 60, 60, 60 });
                tbPeca.WidthPercentage = 100.0f;

                tbPeca = CeldaGrid(tbPeca, new string[] { "Banco", "No cuenta", "Identificador", "Patentes autorizadas", "Aduana" }, true);

                foreach (DataRow fila in modelo.InformacionCuenta.Rows)
                {
                    tbPeca = CeldaGrid(tbPeca, new string[] { fila.Field<string>("banco"),
                                                              fila.Field<int>("numero_cuenta").ToString(),
                                                              fila.Field<string>("identificador"),
                                                              fila.Field<string>("patentes_autorizadas"),
                                                              fila.Field<string>("aduana"),}, false);
                }

                doc.Add(tbPeca);

                doc.Close();
                writer.Close();
            }
            catch (System.Exception ex)
            {
                rutaArchivo = string.Empty;
            }

            return rutaArchivo;
        }

        public string ReporteProcedimientoOperacion(List<ProcedimientoModelo> modelo, string path)
        {
            var rutaArchivo = string.Empty;
            var informacionCompleta = true;
            try
            {
                rutaArchivo = @"\Docs\procedimiento" + new ArchivoHelper().GuiArchivo() + ".pdf";

                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(path + rutaArchivo, FileMode.Create));
                doc.AddTitle("Procedimiento Operación");
                doc.AddCreator("OneCore");
                doc.Open();

                for (int index = 0; index < modelo.Count; index++)
                {
                    doc = Titulo(doc, modelo[index].Titulo[index].titulo_seccion);

                    DataTable dirreccion = new DataTable();
                    DataTable cuenta = new DataTable();

                    if (modelo[index].Cuentas.Rows.Count > 0)
                    {
                        cuenta = modelo[index].Cuentas;
                    }
                    else
                    {
                        informacionCompleta = false;
                    }


                    if (modelo[index].Cuentas.Rows.Count > 0)
                    {
                        dirreccion = modelo[index].Dirreccion;
                    }
                    else
                    {
                        informacionCompleta = false;
                    }

                    if (!informacionCompleta)
                    {
                        return string.Empty;
                    }

                    PdfPTable tabla = new PdfPTable(1);
                    tabla.SetWidths(new[] { 75 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "1. Descripción de la operación" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.DescripcionOperacion }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "1.1 Consignación de mercancías", true, true);

                    tabla = new PdfPTable(2);
                    tabla.SetWidths(new[] { 70, 70 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "La mercancía se consigna de la siguiente manera:", "Contacto Operativo" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.FormaConsigueMenrcancia, modelo[index].DatoProcedimiento.ContactoOperativo }, false);

                    tabla = Celda(tabla, new string[] { "Contacto Cliente", "Observaciones específicas" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.ContactoCliente, modelo[index].DatoProcedimiento.ObservacionesEspecificas }, false);

                    tabla = Celda(tabla, new string[] { "1.2 Apertura de Consolidados (firmas y/o pedimentos)", "2. Envío de información y/o documentos" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.AperturaConsolidados, modelo[index].DatoProcedimiento.EnvioInformacionDocumentos }, false);

                    tabla = Celda(tabla, new string[] { "3. Clasificación", "" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Clasificacion, "" }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "4. Elaboración de pedimento", false, true);

                    tabla = new PdfPTable(4);
                    tabla.SetWidths(new[] { 60, 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Tipo de Pedimento", "Régimen", "Manejo de Pedimento", "Incoterm" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Id_TipodePedimentoDES,
                                                        modelo[index].DatoProcedimiento.Id_RegimenDES,
                                                        modelo[index].DatoProcedimiento.Id_ManejodePedimentoDES,
                                                        modelo[index].DatoProcedimiento.Id_IncotermDES}, false);

                    tabla = Celda(tabla, new string[] { "Método de valoración", "Forma de pago", "Vinculación", "Aplicación de Preferencias" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Id_MetodoValoracionDES,
                                                        modelo[index].DatoProcedimiento.Id_FormaPagoDES,
                                                        modelo[index].DatoProcedimiento.Vinculacion ? "SI" : "NO" ,
                                                        modelo[index].DatoProcedimiento.Id_AplicacionPreferenciasDES }, false);

                    tabla = Celda(tabla, new string[] { "Aplicación de TLCAN", "Incrementables", "Envío de proforma a autorización", "" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.AplicacionTLCAN ? "SI" : "NO",
                                                        modelo[index].DatoProcedimiento.Incrementables ? "SI" : "NO",
                                                        modelo[index].DatoProcedimiento.EnvioProformaAutorizacion ? "SI" : "NO", "" }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "Generación de acuse de COVE y acuse de Edocuments con los sellos de A.A o Cliente", false, true);

                    tabla = new PdfPTable(1);
                    tabla.SetWidths(new[] { 70 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Grupo EI genera el EEI (Electronic Export Information)" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.GrupoGeneralEEI ? "SI" : "NO" }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "Forma de cargo para pago de impuestos en pedimento", false, false);

                    tabla = new PdfPTable(4);
                    tabla.SetWidths(new[] { 60, 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = CeldaGrid(tabla, new string[] { "Banco", "Cuenta", "Identificador", "Aduana" }, true);

                    foreach (DataRow fila in cuenta.Rows)
                    {
                        tabla = CeldaGrid(tabla, new string[] { fila.Field<string>("banco"),
                                                              fila.Field<int>("numero_cuenta").ToString(),
                                                              fila.Field<string>("identificador"),
                                                              fila.Field<string>("aduana"),}, false);
                    }

                    doc.Add(tabla);

                    doc.Add(new Paragraph(15.0f));
                    doc = SaltoLinea(1, doc);

                    tabla = new PdfPTable(1);
                    tabla.SetWidths(new[] { 70 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Observaciones específicas" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.ObservacionesEspecificas }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "5. Despacho de mercancías", false, true);

                    tabla = new PdfPTable(3);
                    tabla.SetWidths(new[] { 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "5.1 Recibo", "5.2 Descarga", "5.3 Previo" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Recibo,
                                                        modelo[index].DatoProcedimiento.Descarga,
                                                        modelo[index].DatoProcedimiento.Previo }, false);

                    tabla = Celda(tabla, new string[] { "5.4 Reporte de daños", "5.5 Carga", "5.6 Coordinación de transporte" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.ReporteDanos,
                                                        modelo[index].DatoProcedimiento.Carga,
                                                        modelo[index].DatoProcedimiento.CoordinacionTransporte }, false);

                    tabla = Celda(tabla, new string[] { "5.7 Entrega de mercancías", "Observaciones específicas", "6. Servicios extraordinarios" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.EntregaMercancias,
                                                        modelo[index].DatoProcedimiento.ObservacionesEspecificas,
                                                        modelo[index].DatoProcedimiento.ServiciosExtraordinarios }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "7. Administración", false, true);

                    doc = CrearSubtitulo(doc, "7.1 Financiamiento", false, true);

                    tabla = new PdfPTable(3);
                    tabla.SetWidths(new[] { 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Monto", "Para uso en", "Punto de reorden" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Monto.ToString(),
                                                        modelo[index].DatoProcedimiento.Parausoen,
                                                        modelo[index].DatoProcedimiento.PuntoReorden }, false);

                    tabla = Celda(tabla, new string[] { "Recuperación", "Plazo", "Condiciones" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Recuperacion,
                                                        modelo[index].DatoProcedimiento.Plazo.ToString(),
                                                        modelo[index].DatoProcedimiento.Condiciones }, false);

                    tabla = Celda(tabla, new string[] { "7.2 Facturación", "7.3 Cobranza", "" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.Facturacion,
                                                        modelo[index].DatoProcedimiento.Cobranza, "" }, false);

                    doc.Add(tabla);

                    doc.Add(new Paragraph(15.0f));
                    doc = SaltoLinea(1, doc);

                    tabla = new PdfPTable(4);
                    tabla.SetWidths(new[] { 60, 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "8. Indicadores de desempeño", "", "", "" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.IndicadoresDesempeno, "", "", "" }, false);

                    tabla = Celda(tabla, new string[] { "8.1 KPI", "8.2 Reportes", "9. HC/MV2", "10. Post-Venta" }, true);
                    tabla = Celda(tabla, new string[] { modelo[index].DatoProcedimiento.KPI,
                                                        modelo[index].DatoProcedimiento.Reportes,
                                                        modelo[index].DatoProcedimiento.HCMVDos,
                                                        modelo[index].DatoProcedimiento.PostVenta }, false);

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "11. Contactos", false, true);
                    doc = CrearSubtitulo(doc, "11.1 Contactos GRUPO EI", false, true);

                    tabla = new PdfPTable(4);
                    tabla.SetWidths(new[] { 60, 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = CeldaGrid(tabla, new string[] { "Nombre", "Email", "Teléfono", "Puesto/Dpto" }, true);

                    foreach (var item in modelo[index].DatoProcedimiento.ContactosEI)
                    {
                        tabla = CeldaGrid(tabla, new string[] { item.nombre, item.correo, item.telefono, item.puesto_departamento }, false);
                    }

                    doc.Add(tabla);

                    doc = CrearSubtitulo(doc, "11.2 Contactos (" + dirreccion.Rows[0].Field<string>("nombre_comercial") + ")", false, true);

                    tabla = new PdfPTable(4);
                    tabla.SetWidths(new[] { 60, 60, 60, 60 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = CeldaGrid(tabla, new string[] { "Nombre", "Email", "Teléfono", "Puesto/Dpto" }, true);

                    foreach (var item in modelo[index].Contactos)
                    {
                        tabla = CeldaGrid(tabla, new string[] { item.Nombre, item.Correo, item.Telefono, item.PuestoDepartamento }, false);
                    }

                    doc.Add(tabla);

                    doc.Add(new Paragraph(10.0f));
                    doc = SaltoLinea(2, doc);
                    var subtitulo = new Paragraph(7.0f, "12.2 Oficinas (" + dirreccion.Rows[0].Field<string>("nombre_comercial") + "))", new Font(Font.FontFamily.UNDEFINED, 9.3f,
                            Font.NORMAL, BaseColor.LIGHT_GRAY));
                    doc.Add(subtitulo);

                    subtitulo = new Paragraph(10.0f, dirreccion.Rows[0].Field<string>("direccion"), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                            Font.NORMAL, BaseColor.DARK_GRAY));
                    doc.Add(subtitulo);
                    doc = SaltoLinea(1, doc);
                }

                doc.Close();
                writer.Close();
            }
            catch (System.Exception ex)
            {
                rutaArchivo = string.Empty;
            }

            return rutaArchivo;
        }

        public string ReporteTabulador(TabuladorModelo modelo, string path)
        {
            var rutaArchivo = string.Empty;
            var tabulador = modelo.Tabulador.Rows[0];
            rutaArchivo = @"\Docs\procedimiento" + new ArchivoHelper().GuiArchivo() + ".pdf";

            try
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(path + rutaArchivo, FileMode.Create));
                doc.AddTitle("Tabuladores");
                doc.AddCreator("OneCore");
                doc.Open();

                doc.Add(new Paragraph(7.0f));

                PdfPTable tabla = new PdfPTable(2);
                tabla.SetWidths(new[] { 70, 70 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Ejecutivo de ventas", "Equipo operativo" }, true);
                tabla = Celda(tabla, new string[] { tabulador["EjecutivoVenta"].ToString(),
                                                    tabulador["descripcion_equipo"].ToString() }, false);
                doc.Add(tabla);

                doc.Add(new Paragraph(7.0f));
                doc = Titulo(doc, "Tipo Cliente");
                var tipoCliente = (TipoCliente)Enum.Parse(typeof(TipoCliente), tabulador["TipoCliente"].ToString());

                var checkTipoCliente = new Paragraph();
                var checkTipo = new Chunk(tipoCliente.GetDescription(), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.BOLD, BaseColor.BLACK));
                checkTipoCliente.Alignment = Element.ALIGN_CENTER;
                checkTipoCliente.Add(checkTipo);
                doc.Add(checkTipoCliente);

                doc.Add(new Paragraph(7.0f));
                doc = SaltoLinea(1, doc);

                tabla = new PdfPTable(2);
                tabla.SetWidths(new[] { 70, 70 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "RFC de Servicios de la sociedad que va a facturar", "" }, true);
                tabla = Celda(tabla, new string[] { tabulador["RFC"].ToString(), "" }, false);

                if (tipoCliente != TipoCliente.PedimientoFactura)
                {
                    tabla = Celda(tabla, new string[] { "Nombre Cliente Alta", "Cliente Pedimento" }, true);
                    tabla = Celda(tabla, new string[] { tabulador["NombreCliente"].ToString(), tabulador["ClientePedimento"].ToString() }, false);
                }


                doc.Add(new Paragraph(7.0f));
                doc.Add(tabla);
                doc.Add(new Paragraph(7.0f));
                doc = Titulo(doc, "Instrucciones de facturación");

                var check = new Paragraph();
                var tituloCheck = new Chunk("  Sitio FTP o página web para carga de facturas electrónicas", new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.LIGHT_GRAY));
                var respuestaCheck = new Chunk("     " + (Convert.ToBoolean(tabulador["SitioFTP"].ToString()) ? "Si" : "NO"), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.BLACK));
                check.Add(tituloCheck);
                check.Add(respuestaCheck);
                doc.Add(check);
                doc.Add(new Paragraph(7.0f));
                doc = SaltoLinea(1, doc);

                tabla = new PdfPTable(3);
                tabla.SetWidths(new[] { 65, 65, 65 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Dirección de la página web", "Usuario", "Contraseña" }, true);
                tabla = Celda(tabla, new string[] { tabulador["DireccionPaginaWeb"].ToString(),
                                                    tabulador["Usuario"].ToString(),
                                                    tabulador["Contrasena"].ToString() }, false);
                doc.Add(tabla);

                var isEntregaFisica = Convert.ToBoolean(tabulador["EntregaFisica"].ToString());

                check = new Paragraph();
                tituloCheck = new Chunk("  El cliente requiere entrega física", new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.LIGHT_GRAY));
                respuestaCheck = new Chunk("      " + (isEntregaFisica ? "Si" : "NO"), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.BLACK));
                check.Add(tituloCheck);
                check.Add(respuestaCheck);
                doc.Add(check);

                doc.Add(new Paragraph(7.0f));
                doc = SaltoLinea(1, doc);

                if (isEntregaFisica)
                {
                    tabla = new PdfPTable(3);
                    tabla.SetWidths(new[] { 65, 65, 65 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Días de revisión", "Horario de revisión", "Horario de revisión" }, true);
                    tabla = Celda(tabla, new string[] { tabulador["DiasRevision"].ToString(),
                                                    tabulador["HorarioRevision"].ToString(),
                                                    tabulador["PersonasReciben"].ToString() }, false);

                    tabla = Celda(tabla, new string[] { "No. Juego de copias", "Calle y número", "Colonia" }, true);
                    tabla = Celda(tabla, new string[] { tabulador["NumJuegoCopia"].ToString(),
                                                    tabulador["CalleNumero"].ToString(),
                                                    tabulador["Colonia"].ToString() }, false);

                    tabla = Celda(tabla, new string[] { "Estado", "Ciudad", "C.P." }, true);
                    tabla = Celda(tabla, new string[] { tabulador["estado"].ToString(),
                                                    tabulador["ciudad"].ToString(),
                                                    tabulador["CP"].ToString() }, false);

                    doc.Add(tabla);
                }

                doc = Titulo(doc, "Tabuladores");

                tabla = new PdfPTable(4);
                tabla.SetWidths(new[] { 75, 75, 75, 75 });
                tabla.WidthPercentage = 100.0f;

                tabla = CeldaGrid(tabla, new string[] { "Concepto", "CtePed", "CeteFact", "Empresa que factura" }, true);
                tabla = CeldaGrid(tabla, new string[] { "Impuesto",
                                                        Convert.ToBoolean(tabulador["ImpuestosCtePed"].ToString()) ? "SI" : "NO",
                                                        Convert.ToBoolean(tabulador["ImpuestosCeteFact"].ToString()) ? "SI" : "NO",
                                                        tabulador["ImpuestosEmpresaFactura"].ToString()}, false);
                tabla = CeldaGrid(tabla, new string[] { "Honorarios",
                                                        Convert.ToBoolean(tabulador["HonorariosCtePed"].ToString()) ? "SI" : "NO",
                                                        Convert.ToBoolean(tabulador["HonorariosCeteFact"].ToString()) ? "SI" : "NO",
                                                        tabulador["HonorariosEmpresaFactura"].ToString()}, false);
                tabla = CeldaGrid(tabla, new string[] { "Cta Americana",
                                                        Convert.ToBoolean(tabulador["CtaAmericanaCtePed"].ToString()) ? "SI" : "NO",
                                                        Convert.ToBoolean(tabulador["CtaAmericanaCeteFact"].ToString()) ? "SI" : "NO",
                                                        tabulador["CtaAmericanaEmpresaFactura"].ToString()}, false);
                tabla = CeldaGrid(tabla, new string[] { "Comprobados",
                                                        Convert.ToBoolean(tabulador["ComprobadosCtePed"].ToString()) ? "SI" : "NO",
                                                        Convert.ToBoolean(tabulador["ComprobadosCeteFact"].ToString()) ? "SI" : "NO",
                                                        tabulador["ComprobadosEmpresaFactura"].ToString()}, false);

                doc.Add(tabla);
                doc.Add(new Paragraph(9.0f));
                doc = SaltoLinea(1, doc);


                tabla = new PdfPTable(3);
                tabla.SetWidths(new[] { 80, 75, 75 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Cta AME: Para la factura de ELI a la Americana utilizar el TC del:", "Cta AME/expedida a:", "" }, true);
                tabla = Celda(tabla, new string[] { tabulador["CtaAMEFactura"].ToString(),
                                                    tabulador["CtaAMEExpedida"].ToString(), "" }, false);

                tabla = Celda(tabla, new string[] { "Cta AME/se cobra en:", "Compr/Expedidor por:", "Impuestos por PECA" }, true);
                tabla = Celda(tabla, new string[] { tabulador["CtaAMECobra"].ToString(),
                                                    tabulador["CtaAMEExpedidor"].ToString(),
                                                    Convert.ToBoolean(tabulador["ImpuestoPeca"].ToString()) ? "SI" : "NO" }, false);

                doc.Add(tabla);
                doc.Add(new Paragraph(7.0f));
                doc = SaltoLinea(1, doc);

                for (int i = 0; i < modelo.TabuladorTabs.Rows.Count; i++)
                {
                    doc = Titulo(doc, "Tabulador " + (i + 1));

                    tabla = new PdfPTable(4);
                    tabla.SetWidths(new[] { 65, 65, 65, 65 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Tipo de operación", "Aduana", "Clave pedimento", "Moneda" }, true);
                    tabla = Celda(tabla, new string[] { modelo.TabuladorTabs.Rows[i]["TipoOperacion"].ToString(),
                                                    modelo.TabuladorTabs.Rows[i]["aduana_descripcion"].ToString(),
                                                    modelo.TabuladorTabs.Rows[i]["pedimento_descripcion"].ToString(),
                                                    modelo.TabuladorTabs.Rows[i]["Moneda"].ToString()}, false);

                    tabla = Celda(tabla, new string[] { "Facturación", "Días libres en almacén Laredo", "", "" }, true);
                    tabla = Celda(tabla, new string[] { modelo.TabuladorTabs.Rows[i]["Facturacion"].ToString(),
                                                        modelo.TabuladorTabs.Rows[i]["DiasLibres"].ToString(), "", "" }, false);

                    doc.Add(tabla);

                    doc.Add(new Paragraph(9.0f));
                    doc = SaltoLinea(1, doc);

                    tabla = new PdfPTable(7);
                    tabla.SetWidths(new[] { 75, 75, 75, 75, 65, 75, 65 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = CeldaGrid(tabla, new string[] { "Empresa", "Concepto facturación", "Concepto autofacturacion", "Tarifa venta", "", "Tarifa de compra", "" }, true);

                    foreach (DataRow fila in modelo.TabuladorEmpresa.Rows)
                    {
                        if (Convert.ToInt32(modelo.TabuladorEmpresa.Rows[i]["id_tabulador_tab"].ToString()) ==
                            Convert.ToInt32(modelo.TabuladorTabs.Rows[i]["id_tabulador_tab"].ToString())) {

                            tabla = CeldaGrid(tabla, new string[] { fila["empresa"].ToString(),
                                                        fila["descripcion_facturacion"].ToString(),
                                                        fila["descripcion_autofacturacion"].ToString(),
                                                        fila["tarifa_venta"].ToString(),
                                                        fila["tarifa_venta_tipo_moneda"].ToString(),
                                                        fila["tarifa_compra"].ToString(),
                                                        fila["tarifa_compra_tipo_moneda"].ToString() }, false);

                        }

                    }

                    doc.Add(tabla);
                    doc.Add(new Paragraph(9.0f));
                    doc = SaltoLinea(2, doc);
                }



                tabla = new PdfPTable(3);
                tabla.SetWidths(new[] { 75, 65, 65 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Datos adicionales para agregar en las factura", "Método de pago", "Últimos 4 dígitos de la cuenta" }, true);
                tabla = Celda(tabla, new string[] { tabulador["DatoAdicional"].ToString(),
                                                    tabulador["MetodoPago"].ToString(),
                                                    tabulador["UltimosDigitos"].ToString() }, false);
                doc.Add(tabla);

                tabla = new PdfPTable(1);
                tabla.SetWidths(new[] { 100 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Instrucciones especiales" }, true);
                tabla = Celda(tabla, new string[] { tabulador["Intrucciones"].ToString() }, false);
                doc.Add(tabla);

                doc.Add(new Paragraph(9.0f));
                doc = SaltoLinea(1, doc);

                doc.Add(new Paragraph(7.0f));
                doc = Titulo(doc, "Información financiera y de cobranza");

                tabla = new PdfPTable(4);
                tabla.SetWidths(new[] { 70, 70, 70, 70 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Condiciones de pago", "Periodo de gracia", "Días de pago", "Horario de pago" }, true);
                tabla = Celda(tabla, new string[] { tabulador["CondicionPago"].ToString(),
                                                    tabulador["PeriodoGracia"].ToString(),
                                                    tabulador["DiasPago"].ToString(),
                                                    tabulador["HorarioPago"].ToString() }, false);
                doc.Add(tabla);

                check = new Paragraph();
                tituloCheck = new Chunk("  ¿Se autoriza a suspender al cliente, pasado el periodo de gracia?", new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.LIGHT_GRAY));
                respuestaCheck = new Chunk("      " + (Convert.ToBoolean(tabulador["SuspenderCliente"].ToString()) ? "SI" : "NO"), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.BLACK));
                check.Add(tituloCheck);
                check.Add(respuestaCheck);
                doc.Add(check);

                doc.Add(new Paragraph(9.0f));
                doc = SaltoLinea(1, doc);

                tabla = new PdfPTable(5);
                tabla.SetWidths(new[] { 75, 75, 75, 75, 75 });
                tabla.WidthPercentage = 100.0f;

                tabla = CeldaGrid(tabla, new string[] { "Contacto", "Nombre", "Puesto", "Telefono", "Email" }, true);

                for (int i = 0; i < modelo.TabuladorContacto.Rows.Count; i++)
                {

                    tabla = CeldaGrid(tabla, new string[] {
                                                            modelo.TabuladorContacto.Rows[i]["contacto"].ToString(),
                                                            modelo.TabuladorContacto.Rows[i]["nombre"].ToString(),
                                                            modelo.TabuladorContacto.Rows[i]["puesto"].ToString(),
                                                            modelo.TabuladorContacto.Rows[i]["telefono"].ToString(),
                                                            modelo.TabuladorContacto.Rows[i]["email"].ToString() }, false);

                    doc.Add(tabla);
                    doc.Add(new Paragraph(9.0f));
                    doc = SaltoLinea(2, doc);
                }



                check = new Paragraph();
                tituloCheck = new Chunk("  Fondo", new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.LIGHT_GRAY));
                respuestaCheck = new Chunk("      " + (Convert.ToBoolean(tabulador["Fondo"].ToString()) ? "SI" : "NO"), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.BLACK));
                check.Add(tituloCheck);
                check.Add(respuestaCheck);
                doc.Add(check);

                doc.Add(new Paragraph(5.0f));
                doc = SaltoLinea(1, doc);

                tabla = new PdfPTable(1);
                tabla.SetWidths(new[] { 100 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Monto" }, true);
                tabla = Celda(tabla, new string[] { tabulador["MontoFondo"].ToString() }, false);
                doc.Add(tabla);

                var isFinanciamiento = Convert.ToBoolean(tabulador["Financiamiento"].ToString());

                check = new Paragraph();
                tituloCheck = new Chunk("  Financiamiento ", new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.LIGHT_GRAY));
                respuestaCheck = new Chunk("      " + ( isFinanciamiento ? "SI" : "NO"), new Font(Font.FontFamily.UNDEFINED, 9.3f,
                        Font.NORMAL, BaseColor.BLACK));
                check.Add(tituloCheck);
                check.Add(respuestaCheck);
                doc.Add(check);

                doc.Add(new Paragraph(5.0f));
                doc = SaltoLinea(1, doc);

                if (isFinanciamiento)
                {
                    tabla = new PdfPTable(3);
                    tabla.SetWidths(new[] { 75, 75, 75 });
                    tabla.WidthPercentage = 100.0f;

                    tabla = Celda(tabla, new string[] { "Monto", "Para uso en", "Punto de reorden" }, true);
                    tabla = Celda(tabla, new string[] { tabulador["Monto"].ToString(),
                                                    tabulador["ParaUso"].ToString(),
                                                    tabulador["PuntoReorden"].ToString() }, false);

                    tabla = Celda(tabla, new string[] { "Recuperación", "Plazo", "Condiciones" }, true);
                    tabla = Celda(tabla, new string[] { tabulador["Recuperacion"].ToString(),
                                                    tabulador["Plazo"].ToString(),
                                                    tabulador["Condicion"].ToString() }, false);

                    doc.Add(tabla);
                    doc.Add(new Paragraph(7.0f));
                }

                doc = Titulo(doc, "Tarifa de ventas de posibles servicios");

                doc.Add(new Paragraph(7.0f));
                doc = SaltoLinea(1, doc);

                tabla = new PdfPTable(3);
                tabla.SetWidths(new[] { 75, 75, 75 });
                tabla.WidthPercentage = 100.0f;
                tabla = CeldaGrid(tabla, new string[] { "Servicio", "Tarifa", "Notas" }, true);

                for (int i = 0; i < modelo.TabuladorTarifa.Rows.Count; i++)
                {
                    tabla = CeldaGrid(tabla, new string[] {
                                                        modelo.TabuladorTarifa.Rows[i]["servicio"].ToString(),
                                                        modelo.TabuladorTarifa.Rows[i]["tarifa"].ToString(),
                                                        modelo.TabuladorTarifa.Rows[i]["notas"].ToString() }, false);
                }





                doc.Add(tabla);
                doc.Add(new Paragraph(9.0f));
                doc = SaltoLinea(2, doc);

                tabla = new PdfPTable(1);
                tabla.SetWidths(new[] { 100 });
                tabla.WidthPercentage = 100.0f;

                tabla = Celda(tabla, new string[] { "Estimado de ventas promedio mensual" }, true);
                tabla = Celda(tabla, new string[] { tabulador["EstimadoVenta"].ToString() }, false);
                doc.Add(tabla);

                doc.Close();
                writer.Close();
            }
            catch (System.Exception ex)
            {
                rutaArchivo = string.Empty;
            }

            return rutaArchivo;
        }

    }
}
