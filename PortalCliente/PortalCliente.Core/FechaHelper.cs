using System.Globalization;

namespace PortalCliente.Core
{
    public class FechaHelper
    {
        public string ObtenerNombreMes(int mes)
        {
            DateTimeFormatInfo cultura = new CultureInfo("es-ES", false).DateTimeFormat;
            return cultura.GetMonthName(mes);
        }
    }
}
