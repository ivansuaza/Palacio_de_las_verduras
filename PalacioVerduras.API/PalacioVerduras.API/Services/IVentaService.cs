using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Services
{
    public interface IVentaService
    {
        Task<IEnumerable<Venta>> GetAllVentasAsync();
        Task<Venta> GetVentaByIdAsync(int id);
        Task<Venta> CreateVentaAsync(Venta venta);
        Task UpdateVentaAsync(Venta venta); //  Las ventas generalmente no se actualizan
        Task DeleteVentaAsync(int id);  //  Las ventas generalmente no se eliminan
    }
}