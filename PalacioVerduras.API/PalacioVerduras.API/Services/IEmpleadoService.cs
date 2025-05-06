using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Services
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetAllEmpleadosAsync();
        Task<Empleado> GetEmpleadoByIdAsync(int id);
        Task<Empleado> CreateEmpleadoAsync(Empleado empleado);
        Task UpdateEmpleadoAsync(Empleado empleado);
        Task DeleteEmpleadoAsync(int id);
    }
}