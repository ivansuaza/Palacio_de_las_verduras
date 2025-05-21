using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ApiFruverSAS.Clases;
using ApiFruverSAS.Models;

namespace ApiFruverSAS.Controllers
{
    [EnableCors(origins: "http://localhost:51044", headers: "*", methods: "*")]
    public class cuidadController : ApiController
    {
        // GET api/<controller>
        public List<tblCuidad> Get()
        {
            clsOpeCiudad oCiu = new clsOpeCiudad();
            return oCiu.listarCiudades();
        }

        // GET api/<controller>/5
        public IQueryable Get(int idDpto)
        {
            clsOpeCiudad oDep = new clsOpeCiudad();
            return oDep.listarCiudades(idDpto);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}