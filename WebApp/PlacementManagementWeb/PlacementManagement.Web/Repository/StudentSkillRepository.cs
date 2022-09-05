using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class StudentSkillRepository : 
        SkillRepository, IStudentAcademicRepository<StudentSkill, Skill>
    {
        private readonly APIService _service;

        public StudentSkillRepository(APIService service) : base(service)
        {
            _service = service;
        }

        public async Task Add(StudentSkill skill)
        {
            await _service.Create("studentskills", skill);
        }

        public async Task Update(StudentSkill skill)
        {
            await _service.Update($"studentskills?studentId={skill.StudentId}&skillId={skill.SkillId}", skill);
        }

        public async Task Remove(int studentId, int skillId)
        {
            await _service.Delete($"studentskills?studentId={studentId}&skillId={skillId}");
        }

        public async Task<List<StudentSkill>> GetAll(int studentId)
        {
            return await _service.GetMany<StudentSkill>($"studentskills?studentId={studentId}");
        }
    }
}