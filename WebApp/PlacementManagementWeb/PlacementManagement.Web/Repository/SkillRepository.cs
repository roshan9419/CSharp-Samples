using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class SkillRepository : IManageRepository<Skill>
    {
        private readonly APIService _service;
        public SkillRepository(APIService service)
        {
            _service = service;
        }

        public async Task Create(Skill skill)
        {
            await _service.Create("skills", skill);
        }

        public async Task Update(int id, Skill skill)
        {
            await _service.Update($"skills/{id}", skill);
        }

        public async Task Delete(int id)
        {
            await _service.Delete($"skills/{id}");
        }

        public async Task<Skill> Get(int id)
        {
            return await _service.Get<Skill>($"skills/{id}");
        }

        public async Task<List<Skill>> GetAll()
        {
            return await _service.GetMany<Skill>("skills");
        }
    }
}