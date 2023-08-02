using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Genero
    {
     
        public int Id { get; set; }
        
        public string Nombre { get; set; } = null!;
        [JsonIgnore]

        public HashSet<Libro> Libros { get; set; } = new HashSet<Libro>();
    }
}
