using log4net;
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
        /// <exception cref="HttpResponseException"></exception>
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
        /// <param name="id"></param>
        /// <exception cref="HttpResponseException"></exception>
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
        /// <param name="value"></param>
        /// <returns>Returns the created program id</returns>
        /// <exception cref="HttpResponseException"></exception>
        public int Post([FromBody] Program value)
        {
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
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int id, [FromBody] Program value)
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
        /// <param name="id"></param>
        /// <exception cref="HttpResponseException"></exception>
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
