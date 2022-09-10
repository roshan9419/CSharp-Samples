﻿using log4net;
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
        /// <returns>Returns the list of StudentSkill</returns>
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
        public void Post([FromBody] StudentSkill value)
        {
            _logger.Debug(value);

            if (!ModelState.IsValid)
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
        public void Put(int studentId, int skillId, [FromBody] StudentSkill value)
        {
            _logger.Debug(value);

            if (!ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentSkill");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                bool success = _stdSkillRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
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
        public void Delete(int studentId, int skillId)
        {
            try
            {
                bool success = _stdSkillRepo.Delete(studentId, skillId);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete studentSkill, studentId: {studentId}, skillId: {skillId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
