using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsFormaPago
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();

        public  tblFormaDePago tblFp {  get; set; }

        public List<tblFormaDePago> listarFormasPg()
        {
            return oEFR.tblFormaDePagoes
                .OrderBy(x => x.Nombre)
                .ToList();
        }
    }
}