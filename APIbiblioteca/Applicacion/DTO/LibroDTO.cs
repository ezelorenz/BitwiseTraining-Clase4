using Models;

namespace Applicacion.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool ParaPrestar { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string? NombreAutor { get; set; }
        public string? NombreGenero { get; set; }
        public HashSet<ComentarioDTO> Comentarios { get; set; } = new HashSet<ComentarioDTO>();
    }
}
