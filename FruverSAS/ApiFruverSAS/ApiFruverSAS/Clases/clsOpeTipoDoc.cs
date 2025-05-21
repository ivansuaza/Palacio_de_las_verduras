using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsOpeTipoDoc
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();

        public tbltipoDoc tblTdoc { get; set; }

        public List<tbltipoDoc> listarTipoDocs()
        {
            return oEFR.tbltipoDocs
                .OrderBy(x => x.Nombre)
                .ToList();
        }
    }
}