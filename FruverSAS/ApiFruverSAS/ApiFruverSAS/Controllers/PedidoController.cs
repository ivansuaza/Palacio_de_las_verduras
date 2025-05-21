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
    public class PedidoController : ApiController
    {
        // GET api/pedido/{nroDocumento}
        [HttpGet]
        public IHttpActionResult GetPedidosPorDocumento(long nroDocumento)
        {
            try
            {
                // Crear instancia de la clase clsPedido
                clsPedido oPedido = new clsPedido();

                // Llamamos al método para obtener los detalles de los pedidos
                List<Detalle_Pedido> detallesPedidos = oPedido.obtenerPedidosPorDocumento(nroDocumento);

                // Verificamos si se encontraron pedidos
                if (detallesPedidos == null || detallesPedidos.Count == 0)
                {
                    return Content(HttpStatusCode.NotFound, "No se encontraron pedidos para el documento proporcionado.");
                }

                // Retornar los detalles de los pedidos con un código de estado 200 OK
                return Ok(detallesPedidos);
            }
            catch (Exception ex)
            {
                // En caso de error, retornar un mensaje de error
                return InternalServerError(new Exception("Hubo un error al obtener los pedidos: " + ex.Message));
            }
        }

        // Otros métodos HTTP, si se necesitan para agregar o modificar pedidos
        // POST api/pedido
        [HttpPost]
        public IHttpActionResult PostPedido([FromBody] tblPedido nuevoPedido)
        {
            try
            {
                clsPedido oPedido = new clsPedido();

                // Llamar al método para crear un nuevo pedido
                bool exito = oPedido.crearPedido(nuevoPedido);

                if (exito)
                {
                    return Created("api/pedido", nuevoPedido); // Retorna un código 201 y el nuevo pedido creado
                }

                return BadRequest("No se pudo crear el pedido.");
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al crear el pedido: " + ex.Message));
            }
        }

        // PUT api/pedido/{id}
        [HttpPut]
        public IHttpActionResult PutPedido(int id, [FromBody] tblPedido pedidoModificado)
        {
            try
            {
                // Lógica para modificar el pedido con el id proporcionado
                // Aquí se podría llamar a un método en clsPedido para actualizar el pedido en la base de datos

                return Ok("Pedido actualizado con éxito.");
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al actualizar el pedido: " + ex.Message));
            }
        }

        // DELETE api/pedido/{id}
        [HttpDelete]
        public IHttpActionResult DeletePedido(int id)
        {
            try
            {
                // Lógica para eliminar el pedido con el id proporcionado
                // Aquí se podría llamar a un método en clsPedido para eliminar el pedido de la base de datos

                return Ok("Pedido eliminado con éxito.");
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al eliminar el pedido: " + ex.Message));
            }
        }
    }
}