using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class StudentSkillsController : ApiController
    {
        private readonly IStudentRepository<StudentSkill> _stdSkillRepo;
        public StudentSkillsController(IStudentRepository<StudentSkill> stdSkillRepo)
        {
            _stdSkillRepo = stdSkillRepo;
        }

        // GET: api/StudentSkills/5
        public IEnumerable<StudentSkill> Get(int studentId)
        {
            return _stdSkillRepo.GetAll(studentId);
        }

        // POST: api/StudentSkills
        public void Post([FromBody]StudentSkill value)
        {
            _stdSkillRepo.Create(value);
        }

        // PUT: api/StudentSkills/5
        public void Put(int studentId, int programId, [FromBody]StudentSkill value)
        {
            _stdSkillRepo.Update(value);
        }

        // DELETE: api/StudentSkills/5
        public void Delete(int studentId, int skillId)
        {
            _stdSkillRepo.Delete(studentId, skillId);
        }
    }
}
