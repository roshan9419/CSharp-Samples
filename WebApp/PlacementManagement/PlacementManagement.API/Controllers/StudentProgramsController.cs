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
        /// <returns>Returns the list of StudentProgram</returns>
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
        public void Post([FromBody] StudentProgram value)
        {
            _logger.Debug("Creating studentProgram: " + JsonConvert.SerializeObject(value));

            if (!ModelState.IsValid)
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
        public void Put(int studentId, int programId, [FromBody] StudentProgram value)
        {
            _logger.Debug("Updating studentProgram: " + JsonConvert.SerializeObject(value));

            if (!ModelState.IsValid)
            {
                _logger.Debug("Bad payload of StudentProgram");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                bool success = _programRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
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
        public void Delete(int studentId, int programId)
        {
            try
            {
                bool success = _programRepo.Delete(studentId, programId);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete studentProgram, studentId: {studentId}, programId: {programId}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
