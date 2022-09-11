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
    public class ProgramRepository : IManageRepository<Program>
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public ProgramRepository(APIService service)
        {
            _service = service;
        }

        public async Task Create(Program program)
        {
            _logger.Debug("Creating new program: " + JsonConvert.SerializeObject(program));
            
            try
            {
                await _service.Create("programs", program);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create Program";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "Program contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate program entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Update(int id, Program program)
        {
            _logger.Debug("Updating program: " + JsonConvert.SerializeObject(program));

            try
            {
                await _service.Update($"programs/{id}", program);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update Program";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "Program contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "Program not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Delete(int id)
        {
            _logger.Debug($"Deleting program: {id}");

            try
            {
                await _service.Delete($"programs/{id}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to delete Program";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "Program not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<Program> Get(int id)
        {
            _logger.Debug($"Getting program: {id}");

            try
            {
                return await _service.Get<Program>($"programs/{id}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Program";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "Program not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<Program>> GetAll()
        {
            _logger.Debug("Getting all programs");

            try
            {
                return await _service.GetMany<Program>("programs");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Programs";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}