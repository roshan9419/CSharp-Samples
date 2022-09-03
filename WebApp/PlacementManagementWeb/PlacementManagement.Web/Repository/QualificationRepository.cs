using PlacementManagement.Models;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class QualificationRepository : IManageRepository<QualificationType>
    {
        private readonly APIService _service;
        public QualificationRepository(APIService service)
        {
            _service = service;
        }

        public async Task Create(QualificationType qualType)
        {
            await _service.Create("qualificationTypes", qualType);
        }

        public async Task Update(int id, QualificationType qualType)
        {
            await _service.Update($"qualificationTypes/{id}", qualType);
        }

        public async Task Delete(int id)
        {
            await _service.Delete($"qualificationTypes/{id}");
        }

        public async Task<QualificationType> Get(int id)
        {
            return await _service.Get<QualificationType>($"qualificationTypes/{id}");
        }

        public async Task<List<QualificationType>> GetAll()
        {
            return await _service.GetMany<QualificationType>("qualificationTypes");
        }
    }
}