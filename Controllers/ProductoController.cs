using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using CatalogApi.Models;
using CatalogApi.Services;
using System.Collections.Generic;

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        public ProductoController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        // Obtener todos los productos
        [HttpGet]
        public ActionResult<List<Producto>> GetAllProductos()
        {
            var productos = _productoService.GetAllProductos();
            return Ok(productos);
        }

        // Obtener un producto por ID
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProductoById(string id)
        {
            try
            {
                var productoObjectId = new ObjectId(id);
                var producto = _productoService.GetProductoById(productoObjectId);
                if (producto == null)
                    return NotFound("Producto no encontrado.");
                return Ok(producto);
            }
            catch
            {
                return BadRequest("ID de producto inválido.");
            }
        }

        // Obtener productos por categoría
        [HttpGet("categoria/{categoriaId}")]
        public ActionResult<List<Producto>> GetProductosPorCategoria(string categoriaId)
        {
            try
            {
                var categoriaObjectId = new ObjectId(categoriaId);
                var productos = _productoService.GetProductosPorCategoria(categoriaObjectId);
                return Ok(productos);
            }
            catch
            {
                return BadRequest("ID de categoría inválido.");
            }
        }

        // Crear un producto
        [HttpPost]
        public ActionResult<Producto> CreateProducto([FromBody] Producto producto)
        {
            var createdProducto = _productoService.CreateProducto(producto);
            return CreatedAtAction(nameof(GetProductoById), new { id = createdProducto.Id.ToString() }, createdProducto);
        }

        // Actualizar un producto
        [HttpPut("{id}")]
        public ActionResult<Producto> UpdateProducto(string id, [FromBody] Producto producto)
        {
            try
            {
                var productoObjectId = new ObjectId(id);
                var updatedProducto = _productoService.UpdateProducto(productoObjectId, producto);
                return Ok(updatedProducto);
            }
            catch
            {
                return BadRequest("ID de producto inválido.");
            }
        }

        // Eliminar un producto
        [HttpDelete("{id}")]
        public ActionResult DeleteProducto(string id)
        {
            try
            {
                var productoObjectId = new ObjectId(id);
                _productoService.DeleteProducto(productoObjectId);
                return NoContent();
            }
            catch
            {
                return BadRequest("ID de producto inválido.");
            }
        }
    }
}
