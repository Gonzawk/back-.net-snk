using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using CatalogApi.Models;
using CatalogApi.Services;
using System.Collections.Generic;

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // Obtener todas las categorías
        [HttpGet]
        public ActionResult<List<Categoria>> GetAllCategorias()
        {
            var categorias = _categoriaService.GetAllCategorias();
            return Ok(categorias);
        }

        // Obtener una categoría por ID
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetCategoriaById(string id)
        {
            try
            {
                var categoriaObjectId = new ObjectId(id);
                var categoria = _categoriaService.GetCategoriaById(categoriaObjectId);
                if (categoria == null)
                    return NotFound("Categoría no encontrada.");
                return Ok(categoria);
            }
            catch
            {
                return BadRequest("ID de categoría inválido.");
            }
        }

        // Crear una nueva categoría
        [HttpPost]
        public ActionResult<Categoria> CreateCategoria([FromBody] Categoria categoria)
        {
            var createdCategoria = _categoriaService.CreateCategoria(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = createdCategoria.Id.ToString() }, createdCategoria);
        }

        // Actualizar una categoría
        [HttpPut("{id}")]
        public ActionResult<Categoria> UpdateCategoria(string id, [FromBody] Categoria categoria)
        {
            try
            {
                var categoriaObjectId = new ObjectId(id);
                var updatedCategoria = _categoriaService.UpdateCategoria(categoriaObjectId, categoria);
                return Ok(updatedCategoria);
            }
            catch
            {
                return BadRequest("ID de categoría inválido.");
            }
        }

        // Eliminar una categoría
        [HttpDelete("{id}")]
        public ActionResult DeleteCategoria(string id)
        {
            try
            {
                var categoriaObjectId = new ObjectId(id);
                _categoriaService.DeleteCategoria(categoriaObjectId);
                return NoContent();
            }
            catch
            {
                return BadRequest("ID de categoría inválido.");
            }
        }
    }
}
