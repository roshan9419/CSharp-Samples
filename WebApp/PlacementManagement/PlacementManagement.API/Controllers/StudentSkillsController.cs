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
                _logger.Error($"Failed to get student skills for studentId: {studentId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
            _logger.Debug("Creating studentSkill: " + JsonConvert.SerializeObject(value));

            if (value == null || !ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentSkill");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                _stdSkillRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create StudentSkill", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
            _logger.Debug("Updating studentSkill: " + JsonConvert.SerializeObject(value));

            value.StudentId = studentId;
            value.SkillId = skillId;

            if (value == null || !ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentSkill");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                bool success = _stdSkillRepo.Update(value);

                if (!success)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                _logger.Debug("StudentId or SkillId not found");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to update studentSkill", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
            try
            {
                bool success = _stdSkillRepo.Delete(studentId, skillId);

                if (!success)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                _logger.Debug("StudentId or SkillId not found");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete studentSkill, studentId: {studentId}, skillId: {skillId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
