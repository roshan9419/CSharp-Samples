using PlacementManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository
{
    public interface IStudentRepository
    {
        Task<int> CreateStudent(Student student);
        Task UpdateStudent(int studentId, Student student);
        Task DeleteStudent(int studentId);
        Task<Student> GetStudent(int studentId);
        Task<List<Student>> GetAllStudents();
    }
}
