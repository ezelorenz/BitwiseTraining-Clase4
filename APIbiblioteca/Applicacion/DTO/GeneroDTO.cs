using Models;

namespace Applicacion.DTO
{
    public class GeneroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public HashSet<LibroDTO> Libros { get; set; } = new HashSet<LibroDTO>();
    }
}
