using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PalacioVerduras.API.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _context;
        private static List<Empleado> _empleados = new List<Empleado>();

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
            if (_empleados.Count == 0)
            {
                _empleados.Add(new Empleado(1, "Carlos", "López", "carlos@example.com", "Gerente"));
                _empleados.Add(new Empleado(2, "Ana", "Rodríguez", "ana@example.com", "Vendedor"));
            }
        }

        public async Task<IEnumerable<Empleado>> GetAllEmpleadosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<Empleado> CreateEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task UpdateEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}