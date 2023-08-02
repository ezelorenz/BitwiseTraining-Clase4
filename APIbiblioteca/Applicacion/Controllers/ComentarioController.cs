using Applicacion.DTO;
using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Applicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IGenericRepository<Comentario> _genericRepository;
        private readonly IMapper _mapper;

        public ComentarioController(IGenericRepository<Comentario> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ComentarioDTO comentarioDTO)
        {
            var comentario = _mapper.Map<Comentario>(comentarioDTO);
            var respuesta = await _genericRepository.Insertar(comentario);

            if (!respuesta) {
                return BadRequest(respuesta);
            }
            var dto = _mapper.Map<ComentarioDTO>(comentario);
            return Ok(dto);
        }
    }
}
