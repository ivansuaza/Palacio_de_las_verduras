using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsOpeGenero
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();

        public tblGenero tblGen { get; set; }


        public List<tblGenero> listarGenero()
        {
            return oEFR.tblGeneroes
                .OrderBy(x => x.Nombre)
                .ToList();
        }
    }
}