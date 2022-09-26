using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class QualificationTypesController : ApiController
    {
        private static readonly ILog _logger = LogHelper.GetLogger();
        private readonly IRepository<QualificationType> _qualTypeRepo;

        public QualificationTypesController(IRepository<QualificationType> qualTypeRepo)
        {
            _qualTypeRepo = qualTypeRepo;
        }

        // GET: api/QualificationTypes
        /// <summary>
        /// This will list all qualification types
        /// </summary>
        /// <param name="pagination">Pagination object containing Page, Limit values</param>
        /// <returns>Returns list of QualificationTypes</returns>
        /// <exception cref="HttpResponseException"></exception>
        public IEnumerable<QualificationType> Get([FromUri] Pagination pagination)
        {
            try
            {
                return _qualTypeRepo.GetAll(pagination);
            }
            catch (Exception ex)
            {
                string message = "Failed to get qualifications";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // GET: api/QualificationTypes/5
        /// <summary>
        /// This will provide QualificationType details for id
        /// </summary>
        /// <param name="id">Id of QualificationTypeId</param>
        /// <returns>Returns the QualificationType</returns>
        /// <exception cref="HttpResponseException"></exception>
        public QualificationType Get(int id)
        {
            QualificationType item = _qualTypeRepo.Get(id);
            if (item == null)
            {
                string message = $"QualificationType not found for id: {id}";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.NotFound, message));
            }
            return item;
        }

        // POST: api/QualificationTypes
        /// <summary>
        /// This will create new QualificationType
        /// </summary>
        /// <returns>Returns the newly created id</returns>
        /// <param name="value">QualificationType model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public int Post([FromBody] QualificationType value)
        {
            string message = "Creating qualificationType: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of qualificationType";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                return _qualTypeRepo.Create(value);
            }
            catch (Exception ex)
            {
                message = "Failed to create qualificationType";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }

        }

        // PUT: api/QualificationTypes/5
        /// <summary>
        /// This will update the QualificationType for id
        /// </summary>
        /// <param name="id">Id of qualificationTypeId to be updated</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int id, [FromBody] QualificationType value)
        {
            string message = "Updating qualificationType: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            try
            {
                if (value == null || !ModelState.IsValid)
                {
                    message = "Bad payload of qualificationType";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
                }

                QualificationType item = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _qualTypeRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
            }
            catch (Exception ex)
            {
                message = $"Failed to update qualificationType: {id}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }

        }

        // DELETE: api/QualificationTypes/5
        /// <summary>
        /// This will delete the QualificationType of id
        /// </summary>
        /// <param name="id">Id of qualificationTypeId to be deleted</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Delete(int id)
        {
            try
            {
                QualificationType item = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _qualTypeRepo.Delete(id);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                string message = $"Failed to delete qualificationType: {id}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }
    }
}
