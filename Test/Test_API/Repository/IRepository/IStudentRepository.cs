using System.Linq.Expressions;
using Test_API.Models;

namespace Test_API.Repository.IRepository
{
    public interface IStudentRepository:IRepository<Student>
    {
        Task<Student> UpdateAsync(Student entity);
    }
}
