using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PortalCliente.Business
{
    internal class ExpedienteCliente
    {
        private string ObtenerGuiArchivo()
        {
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
        }

        private string ObtenerRutaImagen(List<string> rutaArchivo)
        {
            var extImagen = new List<string> { "jpg", "png", "gif" };
            var rutaImagen = string.Empty;

            foreach (var ruta in rutaArchivo)
            {
                var ext = ruta.Substring(ruta.Length - 3, 3).ToLower();
                if (extImagen.Any(x => x.Equals(ext)))
                {
                    Console.WriteLine("existe imagen");
                    rutaImagen = ruta;
                    break;
                }
            }

            return rutaImagen;
        }

        private List<string> ImagenToPDF(List<string> rutaArchivo, int idPrecliente, string path)
        {
            var rutaImagen = ObtenerRutaImagen(rutaArchivo);

            try
            {
                if (!string.IsNullOrEmpty(rutaImagen))
                {
                    var index = rutaArchivo.FindIndex(x => x.Equals(rutaImagen));
                    var rutaAbs = "Docs\\ImagenPDF" + idPrecliente.ToString() + ".pdf";
                    var rutaPdfImagen = path + rutaAbs;
                    rutaArchivo.RemoveAt(index);

                    using (var stream = File.Create(rutaPdfImagen))
                    using (var doc = new Document(PageSize.LETTER))
                    using (var pdfWriter = PdfWriter.GetInstance(doc, stream))
                    {
                        doc.Open();

                        using (var imageStream = File.OpenRead(path + rutaImagen))
                        {
                            var image = Image.GetInstance(imageStream);
                            image.ScaleAbsolute(doc.PageSize.Width, doc.PageSize.Height);
                            image.SetAbsolutePosition(0, 0);
                            doc.Add(image);
                        }

                        doc.Close();

                        rutaArchivo.Add(rutaAbs);
                    }

                }

                return rutaArchivo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public string GenerarExpediente(List<string> rutaArchivo, int idPrecliente, string path)
        {
            rutaArchivo = ImagenToPDF(rutaArchivo, idPrecliente, path);
            var carpeta = path;
            var rutaExpediente = "\\Documentos\\" + idPrecliente.ToString() + "\\Expediente" + ObtenerGuiArchivo() + ".pdf";

            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (Document doc = new Document())
                    {
                        PdfCopy pdf = new PdfCopy(doc, stream);
                        pdf.CloseStream = false;
                        doc.Open();

                        PdfReader reader = null;
                        PdfImportedPage page = null;

                        foreach (var file in rutaArchivo)
                        {
                            reader = new PdfReader(path + file);
                            for (int i = 0; i < reader.NumberOfPages; i++)
                            {
                                page = pdf.GetImportedPage(reader, i + 1);
                                pdf.AddPage(page);
                            }

                            pdf.FreeReader(reader);
                            reader.Close();
                        }
                    }
                    using (FileStream streamX = new FileStream(carpeta + "" + rutaExpediente, FileMode.Create))
                    {
                        stream.WriteTo(streamX);
                    }
                }

                return rutaExpediente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message +"\n"+ ex.StackTrace);
            }
           
        }
    }
}
