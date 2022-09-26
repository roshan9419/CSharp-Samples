using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Repository;
using PlacementManagement.API.Utils;
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
        /// <param name="studentId">StudentId for which the qualificatoins are mapped</param>
        /// <returns>Returns the list of StudentQualification</returns>
        /// <exception cref="HttpResponseException"></exception>
        public IEnumerable<StudentQualification> Get(int studentId)
        {
            try
            {
                return _stdQualRepo.GetAll(studentId);
            }
            catch (Exception ex)
            {
                string message = $"Failed to get student qualifications for studentId: {studentId}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // POST: api/StudentQualifications
        /// <summary>
        /// This will create new StudentQualification of studentId
        /// </summary>
        /// <param name="value">StudentQualification model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Post([FromBody] StudentQualification value)
        {
            string message = "Creating studentQualification: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of StudentQualification";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                _stdQualRepo.Create(value);
            }
            catch (Exception ex)
            {
                message = "Failed to create StudentQualification";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // PUT: api/StudentQualifications/5
        /// <summary>
        /// This will update the existing qualification details of studentId and qualificationTypeId
        /// </summary>
        /// <param name="studentId">StudentId for which this qualification is mapped</param>
        /// <param name="qualificationTypeId">QualificationTypeId of qualification to be updated</param>
        /// <param name="value">StudentQualification model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int studentId, int qualificationTypeId, [FromBody] StudentQualification value)
        {
            string message = "Updating studentQualification: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            value.StudentId = studentId;
            value.QualificationTypeId = qualificationTypeId;

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of StudentQualification";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                bool success = _stdQualRepo.Update(value);

                if (!success)
                {
                    message = "StudentId or QualificationTypeId not found";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                message = "Failed to update studentQualification";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // DELETE: api/StudentQualifications/5
        /// <summary>
        /// This will delete the StudentQualification of studentId and qualificationTypeId
        /// </summary>
        /// <param name="studentId">StudentId for which this qualification is mapped</param>
        /// <param name="qualificationTypeId">QualificationTypeId of qualification to be deleted</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Delete(int studentId, int qualificationTypeId)
        {
            string message;

            try
            {
                bool success = _stdQualRepo.Delete(studentId, qualificationTypeId);

                if (!success)
                {
                    message = "StudentId or QualificationTypeId not found";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                message = $"Failed to delete studentQualification, studentId: {studentId}, qualificationTypeId: {qualificationTypeId}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
