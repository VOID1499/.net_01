using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_01.DTOs;
using Proyecto_01.Services;

namespace Proyecto_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private ICommonService<ProductoDto, ProductoInsertDto, ProductoUpdateDto> _productosService;
        private IValidator<ProductoInsertDto> _validator;

        public ProductosController(
            [FromKeyedServices("productosService")] ICommonService<ProductoDto, ProductoInsertDto, ProductoUpdateDto> productosService,
            IValidator<ProductoInsertDto> validator
            )
        {
            _productosService = productosService;
            _validator = validator;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(uint id) {

            var productoDto = await _productosService.GetById(id);
            return productoDto == null ? NotFound() : Ok(productoDto);
        }


        [HttpGet("{pageNumber}/{pageSize}")]

        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll(int pageNumber,int pageSize)
        {
            await Console.Out.WriteLineAsync(nameof(GetAll));


            var productos = await _productosService.GetAll(pageNumber,pageSize);

            return Ok(productos);
        }


        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Add(ProductoInsertDto productoInsertDto)
        {
            var validationResult = await _validator.ValidateAsync(productoInsertDto);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors); 

            var productoDto = await _productosService.Add(productoInsertDto);

            return Ok(productoDto);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoDto>> Delete(uint id)
        {
            var productoDto = await _productosService.Delete(id);
            return productoDto == null ? NotFound() : Ok(productoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoUpdateDto>> Update(uint id,ProductoUpdateDto productoUpdateDto) {
        
            var productoDto = await _productosService.Update(id, productoUpdateDto);
            return productoUpdateDto == null ? NotFound() : Ok( productoDto);
        }

    }
}
