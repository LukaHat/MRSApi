using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBAG { get; set; }
        public ICollection<Razmjena>? Razmjene { get; set; }
    }
}
