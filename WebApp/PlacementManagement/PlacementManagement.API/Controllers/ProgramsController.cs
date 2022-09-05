using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System.Collections.Generic;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class ProgramsController : ApiController
    {
        private readonly IRepository<Program> _programsRepo;

        public ProgramsController(IRepository<Program> programsRepo)
        {
            _programsRepo = programsRepo;
        }

        // GET: api/Programs
        public IEnumerable<Program> Get([FromUri] Pagination pagination)
        {
            return _programsRepo.GetAll(pagination);
        }

        // GET: api/Programs/5
        public Program Get(int id)
        {
            return _programsRepo.Get(id);
        }

        // POST: api/Programs
        public int Post([FromBody] Program value)
        {
            return _programsRepo.Create(value);
        }

        // PUT: api/Programs/5
        public void Put(int id, [FromBody] Program value)
        {
            _programsRepo.Update(value);
        }

        // DELETE: api/Programs/5
        public void Delete(int id)
        {
            _programsRepo.Delete(id);
        }
    }
}
