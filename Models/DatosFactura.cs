using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaDonMario.Models
{
    public class DatosFactura
    {
        public Factura datoFactura { get; set; }

        public Factura_Inevntario facturaInventario { get; set; }


    }
}