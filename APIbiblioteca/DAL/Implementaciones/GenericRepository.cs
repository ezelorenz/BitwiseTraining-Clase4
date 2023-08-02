using DAL.DataContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementaciones
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Actualizar(TEntity modelo)
        {
            _context.Set<TEntity>().Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entidad = await Obtener(id);
            if (entidad == null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(TEntity modelo)
        {
            _context.Set<TEntity>().AddAsync(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> Obtener(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodos()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
