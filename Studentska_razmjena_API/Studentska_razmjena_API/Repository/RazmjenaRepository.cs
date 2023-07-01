using Studentska_razmjena_API.Data;
using Studentska_razmjena_API.Interfaces;
using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Repository
{
    public class RazmjenaRepository : IRazmjenaRepository
    {
        private DataContext _context;
        public RazmjenaRepository(DataContext context)
        {
            _context = context;
        }
        public bool RazmjenaPostoji(int id)
        {
            return _context.Razmjene.Any(r => r.Id == id);
        }

        public ICollection<Razmjena> DohvatiRazmjene()
        {
            return _context.Razmjene.ToList();
        }

        public Razmjena DohvatiRazmjenu(int id)
        {
            return _context.Razmjene.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
