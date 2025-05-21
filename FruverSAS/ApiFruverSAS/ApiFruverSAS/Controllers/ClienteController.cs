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
    public class ClienteController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IQueryable Get(int dato, int comando)
        {
            clsCliente datCli = new clsCliente();
            switch (comando)
            {
                case 1:
                    return datCli.listarClientes();

                default:
                    return datCli.listarXCliente(dato);
            }
        }

        // POST api/<controller>
        public string Post([FromBody] tblCliente datCli)
        {
            clsCliente opeCli = new clsCliente();
            opeCli.tblCli = datCli;
            return opeCli.Agregar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] tblCliente datCli)
        {
            clsCliente opeCli = new clsCliente();
            opeCli.tblCli = datCli;
            return opeCli.Modificar();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}