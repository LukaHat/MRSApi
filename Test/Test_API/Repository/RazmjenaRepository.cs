using Test_API.Data;
using Test_API.Models;
using Test_API.Repository.IRepository;

namespace Test_API.Repository
{
    public class RazmjenaRepository : Repository<Razmjena>, IRazmjenaRepository
    {
        private readonly ApplicationDbContext _db;
        public RazmjenaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Razmjena> UpdateAsync(Razmjena entity)
        {
            _db.Razmjene.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
