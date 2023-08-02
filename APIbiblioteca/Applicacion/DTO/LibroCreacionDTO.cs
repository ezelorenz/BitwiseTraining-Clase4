namespace Applicacion.DTO
{
    public class LibroCreacionDTO
    {
        public string Titulo { get; set; } = null!;
        public string ParaPrestar { get; set; }
        public string FechaLanzamiento { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }
}
