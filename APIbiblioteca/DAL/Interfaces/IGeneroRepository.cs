using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGeneroRepository : IGenericRepository<Genero>
    {
        public Task <IEnumerable<Genero>> ObtenerConLibros();
    }
}
