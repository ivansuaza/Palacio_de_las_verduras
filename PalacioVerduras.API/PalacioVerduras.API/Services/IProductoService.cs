using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync();
        Task<Producto> GetProductoByIdAsync(int id);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
    }
}