using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Dto
{
    public class RazmjenaDto
    {
        public int Id { get; set; }
        public string? Drzava { get; set; }
        public string? Sveuciliste { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public Student? Student { get; set; }
    }
}
