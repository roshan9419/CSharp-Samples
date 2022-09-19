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
                _logger.Error($"Failed to get student programs for studentId: {studentId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
            _logger.Debug("Creating studentProgram: " + JsonConvert.SerializeObject(value));

            if (value == null || !ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentProgram");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                _programRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create StudentProgram", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
            _logger.Debug("Updating studentProgram: " + JsonConvert.SerializeObject(value));

            value.StudentId = studentId;
            value.ProgramId = programId;

            if (value == null || !ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentProgram");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                bool success = _programRepo.Update(value);

                if (!success)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                _logger.Debug("StudentId or ProgramId not found");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to update studentProgram", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
            try
            {
                bool success = _programRepo.Delete(studentId, programId);

                if (!success)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                _logger.Debug("StudentId or ProgramId not found");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete studentProgram, studentId: {studentId}, programId: {programId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
