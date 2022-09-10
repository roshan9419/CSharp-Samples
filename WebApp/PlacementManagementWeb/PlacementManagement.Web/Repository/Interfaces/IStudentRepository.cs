using PlacementManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository
{
    /// <summary>
    /// Student related operations
    /// </summary>
    public interface IStudentRepository
    {
        Task<int> CreateStudent(Student student);
        Task UpdateStudent(int studentId, Student student);
        Task DeleteStudent(int studentId);
        Task<Student> GetStudent(int studentId);
        Task<Student> GetStudentByUserId(string userId);
        Task<List<Student>> GetAllStudents(int page, int limit);
        Task<List<Student>> GetFilteredStudents(StudentFilter filter);
    }
}
