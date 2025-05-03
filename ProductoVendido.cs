using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_de_las_verduras
{
	public class ProductoVendido
	{
		public Producto Producto { get; set; }
		public int Cantidad { get; set; }

		public ProductoVendido(Producto producto, int cantidad)
		{
			Producto = producto;
			Cantidad = cantidad;
		}
	}
}
