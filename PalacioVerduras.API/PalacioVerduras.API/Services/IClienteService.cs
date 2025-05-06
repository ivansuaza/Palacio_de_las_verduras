using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> CreateClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}