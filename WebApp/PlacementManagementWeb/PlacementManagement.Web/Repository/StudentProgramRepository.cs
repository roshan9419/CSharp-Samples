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
    public class StudentProgramRepository : ProgramRepository, IStudentAcademicRepository<StudentProgram, Program>
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public StudentProgramRepository(APIService service) : base(service)
        {
            _service = service;
        }

        public async Task Add(StudentProgram program)
        {
            _logger.Debug("Adding new studentProgram: " + JsonConvert.SerializeObject(program));
            
            try
            {
                await _service.Create("studentprograms", program);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create StudentProgram";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "StudentProgram contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate studentProgram entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Update(StudentProgram program)
        {
            _logger.Debug("Updating studentProgram: " + JsonConvert.SerializeObject(program));

            try
            {
                await _service.Update($"studentprograms?studentId={program.StudentId}&programId={program.ProgramId}", program);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update StudentProgram";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "StudentProgram contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "StudentProgram not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task Remove(int studentId, int programId)
        {
            _logger.Debug($"Removing studentProgram, studentId: {studentId} and programId: {programId}");

            try
            {
                await _service.Delete($"studentprograms?studentId={studentId}&programId={programId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to remove StudentProgram";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "StudentProgram not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<StudentProgram>> GetAll(int studentId)
        {
            _logger.Debug($"Getting all studentPrograms of student: {studentId}");

            try
            {
                return await _service.GetMany<StudentProgram>($"studentprograms?studentId={studentId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get StudentPrograms";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}