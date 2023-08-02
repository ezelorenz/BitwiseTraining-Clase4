using Newtonsoft.Json;

namespace Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        [JsonIgnore]
        public HashSet<Libro> Libros { get; set; } = new HashSet<Libro>();
    }
}
