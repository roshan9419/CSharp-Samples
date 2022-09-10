using log4net;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
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
        public IEnumerable<QualificationType> Get([FromUri] Pagination pagination)
        {
            try
            {
                return _qualTypeRepo.GetAll(pagination);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to get qualifications", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/QualificationTypes/5
        /// <summary>
        /// This will provide QualificationType details for id
        /// </summary>
        /// <returns>Returns the QualificationType</returns>
        public QualificationType Get(int id)
        {
            QualificationType item = _qualTypeRepo.Get(id);
            if (item == null)
            {
                _logger.Debug($"QualificationType not found for id: {id}");
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        // POST: api/QualificationTypes
        /// <summary>
        /// This will create new QualificationType
        /// </summary>
        /// <returns>Returns the newly created id</returns>
        public int Post([FromBody] QualificationType value)
        {
            _logger.Debug(value);

            if (!ModelState.IsValid)
            {
                _logger.Debug("Bad payload of qualificationType");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                return _qualTypeRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create qualificationType", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }

        // PUT: api/QualificationTypes/5
        /// <summary>
        /// This will update the QualificationType for id
        /// </summary>
        public void Put(int id, [FromBody] QualificationType value)
        {
            _logger.Debug(value); 
            
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.Debug("Bad payload of qualificationType");
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
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
                _logger.Error($"Failed to update qualificationType: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }

        // DELETE: api/QualificationTypes/5
        /// <summary>
        /// This will delete the QualificationType of id
        /// </summary>
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
                _logger.Error($"Failed to delete qualificationType: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
