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
    public class StudentSkillsController : ApiController
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly IStudentRepository<StudentSkill> _stdSkillRepo;

        public StudentSkillsController(IStudentRepository<StudentSkill> stdSkillRepo)
        {
            _stdSkillRepo = stdSkillRepo;
        }

        // GET: api/StudentSkills/5
        /// <summary>
        /// This will list StudentSkills of studentId
        /// </summary>
        /// <param name="studentId">StudentId for which skills are mapped</param>
        /// <returns>Returns the list of StudentSkill</returns>
        /// <exception cref="HttpResponseException"></exception>
        public IEnumerable<StudentSkill> Get(int studentId)
        {
            try
            {
                return _stdSkillRepo.GetAll(studentId);
            }
            catch (Exception ex)
            {
                string message = $"Failed to get student skills for studentId: {studentId}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // POST: api/StudentSkills
        /// <summary>
        /// This will create new StudentSkill of studentId
        /// </summary>
        /// <param name="value">StudentSkill model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Post([FromBody] StudentSkill value)
        {
            string message = "Creating studentSkill: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of StudentSkill";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                _stdSkillRepo.Create(value);
            }
            catch (Exception ex)
            {
                message = "Failed to create StudentSkill";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // PUT: api/StudentSkills/5
        /// <summary>
        /// This will update the existing skill details of studentId and skillId
        /// </summary>
        /// <param name="studentId">StudentId for which this skill is mapped</param>
        /// <param name="skillId">SkillId of skilll to be updated</param>
        /// <param name="value">StudentSkill model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int studentId, int skillId, [FromBody] StudentSkill value)
        {
            string message = "Updating studentSkill: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            value.StudentId = studentId;
            value.SkillId = skillId;

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of StudentSkill";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                bool success = _stdSkillRepo.Update(value);

                if (!success)
                {
                    message = "StudentId or SkillId not found";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.NotFound, message));
                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                message = "Failed to update studentSkill";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // DELETE: api/StudentSkills/5
        /// <summary>
        /// This will delete the StudentQualification of studentId and skillId
        /// </summary>
        /// <param name="studentId">StudentId for which this skill is mapped</param>
        /// <param name="skillId">SkillId of skilll to be deleted</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Delete(int studentId, int skillId)
        {
            string message;

            try
            {
                bool success = _stdSkillRepo.Delete(studentId, skillId);

                if (!success)
                {
                    message = "StudentId or SkillId not found";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.NotFound, message));
                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                message = $"Failed to delete studentSkill, studentId: {studentId}, skillId: {skillId}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }
    }
}
