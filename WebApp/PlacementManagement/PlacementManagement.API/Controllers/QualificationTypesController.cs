using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System.Collections.Generic;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class QualificationTypesController : ApiController
    {
        private readonly IRepository<QualificationType> _qualTypeRepo;

        public QualificationTypesController(IRepository<QualificationType> qualTypeRepo)
        {
            _qualTypeRepo = qualTypeRepo;
        }

        // GET: api/QualificationTypes
        public IEnumerable<QualificationType> Get([FromUri] Pagination pagination)
        {
            return _qualTypeRepo.GetAll(pagination);
        }

        // GET: api/QualificationTypes/5
        public QualificationType Get(int id)
        {
            return _qualTypeRepo.Get(id);
        }

        // POST: api/QualificationTypes
        public int Post([FromBody] QualificationType value)
        {
            return _qualTypeRepo.Create(value);
        }

        // PUT: api/QualificationTypes/5
        public void Put(int id, [FromBody] QualificationType value)
        {
            _qualTypeRepo.Update(value);
        }

        // DELETE: api/QualificationTypes/5
        public void Delete(int id)
        {
            _qualTypeRepo.Delete(id);
        }
    }
}
