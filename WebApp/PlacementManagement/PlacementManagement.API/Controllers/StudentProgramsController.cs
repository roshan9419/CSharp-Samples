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
    public class StudentProgramsController : ApiController
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly IStudentRepository<StudentProgram> _programRepo;

        public StudentProgramsController(IStudentRepository<StudentProgram> programRepo)
        {
            _programRepo = programRepo;
        }

        // GET: api/StudentPrograms/5
        /// <summary>
        /// This will list StudentPrograms of studentId
        /// </summary>
        /// <param name="studentId">StudentId for which the programs are mapped</param>
        /// <returns>Returns the list of StudentProgram</returns>
        /// <exception cref="HttpResponseException"></exception>
        public IEnumerable<StudentProgram> Get(int studentId)
        {
            try
            {
                return _programRepo.GetAll(studentId);
            }
            catch (Exception ex)
            {
                string message = $"Failed to get student programs for studentId: {studentId}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // POST: api/StudentPrograms
        /// <summary>
        /// This will create new StudentProgram of studentId
        /// </summary>
        /// <param name="value">StudentProgram model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Post([FromBody] StudentProgram value)
        {
            string message = "Creating studentProgram: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of StudentProgram";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                _programRepo.Create(value);
            }
            catch (Exception ex)
            {
                message = "Failed to create StudentProgram";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // PUT: api/StudentPrograms/5
        /// <summary>
        /// This will update the existing program details of studentId and programId
        /// </summary>
        /// <param name="studentId">StudentId for which this program is mapped</param>
        /// <param name="programId">ProgramId of program to be updated</param>
        /// <param name="value">StudentQualification model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int studentId, int programId, [FromBody] StudentProgram value)
        {
            string message = "Updating studentProgram: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            value.StudentId = studentId;
            value.ProgramId = programId;

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of StudentProgram";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                bool success = _programRepo.Update(value);

                if (!success)
                {
                    message = "StudentId or ProgramId not found";
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
                message = "Failed to update studentProgram";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // DELETE: api/StudentPrograms/5
        /// <summary>
        /// This will delete the StudentProgram of studentId and programId
        /// </summary>
        /// <param name="studentId">StudentId for which this program is mapped</param>
        /// <param name="programId">ProgramId of program to be deleted</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Delete(int studentId, int programId)
        {
            string message;
            try
            {
                bool success = _programRepo.Delete(studentId, programId);

                if (!success)
                {
                    message = "StudentId or ProgramId not found";
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
                message = $"Failed to delete studentProgram, studentId: {studentId}, programId: {programId}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
