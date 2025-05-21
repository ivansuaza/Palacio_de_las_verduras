using ApiFruverSAS.Clases;
using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiFruverSAS.Controllers
{
    [EnableCors(origins: "http://localhost:51044", headers: "*", methods: "*")]
    public class TipoVentaController : ApiController
    {
        // GET api/<controller>
        public List<tblTipo_Venta> Get()
        {
            clsTipoVenta oTip = new clsTipoVenta();
            return oTip.listarTiposVentas(); 
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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