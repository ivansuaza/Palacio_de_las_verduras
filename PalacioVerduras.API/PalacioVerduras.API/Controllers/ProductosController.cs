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
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductosController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var productos = await _productoService.GetAllProductosAsync();
            var productosDto = _mapper.Map<IEnumerable<ProductoDTO>>(productos);
            return Ok(productosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            var productoDto = _mapper.Map<ProductoDTO>(producto);
            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> CreateProducto(ProductoDTO productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            await _productoService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.IdProducto }, _mapper.Map<ProductoDTO>(producto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO productoDto)
        {
            if (id != productoDto.IdProducto)
            {
                return BadRequest();
            }

            var producto = _mapper.Map<Producto>(productoDto);
            await _productoService.UpdateProductoAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productoService.DeleteProductoAsync(id);
            return NoContent();
        }
    }
}