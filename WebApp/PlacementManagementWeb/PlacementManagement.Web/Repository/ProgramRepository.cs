using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class ProgramRepository : IManageRepository<Program>
    {
        private readonly APIService _service;
        public ProgramRepository(APIService service)
        {
            _service = service;
        }

        public async Task Create(Program program)
        {
            await _service.Create("programs", program);
        }

        public async Task Update(int id, Program program)
        {
            await _service.Update($"programs/{id}", program);
        }

        public async Task Delete(int id)
        {
            await _service.Delete($"programs/{id}");
        }

        public async Task<Program> Get(int id)
        {
            return await _service.Get<Program>($"programs/{id}");
        }

        public async Task<List<Program>> GetAll()
        {
            return await _service.GetMany<Program>("programs");
        }
    }
}