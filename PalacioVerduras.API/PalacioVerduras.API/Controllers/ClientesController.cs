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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            var clientesDto = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            return Ok(clienteDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> CreateCliente(ClienteDTO clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _clienteService.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdUsuario }, _mapper.Map<ClienteDTO>(cliente));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, ClienteDTO clienteDto)
        {
            if (id != clienteDto.IdUsuario)
            {
                return BadRequest();
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _clienteService.UpdateClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}