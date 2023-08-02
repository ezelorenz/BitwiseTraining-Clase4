using DAL.DataContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementaciones
{
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        private readonly ApplicationDbContext _context;
        public LibroRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Libro> ObtenerPorIdConRelacion(int id)
        {
            var query = await _context.Libros
                            .Include(l => l.Comentarios)
                            .Include(a => a.Autor)
                            .Include(g => g.Genero)
                            .FirstOrDefaultAsync(l => l.Id == id);
            
            return query;
        }
    }
}
