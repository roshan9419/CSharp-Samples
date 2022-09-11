using log4net;
using Newtonsoft.Json;
using PlacementManagement.Models;
using PlacementManagement.Services;
using PlacementManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository
{
    public class SkillRepository : IManageRepository<Skill>
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public SkillRepository(APIService service)
        {
            _service = service;
        }

        public async Task Create(Skill skill)
        {
            _logger.Debug("Creating new Skill: " + JsonConvert.SerializeObject(skill));
            
            try
            {
                await _service.Create("skills", skill);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create Skill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "Skill contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate skill entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Update(int id, Skill skill)
        {
            _logger.Debug("Updating Skill: " + JsonConvert.SerializeObject(skill));
            
            try
            {
                await _service.Update($"skills/{id}", skill);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update Skill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "Skill contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "Skill not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Delete(int id)
        {
            _logger.Debug($"Deleting skill: {id}");

            try
            {
                await _service.Delete($"skills/{id}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to delete Skill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "Skill not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<Skill> Get(int id)
        {
            _logger.Debug($"Getting skill: {id}");
            
            try
            {
                return await _service.Get<Skill>($"skills/{id}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Skill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "Skill not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<Skill>> GetAll()
        {
            _logger.Debug("Getting all skills");

            try
            {
                return await _service.GetMany<Skill>("skills");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Skills";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}