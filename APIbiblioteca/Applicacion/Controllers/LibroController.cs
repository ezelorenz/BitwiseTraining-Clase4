using DAL.Implementaciones;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Applicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IGenericRepository<Libro> _libroRepository;
        public LibroController(IGenericRepository<Libro> libroRepository)
        {
            _libroRepository = libroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var libros = await _libroRepository.ObtenerTodos();
            return Ok(libros.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var libro = await _libroRepository.Obtener(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                await _libroRepository.Insertar(libro);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var resultado = await _libroRepository.Actualizar(libro);
                if (resultado)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _libroRepository.Eliminar(id);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
