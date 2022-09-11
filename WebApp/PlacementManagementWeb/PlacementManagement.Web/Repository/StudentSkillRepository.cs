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
    public class StudentSkillRepository : 
        SkillRepository, IStudentAcademicRepository<StudentSkill, Skill>
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public StudentSkillRepository(APIService service) : base(service)
        {
            _service = service;
        }

        public async Task Add(StudentSkill skill)
        {
            _logger.Debug("Adding new studentSkill: " + JsonConvert.SerializeObject(skill));

            try
            {
                await _service.Create("studentskills", skill);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create StudentSkill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "StudentSkill contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate studentSkill entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Update(StudentSkill skill)
        {
            _logger.Debug("Updating studentSkill: " + JsonConvert.SerializeObject(skill));

            try
            {
                await _service.Update($"studentskills?studentId={skill.StudentId}&skillId={skill.SkillId}", skill);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update StudentSkill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "StudentSkill contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "StudentSkill not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Remove(int studentId, int skillId)
        {
            _logger.Debug($"Removing studentSkill, studentId: {studentId} and skillId: {skillId}");

            try
            {
                await _service.Delete($"studentskills?studentId={studentId}&skillId={skillId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to remove StudentSkill";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "StudentSkill not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<StudentSkill>> GetAll(int studentId)
        {
            _logger.Debug($"Getting all studentSkills of student: {studentId}");

            try
            {
                return await _service.GetMany<StudentSkill>($"studentskills?studentId={studentId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get StudentSkill";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}