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
    public class StudentProgramsController : ApiController
    {
        private readonly IStudentRepository<StudentProgram> _programRepo;
        public StudentProgramsController(IStudentRepository<StudentProgram> programRepo)
        {
            _programRepo = programRepo;
        }

        // GET: api/StudentPrograms/5
        public IEnumerable<StudentProgram> Get(int studentId)
        {
            return _programRepo.GetAll(studentId);
        }

        // POST: api/StudentPrograms
        public void Post([FromBody]StudentProgram value)
        {
            _programRepo.Create(value);
        }

        // PUT: api/StudentPrograms/5
        public void Put(int studentId, int programId, [FromBody]StudentProgram value)
        {
            _programRepo.Update(value);
        }

        // DELETE: api/StudentPrograms/5
        public void Delete(int studentId, int programId)
        {
            _programRepo.Delete(studentId, programId);
        }
    }
}
