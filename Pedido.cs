using System;

public class Pedido
{
	public int NumeroPedido { get; set; }
	public int IDProducto { get; set; }
	public int Codigo_Cliente { get; set; }
	public int Codigo_Usuario { get; set; }


	public Pedido(int numeroPedido, int idProducto, int codigo_cliente, int codigo_usuario )
	{
		NumeroPedido = numeroPedido;
		IDProducto = idProducto;
		Codigo_Cliente = codigo_cliente;
		Codigo_Usuario = codigo_usuario;
	}
    public void MostrarInformacion()
    {
		Console.WriteLine($"Numero de pedido: {NumeroPedido}, Id del producto: {IDProducto}," +
			$"Codigo del cliente: {Codigo_Cliente}, Codigo del usuario: {Codigo_Usuario} ");

    }
}
