using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class ProgramsController : ApiController
    {
        private static readonly ILog _logger = LogHelper.GetLogger();
        private readonly IRepository<Program> _programsRepo;

        public ProgramsController(IRepository<Program> programsRepo)
        {
            _programsRepo = programsRepo;
        }

        // GET: api/Programs
        /// <summary>
        /// This will list all programs
        /// </summary>
        public IEnumerable<Program> Get([FromUri] Pagination pagination)
        {
            try
            {
                return _programsRepo.GetAll(pagination);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to get programs", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/Programs/5
        /// <summary>
        /// This will provide program details for id
        /// </summary>
        /// <returns>Returns the program</returns>
        public Program Get(int id)
        {
            Program program = _programsRepo.Get(id);
            if (program == null)
            {
                _logger.Debug($"Program not found for id: {id}");
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return program;
        }

        // POST: api/Programs
        /// <summary>
        /// This will create program for provided body
        /// </summary>
        /// <returns>Returns the created program id</returns>
        public int Post([FromBody] Program value)
        {
            _logger.Debug("Creating program: " + JsonConvert.SerializeObject(value));

            if (value == null || !ModelState.IsValid)
            {
                _logger.Debug("Bad payload of program");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                return _programsRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create program", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Programs/5
        /// <summary>
        /// This will update the program details for id
        /// </summary>
        public void Put(int id, [FromBody] Program value)
        {
            _logger.Debug("Updating program: " + JsonConvert.SerializeObject(value));

            try
            {
                if (value == null || !ModelState.IsValid)
                {
                    _logger.Debug("Bad payload of program");
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
                Program program = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _programsRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to update program: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Programs/5
        /// <summary>
        /// This will delete the program for id
        /// </summary>
        public void Delete(int id)
        {
            try
            {
                Program program = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _programsRepo.Delete(id);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete program: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
