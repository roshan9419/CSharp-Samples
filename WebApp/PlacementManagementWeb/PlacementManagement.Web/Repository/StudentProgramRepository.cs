using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class StudentProgramRepository : ProgramRepository, IStudentAcademicRepository<StudentProgram, Program>
    {
        private readonly APIService _service;

        public StudentProgramRepository(APIService service) : base(service)
        {
            _service = service;
        }

        public async Task Add(StudentProgram program)
        {
            await _service.Create("studentprograms", program);
        }

        public async Task Update(StudentProgram program)
        {
            await _service.Update($"studentprograms?studentId={program.StudentId}&programId={program.ProgramId}", program);
        }

        public async Task Remove(int studentId, int programId)
        {
            await _service.Delete($"studentprograms?studentId={studentId}&programId={programId}");
        }

        public async Task<List<StudentProgram>> GetAll(int studentId)
        {
            return await _service.GetMany<StudentProgram>($"studentprograms?studentId={studentId}");
        }
    }
}