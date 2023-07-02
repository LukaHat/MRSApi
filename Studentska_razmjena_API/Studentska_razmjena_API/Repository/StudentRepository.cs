using Studentska_razmjena_API.Data;
using Studentska_razmjena_API.Interfaces;
using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Student> DohvatiStudente()
        {
            return _context.Studenti.OrderBy(s => s.Id).ToList();
        }

        public Student DohvatiStudente(int id)
        {
            return _context.Studenti.Where(s => s.Id == id).FirstOrDefault();
        }

        public Student DohvatiStudente(string ime)
        {
            return _context.Studenti.Where(s => s.Ime == ime).FirstOrDefault();
        }

        public bool Spremi()
        {
            var spremljeno = _context.SaveChanges();
            return spremljeno > 0 ? true : false;
        }

        public bool StudentPostoji(int StudentId)
        {
            return _context.Studenti.Any(s => s.Id == StudentId);
        }

        public Student StvoriStudenta(Student student)
        {
            _context.Add(student);
            var uspjeh = Spremi();

            if (uspjeh)
            {
                return student;
            }
            else
            {
                return null; // Or handle the failure case appropriately
            }
        }

        bool IStudentRepository.StvoriStudenta(Student student)
        {
            throw new NotImplementedException();
        }
    }
    }

