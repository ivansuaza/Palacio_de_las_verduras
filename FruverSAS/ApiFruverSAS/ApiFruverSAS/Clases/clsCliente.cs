using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsCliente
    {
        private readonly dbFruverEntities oEFR = new dbFruverEntities();


        public tblCliente tblCli { get; set; }

        public IQueryable listarClientes()
        {
            return from cliente in oEFR.Set<tblCliente>()
                   join tipoDoc in oEFR.Set<tbltipoDoc>()
                       on cliente.idTipoDoc equals tipoDoc.Codigo
                   join genero in oEFR.Set<tblGenero>()
                       on cliente.idGenero equals genero.Codigo
                   select new
                   {
                       Editar = "<a class='btn btn-info btn-sm' href=''><i class='fas fa-pencil-alt'></i>Editar</a>",
                       CodigoCliente = cliente.Codigo,
                       NombreCliente = cliente.Nombre,
                       ApellidoCliente = cliente.Apellido,
                       IDTipoDocumento = cliente.idTipoDoc,
                       NumeroDocumento = cliente.NroDoc,
                       IDGenero = cliente.idGenero
                   };
        }

        public IQueryable listarXCliente(int NroDoc)
        {
            return from cliente in oEFR.Set<tblCliente>()
                   join tipoDoc in oEFR.Set<tbltipoDoc>()
                       on cliente.idTipoDoc equals tipoDoc.Codigo
                   join genero in oEFR.Set<tblGenero>()
                       on cliente.idGenero equals genero.Codigo
                   where cliente.NroDoc == NroDoc
                   select new
                   {
                       CodigoCliente = cliente.Codigo,
                       NombreCliente = cliente.Nombre,
                       ApellidoCliente = cliente.Apellido,
                       IDTipoDocumento = cliente.idTipoDoc,
                       NumeroDocumento = cliente.NroDoc,
                       IDGenero = cliente.idGenero
                   };
        }

        public string Agregar()
        {

            var idmax = 0;
            try
            {
                idmax = oEFR.tblClientes.DefaultIfEmpty().Max(r => r == null ? 1 : r.Codigo + 1);
            }
            catch
            {

                return $"Hubo un Error al Calcular el Nuevo ID: {tblCli.Nombre}, con nroDoc: {tblCli.NroDoc} ";
            }

            tblCli.Codigo = idmax;
            try
            {
                oEFR.tblClientes.Add(tblCli);
                oEFR.SaveChanges();
                return $"Registro grabado con éxito: {tblCli.Nombre} , con nroDoc: {tblCli.NroDoc} su Codigo es : {tblCli.Codigo}";

            }
            catch
            {
                return $"Error, hubo fallo al grabar el registro: {tblCli.Codigo}, con nroDoc: {tblCli.NroDoc}";

            }


        }

        public string Modificar()
        {
            try
            {
                tblCliente tbCli = oEFR.tblClientes.FirstOrDefault(s => s.NroDoc == tblCli.NroDoc);
                tbCli.Codigo = tblCli.Codigo;
                tbCli.Nombre = tblCli.Nombre;
                tbCli.Apellido = tblCli.Apellido;
                tbCli.idTipoDoc = tblCli.idTipoDoc;
                tbCli.NroDoc = tblCli.NroDoc;
                tbCli.idGenero = tblCli.idGenero;
                
                oEFR.SaveChanges();
                return $"Se actualizo el registro de {tbCli.NroDoc}";


            }
            catch
            {

                return $"Error, hubo fallo al actualizar registro: {tblCli.Codigo}, reintente porfavor";
            }
        }
    }
}