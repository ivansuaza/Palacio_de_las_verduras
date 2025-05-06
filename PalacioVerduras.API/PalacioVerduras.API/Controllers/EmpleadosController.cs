using Microsoft.AspNetCore.Mvc;
using PalacioVerduras.API.Models;
using PalacioVerduras.API.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadosController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            var empleadosDto = _mapper.Map<IEnumerable<EmpleadoDTO>>(empleados);
            return Ok(empleadosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            var empleadoDto = _mapper.Map<EmpleadoDTO>(empleado);
            return Ok(empleadoDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoDTO>> CreateEmpleado(EmpleadoDTO empleadoDto)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDto);
            await _empleadoService.CreateEmpleadoAsync(empleado);
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.IdUsuario }, _mapper.Map<EmpleadoDTO>(empleado));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, EmpleadoDTO empleadoDto)
        {
            if (id != empleadoDto.IdUsuario)
            {
                return BadRequest();
            }

            var empleado = _mapper.Map<Empleado>(empleadoDto);
            await _empleadoService.UpdateEmpleadoAsync(empleado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _empleadoService.DeleteEmpleadoAsync(id);
            return NoContent();
        }
    }
}