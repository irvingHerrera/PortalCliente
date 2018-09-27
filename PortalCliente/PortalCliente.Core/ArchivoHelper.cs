using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalCliente.Core
{
    public class ArchivoHelper
    {
        private List<string> extension = new List<string> { "pdf", "jpg", "png", "gif" };

        public bool ExtensionValida(string extensionArchivo)
        {
            var rest = extension.Any(a => a.Equals(extensionArchivo.ToLower()));
            return rest;
        }

        public string GuiArchivo()
        {
            return DateTime.Now.Year.ToString() + 
                   DateTime.Now.Month.ToString() + 
                   DateTime.Now.Day.ToString() + 
                   DateTime.Now.Hour.ToString() + 
                   DateTime.Now.Minute.ToString() + 
                   DateTime.Now.Second.ToString() + 
                   DateTime.Now.Millisecond.ToString();
        }
    }
}
