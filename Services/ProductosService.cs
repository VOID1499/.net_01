using Microsoft.EntityFrameworkCore;
using Proyecto_01.DTOs;
using Proyecto_01.Models;


namespace Proyecto_01.Services
{
    public class ProductosService : ICommonService<ProductoDto,ProductoInsertDto,ProductoUpdateDto>
    {
        private StoreContext _storeContext;
        public ProductosService(StoreContext storeContext) { 
        
            _storeContext = storeContext;
        }

        public async Task<ProductoDto> Add(ProductoInsertDto productoInsertDto)
        {
            var producto = new Producto()
            {
                Nombre = productoInsertDto.Nombre,
                Descripcion = productoInsertDto.Descripcion,
                CreatedAt = DateTime.Now,
                IdCategoria = productoInsertDto.IdCategoria,

            };

            await _storeContext.Productos.AddAsync(producto);
            await _storeContext.SaveChangesAsync();

            var productoDto = new ProductoDto()
            {
                Id = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                CreatedAt = producto.CreatedAt,
                IdCagtegoria = producto.IdCategoria
            };

            return productoDto;

        }

        
        public async Task<ProductoDto> Delete(uint id)
        {
            var producto = await _storeContext.Productos.FindAsync(id);
            
            if(producto != null)
            {
                var productoDto = new ProductoDto()
                {
                    Id = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    CreatedAt = producto.CreatedAt,
                    IdCagtegoria = producto.IdCategoria
                };

                _storeContext.Productos.Remove(producto);
                await _storeContext.SaveChangesAsync();

                return productoDto;
            }

            return null;
        }

        public async Task<IEnumerable<ProductoDto>> GetAll(int pageNumber, int pageSize)
        {
            var productos = await _storeContext.Productos.Include(p => p.Categoria).

                OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)

                .Select(p => new ProductoDto
                {
                    Id = p.IdProducto,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    CreatedAt = p.CreatedAt,
                    UpdateAt = p.UpdateAt,
                    Categoria = p.Categoria.Nombre,
                    IdCagtegoria = p.IdCategoria,

                }).ToListAsync();

            return productos;
        }


        public async Task<ProductoDto> GetById(uint id)
        {
            var producto = await _storeContext.Productos.FindAsync(id);

            if(producto != null)
            {
                var productoDto = new ProductoDto()
                {
                    Id = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    IdCagtegoria = producto.IdCategoria,
                    CreatedAt = producto.CreatedAt,
                    UpdateAt = producto.UpdateAt
                };
                return productoDto;
            }

            return null;
        }



        public async Task<ProductoDto> Update(uint id, ProductoUpdateDto productoUpdateDto)
        {
            var producto = await _storeContext.Productos.FindAsync(id);

           
            if(producto != null)
            {

                producto.Nombre = productoUpdateDto.Nombre;
                producto.Descripcion = productoUpdateDto.Descripcion;
                producto.IdCategoria = productoUpdateDto.IdCategoria;
                producto.UpdateAt = DateTime.Now;
                await _storeContext.SaveChangesAsync();

                var productoDto = new ProductoDto()
                {
                    Id = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    IdCagtegoria = producto.IdCategoria,
                    CreatedAt = producto.CreatedAt,
                    UpdateAt = producto.UpdateAt
                };

                return(productoDto);
            }

            return null;

        }
    }
}
