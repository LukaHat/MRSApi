using Test_API.Models;

namespace Test_API.Repository.IRepository
{
    public interface IRazmjenaRepository : IRepository<Razmjena>
    {
        Task<Razmjena> UpdateAsync(Razmjena entity);
    }
}
