using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsTipoVenta
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();

        public tblTipo_Venta tblTv { get; set; }

        public List<tblTipo_Venta> listarTiposVentas()
        {
            return oEFR.tblTipo_Venta
                .OrderBy(x => x.Nombre)
               .ToList();
        }
    }
}