using System;

public class Producto
{
	public int Codigo { get; set; }
	public string Nombre { get; set; }
	public int Precio { get; set; }
	public float Iva { get; set; }

	public Producto(int codigo, string nombre, int precio, float iva)
	{
		Codigo = codigo;
		Nombre = nombre;
		Precio = precio;
		Iva = iva;
	}
    public void MostrarInformacion()
    {
		Console.WriteLine($"Codigo del producto: {Codigo}, Nombre producto: {Nombre}," +
			$"Precio: {Precio},Impuesto : {Iva}");

    }
}
