namespace Studentska_razmjena_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBAG { get; set; }
        public ICollection<Razmjena>? Razmjene { get; set; }
    }
}
