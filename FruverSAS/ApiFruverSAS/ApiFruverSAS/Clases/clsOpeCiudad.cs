using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsOpeCiudad
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();


        public tblCuidad tblCiu {  get; set; }

        public IQueryable listarCiudades(int idD)
        {
            return from tC in oEFR.tblCuidads
                   //Tabla modelo entity
                   .Where(x => x.idDpto == idD)
                   .OrderBy(x => x.Nombre)
                   select new { tC.Codigo, tC.Nombre };
        }

        public List<tblCuidad> listarCiudades()
        {
            return oEFR.tblCuidads //Tabla modelo entity
                .OrderBy(x =>x.Nombre)
                .ToList();
        }
    }
}