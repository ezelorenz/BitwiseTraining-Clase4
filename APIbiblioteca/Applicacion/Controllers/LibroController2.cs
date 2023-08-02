using Applicacion.DTO;
using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Applicacion.Controllers
{
    [Route("api/libro2")]
    [ApiController]
    public class LibroController2 : ControllerBase
    {
        private readonly IGenericRepository<Libro> _genericRepository;
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;
        public LibroController2(IGenericRepository<Libro> genericRepository, IMapper mapper,
                                ILibroRepository libroRepository)
        {
            _genericRepository = genericRepository;
            _libroRepository = libroRepository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDTO>> Obtener(int id)
        {
            var libro = await _genericRepository.Obtener(id);
            if (libro == null)
            {
                return NotFound();
            }

            var libroDTO = _mapper.Map<LibroDTO>(libro);
            return Ok(libroDTO);
        }
        [HttpGet("datarelacionada/{id}")]
        public async Task<ActionResult<LibroDTO>> ObtenerRelacionada(int id)
        {
            var libro = await _libroRepository.ObtenerPorIdConRelacion(id);
            if (libro == null)
            {
                return NotFound();
            }

            var libroDTO = _mapper.Map<LibroDTO>(libro);
            return Ok(libroDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> ObtenerTodos()
        {
            var libros = await _genericRepository.ObtenerTodos();
            var librosDTO = _mapper.Map<IEnumerable<LibroDTO>>(libros);
            return Ok(librosDTO);
        }

        [HttpPost]
        public async Task<ActionResult<LibroDTO>> Crear(LibroCreacionDTO libroCreacionDTO)
        {
            var libro = _mapper.Map<Libro>(libroCreacionDTO);
            await _genericRepository.Insertar(libro);

            var libroDTO = _mapper.Map<LibroDTO>(libro);
            return CreatedAtAction(nameof(Obtener), new { id = libro.Id }, libroDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LibroDTO>> Actualizar(int id, LibroCreacionDTO libroCreacionDTO)
        {
            var libro = await _genericRepository.Obtener(id);
            if (libro == null)
            {
                return NotFound();
            }

            _mapper.Map(libroCreacionDTO, libro);
            await _genericRepository.Actualizar(libro);

            var libroDTO = _mapper.Map<LibroDTO>(libro);
            return Ok(libroDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var libro = await _genericRepository.Obtener(id);
            if (libro == null)
            {
                return NotFound();
            }

            await _genericRepository.Eliminar(id);
            return NoContent();
        }
    }
}
