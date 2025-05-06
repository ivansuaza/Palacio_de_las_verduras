using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PalacioVerduras.API.Data;  //  Asegúrate de que este namespace sea correcto

namespace PalacioVerduras.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;
        //private static List<Cliente> _clientes = new List<Cliente>();  //  No uses una lista estática en un servicio

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
            //if (_clientes.Count == 0)  //  No inicialices datos aquí
            //{
            //    _clientes.Add(new Cliente(1, "Juan", "Pérez", "juan@example.com"));
            //    _clientes.Add(new Cliente(2, "María", "Gómez", "maria@example.com"));
            //}
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}