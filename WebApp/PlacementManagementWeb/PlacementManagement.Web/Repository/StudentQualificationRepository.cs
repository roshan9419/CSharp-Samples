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
    public class StudentQualificationRepository : 
        QualificationRepository, IStudentAcademicRepository<StudentQualification, QualificationType>
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public StudentQualificationRepository(APIService service) : base(service)
        {
            _service = service;
        }

        public async Task Add(StudentQualification qualification)
        {
            _logger.Debug("Adding new studentQualification: " + JsonConvert.SerializeObject(qualification));

            try
            {
                await _service.Create("studentqualifications", qualification);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create StudentQualification";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "StudentQualification contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate studentQualification entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Update(StudentQualification qualification)
        {
            _logger.Debug("Updating studentQualification: " + JsonConvert.SerializeObject(qualification));

            try
            {
                await _service.Update($"studentqualifications?studentId={qualification.StudentId}&qualificationTypeId={qualification.QualificationTypeId}", qualification);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update StudentQualification";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "StudentQualification contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "StudentQualification not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Remove(int studentId, int qualificationTypeId)
        {
            _logger.Debug($"Removing studentQualification, studentId: {studentId} and qualificationTypeId: {qualificationTypeId}");

            try
            {
                await _service.Delete($"studentqualifications?studentId={studentId}&qualificationTypeId={qualificationTypeId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to remove StudentQualification";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "StudentQualification not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<StudentQualification>> GetAll(int studentId)
        {
            _logger.Debug($"Getting all studentQualifications of student: {studentId}");

            try
            {
                return await _service.GetMany<StudentQualification>($"studentqualifications?studentId={studentId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get StudentQualifications";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}