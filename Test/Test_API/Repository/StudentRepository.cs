using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test_API.Data;
using Test_API.Models;
using Test_API.Repository.IRepository;

namespace Test_API.Repository
{
    public class StudentRepository :Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            _db.Students.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
