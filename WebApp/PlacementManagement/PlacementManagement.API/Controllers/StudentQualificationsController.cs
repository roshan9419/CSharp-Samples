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
    public class StudentQualificationsController : ApiController
    {
        private readonly IStudentRepository<StudentQualification> _stdQualRepo;
        public StudentQualificationsController(IStudentRepository<StudentQualification> stdQualRepo)
        {
            _stdQualRepo = stdQualRepo;
        }

        // GET: api/StudentQualifications/5
        public IEnumerable<StudentQualification> Get(int studentId)
        {
            return _stdQualRepo.GetAll(studentId);
        }

        // POST: api/StudentQualifications
        public void Post([FromBody]StudentQualification value)
        {
            _stdQualRepo.Create(value);
        }

        // PUT: api/StudentQualifications/5
        public void Put(int studentId, int qualificationTypeId, [FromBody]StudentQualification value)
        {
            _stdQualRepo.Update(value);
        }

        // DELETE: api/StudentQualifications/5
        public void Delete(int studentId, int qualificationTypeId)
        {
            _stdQualRepo.Delete(studentId, qualificationTypeId);
        }
    }
}
