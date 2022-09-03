using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class StudentQualificationRepository : 
        QualificationRepository, IStudentAcademicRepository<StudentQualification, QualificationType>
    {
        private readonly APIService _service;

        public StudentQualificationRepository(APIService service) : base(service)
        {
            _service = service;
        }

        public async Task Add(StudentQualification qualification)
        {
            await _service.Create("studentqualifications", qualification);
        }

        public async Task Update(StudentQualification qualification)
        {
            await _service.Update($"studentqualifications?studentId={qualification.StudentId}&qualificationTypeId={qualification.QualificationTypeId}", qualification);
        }

        public async Task Remove(int studentId, int qualificationTypeId)
        {
            await _service.Delete($"studentqualifications?studentId={studentId}&qualificationTypeId={qualificationTypeId}");
        }

        public async Task<List<StudentQualification>> GetAll(int studentId)
        {
            return await _service.GetMany<StudentQualification>($"studentqualifications?studentId={studentId}");
        }
    }
}