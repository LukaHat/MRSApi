using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Interfaces
{
    public interface IRazmjenaRepository
    {
        ICollection<Razmjena> DohvatiRazmjene();
        Razmjena DohvatiRazmjenu(int id);
        
        bool RazmjenaPostoji(int id);
    }
}
