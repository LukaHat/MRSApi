using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> DohvatiStudente();
        Student DohvatiStudente(int id);
        Student DohvatiStudente(string Ime);
        bool StudentPostoji(int StudentId);
        bool StvoriStudenta(Student student);
        bool Spremi();
    }
}
