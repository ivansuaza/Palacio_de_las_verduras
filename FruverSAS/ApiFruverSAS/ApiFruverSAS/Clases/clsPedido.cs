using ApiFruverSAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    public class clsPedido
    {
        // Instancia del contexto de la base de datos
        private readonly dbFruverEntities oEFR = new dbFruverEntities();

        // Método para obtener pedidos de un cliente por su número de documento
        public List<Detalle_Pedido> obtenerPedidosPorDocumento(long nroDocumento)
        {
            try
            {
                // Buscamos los pedidos asociados al cliente con el número de documento
                var pedidos = oEFR.tblPedidoes
                    .Where(p => p.tblCliente.NroDoc == nroDocumento)  // Asumiendo que hay una relación entre Pedido y Cliente
                    .Select(p => new
                    {
                        p.idCliente,
                        p.Fecha_Pedido,
                        p.Fecha_Entrega,
                        Detalles = p.Detalle_Pedido  // Relación con los detalles del pedido
                    })
                    .ToList();

                // Convertimos los resultados a una lista de Detalle_Pedido
                List<Detalle_Pedido> detallePedidos = new List<Detalle_Pedido>();

                foreach (var pedido in pedidos)
                {
                    detallePedidos.AddRange(pedido.Detalles);  // Añadimos los detalles de cada pedido
                }

                return detallePedidos;
            }
            catch (Exception ex)
            {
                // En caso de error, lanzar una excepción personalizada o manejar el error
                throw new Exception("Error al obtener los pedidos: " + ex.Message);
            }
        }

        // Método para crear un nuevo pedido (ejemplo)
        public bool crearPedido(tblPedido nuevoPedido)
        {
            try
            {
                // Añadimos el nuevo pedido a la base de datos
                oEFR.tblPedidoes.Add(nuevoPedido);
                oEFR.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // En caso de error, lanzamos una excepción
                throw new Exception("Error al crear el pedido: " + ex.Message);
            }
        }
    }
}