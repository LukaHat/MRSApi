namespace Studentska_razmjena_API.Models
{
    public class Razmjena
    {
        public int Id { get; set; }
        public string? Drzava { get; set; }
        public string?  Sveuciliste { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public Student? Student { get; set; }
    }
}
  