using Applicacion.DTO;
using AutoMapper;
using DAL.Implementaciones;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Applicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _genericRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public GeneroController(IGenericRepository<Genero> genericRepository, IMapper mapper, IGeneroRepository generoRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _generoRepository = generoRepository;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroDTO>> Obtener(int id)
        {
            var genero = await _genericRepository.Obtener(id);
            if (genero == null)
            {
                return NotFound();
            }

            var generoDTO = _mapper.Map<GeneroDTO>(genero);
            return Ok(generoDTO);
        }

        [HttpGet("conlibros")]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> GeneroConLibros()
        {
            var generos = await _generoRepository.ObtenerConLibros();
            var generosDto = _mapper.Map<IEnumerable<GeneroDTO>>(generos);
            return Ok(generosDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> ObtenerTodos()
        {
            var generos = await _genericRepository.ObtenerTodos();
            var generosDTO = _mapper.Map<IEnumerable<GeneroDTO>>(generos);
            return Ok(generosDTO);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroDTO>> Crear(GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            await _genericRepository.Insertar(genero);

            var generoDTO = _mapper.Map<GeneroDTO>(genero);
            return CreatedAtAction(nameof(Obtener), new { id = genero.Id }, generoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneroDTO>> Actualizar(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = await _genericRepository.Obtener(id);
            if (genero == null)
            {
                return NotFound();
            }

            _mapper.Map(generoCreacionDTO, genero);
            await _genericRepository.Actualizar(genero);

            var generoDTO = _mapper.Map<GeneroDTO>(genero);
            return Ok(generoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var genero = await _genericRepository.Obtener(id);
            if (genero == null)
            {
                return NotFound();
            }

            await _genericRepository.Eliminar(id);
            return NoContent();
        }
    }
}
