using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsOpeDpto
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();


        public tblDepartamento tblDep { get; set; }

        public List<tblDepartamento> listarDptos()
        {
            return oEFR.tblDepartamentoes
               .OrderBy(x => x.Nombre)
               .ToList();
        }
        
    }
}