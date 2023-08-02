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
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        private readonly ApplicationDbContext _context;
        public GeneroRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Genero>> ObtenerConLibros()
        {
            return await _context.Generos.Include(l => l.Libros).ToListAsync();
        }
    }
}
