using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly APIService _service;

        public StudentRepository(APIService service)
        {
            _service = service;
        }

        public async Task<int> CreateStudent(Student student)
        {
            var studentId = await _service.Create("students", student);
            return Convert.ToInt32(studentId);
        }

        public async Task UpdateStudent(int studentId, Student student)
        {
            await _service.Update($"students/{studentId}", student);
        }

        public async Task DeleteStudent(int studentId)
        {
            await _service.Delete($"students/{studentId}");
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await _service.Get<Student>($"students/{studentId}");
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _service.GetMany<Student>("students");
        }
    }
}