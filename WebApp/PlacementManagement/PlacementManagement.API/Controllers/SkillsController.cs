using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System.Collections.Generic;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class SkillsController : ApiController
    {
        private readonly IRepository<Skill> _skillsRepo;

        public SkillsController(IRepository<Skill> skillsRepo)
        {
            _skillsRepo = skillsRepo;
        }

        // GET: api/Skills
        public IEnumerable<Skill> Get()
        {
            return _skillsRepo.GetAll();
        }

        // GET: api/Skills/5
        public Skill Get(int id)
        {
            return _skillsRepo.Get(id);
        }

        // POST: api/Skills
        public int Post([FromBody] Skill value)
        {
            return _skillsRepo.Create(value);
        }

        // PUT: api/Skills/5
        public void Put(int id, [FromBody] Skill value)
        {
            _skillsRepo.Update(value);
        }

        // DELETE: api/Skills/5
        public void Delete(int id)
        {
            _skillsRepo.Delete(id);
        }
    }
}
