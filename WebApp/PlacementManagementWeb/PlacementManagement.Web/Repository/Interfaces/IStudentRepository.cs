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
        /// <summary>
        /// This will create a new student
        /// </summary>
        /// <returns>Returns the StudentId</returns>
        Task<int> CreateStudent(Student student);

        /// <summary>
        /// This will update the student details
        /// </summary>
        Task UpdateStudent(int studentId, Student student);
        
        /// <summary>
        /// This will delete the student and all it's academic data
        /// </summary>
        Task DeleteStudent(int studentId);

        /// <summary>
        /// This will get the student details of studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Returns Student object</returns>
        Task<Student> GetStudent(int studentId);

        /// <summary>
        /// This will get the student details by userId of that student
        /// </summary>
        /// <param name="userId">UserId of student</param>
        /// <returns>Returns Student object</returns>
        Task<Student> GetStudentByUserId(string userId);

        /// <summary>
        /// This will list all the students with paginated result
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="limit">Page size</param>
        /// <returns>Returns list of Students</returns>
        Task<List<Student>> GetAllStudents(int page, int limit);

        /// <summary>
        /// This will list all the students matching the filter with paginated result
        /// </summary>
        /// <param name="filter">Applied filters</param>
        /// <returns>Returns list of Students</returns>
        Task<List<Student>> GetFilteredStudents(StudentFilter filter);
    }
}
