using iTextSharp.text;
using iTextSharp.text.pdf;
using PortalCliente.Core;
using PortalCliente.Data.ENT;
using System;
using System.IO;

namespace PortalCliente.Business.CartaEncomienda
{
    internal class CartaEncomienda
    {
        #region Metodos Privados

        /// <summary>
        /// Genera la fecha para la carta encomienda
        /// </summary>
        /// <param name="ciudad"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        private Paragraph ObtenerFecha(string ciudad, string estado)
        {
            FechaHelper fechaHelper = new FechaHelper();

            var fechaCarta = new Paragraph();

            var chunkFecha = new Chunk("         " + ciudad + "," + estado + "         ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            chunkFecha = new Chunk(" a ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.NORMAL, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            chunkFecha = new Chunk("     " + DateTime.Now.Day.ToString() + "     ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            chunkFecha = new Chunk(" de ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.NORMAL, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            chunkFecha = new Chunk("     " + fechaHelper.ObtenerNombreMes(DateTime.Now.Month) + "     ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            chunkFecha = new Chunk(" de ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.NORMAL, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            chunkFecha = new Chunk("     " + DateTime.Now.Year.ToString() + "     ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK));
            fechaCarta.Add(chunkFecha);

            fechaCarta.Alignment = Element.ALIGN_RIGHT;

            return fechaCarta;
        }

        /// <summary>
        /// Genera el asunto de la carta
        /// </summary>
        /// <returns></returns>
        private Paragraph ObtenerAsunto()
        {
            var asunto = new Paragraph();
            var chunkAsunto = new Chunk("ASUNTO", new Font(Font.FontFamily.UNDEFINED, 10.0f, Font.BOLD, BaseColor.BLACK));
            asunto.Add(chunkAsunto);

            chunkAsunto = new Chunk(": Se confiere autorización según la Ley Aduanera para realizar en nuestra representación el", new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK));
            asunto.Add(chunkAsunto);

            asunto.Alignment = Element.ALIGN_RIGHT;
            asunto.IndentationLeft = 50.0f;

            return asunto;
        }

        /// <summary>
        /// Genera el destinatario de la carta
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private Document ObtenerComplemento(Document doc, CartaEncomiendaViewModel modelo)
        {
            var complemento = new Paragraph(15.0f, "C. AGENTE ADUANAL", new Font(Font.FontFamily.UNDEFINED, 10.0f, Font.BOLD, BaseColor.BLACK));
            complemento.Alignment = Element.ALIGN_LEFT;
            doc.Add(complemento);

            complemento = new Paragraph(15.0f, modelo.NombreAgenteAduanal, new Font(Font.FontFamily.UNDEFINED, 10.0f, Font.BOLD, BaseColor.BLACK));
            complemento.Alignment = Element.ALIGN_LEFT;
            doc.Add(complemento);

            complemento = new Paragraph(15.0f, "PATENTE: "+modelo.Patente, new Font(Font.FontFamily.UNDEFINED, 10.0f, Font.BOLD, BaseColor.BLACK));
            complemento.Alignment = Element.ALIGN_LEFT;
            doc.Add(complemento);

            complemento = new Paragraph(15.0f, "DIRECCIÓN: ", new Font(Font.FontFamily.UNDEFINED, 10.0f, Font.BOLD, BaseColor.BLACK));
            complemento.Alignment = Element.ALIGN_LEFT;
            doc.Add(complemento);

            complemento = new Paragraph(15.0f, modelo.DirreccionPatente, new Font(Font.FontFamily.UNDEFINED, 10.0f, Font.BOLD, BaseColor.BLACK));
            complemento.Alignment = Element.ALIGN_LEFT;
            doc.Add(complemento);

            return doc;
        }

        /// <summary>
        /// Agrega saltos de linea al documento 
        /// </summary>
        /// <param name="saltos"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        private Document SaltoLinea(int saltos, Document doc)
        {
            for (int i = 0; i < saltos; i++)
            {
                doc.Add(Chunk.NEWLINE);
            }

            return doc;
        }

        /// <summary>
        /// Agrega una frase en negrillas
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="frase"></param>
        /// <returns></returns>
        private Paragraph AgregarFrase(string texto, string frase)
        {
            var arrayTexto = texto.Split('&');
            var parrafo = new Paragraph(11.0f);
            var chuck = new Chunk(arrayTexto[0], new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK));
            parrafo.Add(chuck);
            chuck = new Chunk(frase, new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.BOLD, BaseColor.BLACK));
            parrafo.Add(chuck);
            chuck = new Chunk(arrayTexto[1], new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK));
            parrafo.Add(chuck);

            return parrafo;
        }

        /// <summary>
        /// Añade los datos faltantes de la carta que provienen del view model 
        /// por medio de stirng format
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="modelo"></param>
        /// <param name="rfc"></param>
        /// <returns></returns>
        private string RemplazarDatos(string texto, CartaEncomiendaViewModel modelo, string rfc)
        {
            var textoDato = string.Empty;

           
            return textoDato;
        }

        /// <summary>
        /// Añade los datos faltantes de la carta que provienen del view model y los pone en negrillas
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        private Paragraph RemplazarDatos(string texto, string[] datos)
        {
            var textoDato = string.Empty;
            var arrayTexto = texto.Split('|');

            var parrafoDato = new Paragraph(11.0f);

            for (int i = 0; i < datos.Length; i++)
            {

                var chunk = new Chunk(datos[i], new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.BOLD, BaseColor.BLACK));
                parrafoDato.Add(chunk);

                chunk = new Chunk(arrayTexto[i], new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK));
                parrafoDato.Add(chunk);
            }

            return parrafoDato;
        }

        /// <summary>
        /// Obtiene un arreglo con los datos faltantes de la carta
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="nombreRepresentante"></param>
        /// <param name="razonSocial"></param>
        /// <param name="rfc"></param>
        /// <returns></returns>
        private string[] ObtenerDatosFaltantes(CartaEncomiendaViewModel modelo, ClienteDTO modeloDTO)

        {
            FechaHelper fechaHelper = new FechaHelper();

            var datos = new string[] { "       "+modeloDTO.RepresentanteLegal,
                                       modeloDTO.NombreFiscal,
                                       modeloDTO.ObtenerDomicilioFiscal,
                                       modeloDTO.RFC,
                                       modelo.NumeroEscritura,
                                       modelo.NombreNotarioPublico,
                                       modelo.NumeroNotaria,
                                       modelo.CiudadNotariado+", "+modelo.EstadoNotariado,
                                      "AUTORIZARLO",
                                       modelo.PeriodoCompredidoInicio.Day.ToString(),
                                       fechaHelper.ObtenerNombreMes(modelo.PeriodoCompredidoInicio.Month),
                                       modelo.PeriodoCompredidoInicio.Year.ToString(),
                                       modelo.PeriodoCompredidoFin.Day.ToString(),
                                       fechaHelper.ObtenerNombreMes(modelo.PeriodoCompredidoFin.Month),
                                       modelo.PeriodoCompredidoFin.Year.ToString() };

            return datos;
        }

        #endregion



        public string GenerarCartaEncomienda(CartaEncomiendaViewModel modelo, ClienteDTO modeloDTO, string rutaFisica)
        {
            string nombreCarta = "CartaEncomienda" + modelo.IdPrecliente + ".pdf";
            EventoCartaEncomienda evento = new EventoCartaEncomienda();
            evento.Encabezado = modelo.MembreteEmpresa;

            var datos = ObtenerDatosFaltantes(modelo, modeloDTO);

            // \\ArchivoTexto\\cuerpoCartaEncomienda.txt
            try
            {
                var cuerpo = File.ReadAllText(rutaFisica + "ArchivoTexto\\cuerpoCartaEncomienda.txt");
                var parrafos = cuerpo.Split('@');

                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaFisica + "Docs\\"+nombreCarta, FileMode.Create));

                doc.AddTitle("Carta Encomienda");
                doc.AddCreator("OneCore");
                doc.Open();
                writer.PageEvent = evento;

                Font fuente = new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK);

                doc.Add(new Paragraph(10.0f, string.Empty, new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK)));
                doc = SaltoLinea(4, doc);

                doc.Add(ObtenerFecha(modeloDTO.Ciudad, modeloDTO.Estado));
                doc = SaltoLinea(1, doc);
                doc.Add(ObtenerAsunto());
                var complemento = new Paragraph(10.0f, "despachoaduanal de mercancías.", new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.NORMAL, BaseColor.BLACK));
                complemento.IndentationLeft = 168.0f;
                doc.Add(complemento);
                doc = SaltoLinea(4, doc);
                doc = ObtenerComplemento(doc, modelo);
                doc = SaltoLinea(1, doc);

                for (int index = 0; index < parrafos.Length; index++)
                {
                    var parrafo = new Paragraph(11.0f, parrafos[index], fuente);
                    if (index == 0)
                    {
                        parrafo = RemplazarDatos(parrafos[index], datos);
                    }

                    if (index == 2)
                        parrafo = AgregarFrase(parrafos[index], "a favor del Agente Aduanal");

                    parrafo.Alignment = Element.ALIGN_JUSTIFIED;
                    doc.Add(parrafo);
                }

                doc = SaltoLinea(4, doc);

                var firma = new Paragraph(10.0f, "PROTESTAMOS LO NECESARIO", new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.BOLD, BaseColor.BLACK));
                firma.Alignment = Element.ALIGN_CENTER;
                doc.Add(firma);

                doc = SaltoLinea(1, doc);

                firma = new Paragraph(10.0f, modeloDTO.RepresentanteLegal, new Font(Font.FontFamily.UNDEFINED, 9.5f, Font.BOLD, BaseColor.BLACK));
                firma.Alignment = Element.ALIGN_CENTER;
                doc.Add(firma);

                firma = new Paragraph(10.0f, modeloDTO.RFC, new Font(Font.FontFamily.UNDEFINED, 9.5f, Font.BOLD, BaseColor.BLACK));
                firma.Alignment = Element.ALIGN_CENTER;
                doc.Add(firma);

                doc = SaltoLinea(4, doc);

                firma = new Paragraph(10.0f, "REPRESENTANTE LEGAL", new Font(Font.FontFamily.UNDEFINED, 9.3f, Font.BOLD, BaseColor.BLACK));
                firma.Alignment = Element.ALIGN_CENTER;
                doc.Add(firma);

                doc.Close();
                writer.Close();

                return nombreCarta;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
