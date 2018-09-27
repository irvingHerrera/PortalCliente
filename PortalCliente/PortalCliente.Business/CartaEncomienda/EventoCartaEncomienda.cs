using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PortalCliente.Business.CartaEncomienda
{
    internal class EventoCartaEncomienda : PdfPageEventHelper
    {
        public string Encabezado { get; set; }

        public string PiePagina { get; set; }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte canvas = writer.DirectContent;
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_CENTER, new Phrase(new Chunk(" " + Encabezado + " ", new Font(Font.FontFamily.UNDEFINED, 11.0f, Font.NORMAL, BaseColor.BLACK))), 300, 760, 0);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(new Chunk(" FGEiIN04 ", new Font(Font.FontFamily.UNDEFINED, 10.5f, Font.NORMAL, BaseColor.BLACK))), 530, 30, 0);
        }
    }
}
