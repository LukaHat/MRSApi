namespace Studentska_razmjena_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBAG { get; set; }
        public ICollection<Razmjena>? Razmjene { get; set; }
        public Student()
        {
            Razmjene = new List<Razmjena>(); // Initialize the property with an empty list
        }
    }
}
