using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class StudentQualificationsController : ApiController
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly IStudentRepository<StudentQualification> _stdQualRepo;
        
        public StudentQualificationsController(IStudentRepository<StudentQualification> stdQualRepo)
        {
            _stdQualRepo = stdQualRepo;
        }

        // GET: api/StudentQualifications/5
        /// <summary>
        /// This will list StudentQualifications of studentId
        /// </summary>
        /// <returns>Returns the list of StudentQualification</returns>
        public IEnumerable<StudentQualification> Get(int studentId)
        {
            try
            {
                return _stdQualRepo.GetAll(studentId);
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to get student qualifications for studentId: {studentId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/StudentQualifications
        /// <summary>
        /// This will create new StudentQualification of studentId
        /// </summary>
        public void Post([FromBody]StudentQualification value)
        {
            _logger.Debug("Creating studentQualification: " + JsonConvert.SerializeObject(value));

            if (!ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentQualification");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                _stdQualRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create StudentQualification", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/StudentQualifications/5
        /// <summary>
        /// This will update the existing qualification details of studentId and qualificationTypeId
        /// </summary>
        public void Put(int studentId, int qualificationTypeId, [FromBody]StudentQualification value)
        {
            _logger.Debug("Updating studentQualification: " + JsonConvert.SerializeObject(value));

            if (!ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentQualification");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                bool success = _stdQualRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to update studentQualification", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/StudentQualifications/5
        /// <summary>
        /// This will delete the StudentQualification of studentId and qualificationTypeId
        /// </summary>
        public void Delete(int studentId, int qualificationTypeId)
        {
            try
            {
                bool success = _stdQualRepo.Delete(studentId, qualificationTypeId);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete studentQualification, studentId: {studentId}, qualificationTypeId: {qualificationTypeId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
