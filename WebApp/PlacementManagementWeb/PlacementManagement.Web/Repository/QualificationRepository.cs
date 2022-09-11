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
    public class QualificationRepository : IManageRepository<QualificationType>
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public QualificationRepository(APIService service)
        {
            _service = service;
        }

        public async Task Create(QualificationType qualType)
        {
            _logger.Debug("Creating new QualificationType: " + JsonConvert.SerializeObject(qualType));

            try
            {
                await _service.Create("qualificationTypes", qualType);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create QualificationType";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "QualificationType contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate qualificationType entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Update(int id, QualificationType qualType)
        {
            _logger.Debug("Updating QualificationType: " + JsonConvert.SerializeObject(qualType));
            
            try
            {
                await _service.Update($"qualificationTypes/{id}", qualType);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update QualificationType";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "QualificationType contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "QualificationType not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Delete(int id)
        {
            _logger.Debug($"Deleting qualificationType: {id}");

            try
            {
                await _service.Delete($"qualificationTypes/{id}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to delete QualificationType";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "QualificationType not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<QualificationType> Get(int id)
        {
            _logger.Debug($"Getting qualificationType: {id}");
            
            try
            {
                return await _service.Get<QualificationType>($"qualificationTypes/{id}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get QualificationType";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "QualificationType not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<QualificationType>> GetAll()
        {
            _logger.Debug("Getting all qualificationTypes");

            try
            {
                return await _service.GetMany<QualificationType>("qualificationTypes");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get QualificationTypes";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}