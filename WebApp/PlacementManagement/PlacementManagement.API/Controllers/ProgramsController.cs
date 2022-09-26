using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.API.Utils;
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

        /// GET: api/Programs
        /// <summary>
        /// This will list all programs
        /// </summary>
        /// <param name="pagination">Pagination object containing Page, Limit values</param>
        /// <returns>Returns list of Program</returns>
        /// <exception cref="HttpResponseException"></exception>
        public IEnumerable<Program> Get([FromUri] Pagination pagination)
        {
            try
            {
                return _programsRepo.GetAll(pagination);
            }
            catch (Exception ex)
            {
                string message = "Failed to get programs";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // GET: api/Programs/5
        /// <summary>
        /// This will provide program details for id
        /// </summary>
        /// <param name="id">Id of the Program</param>
        /// <returns>Returns the Program</returns>
        /// <exception cref="HttpResponseException"></exception>
        public Program Get(int id)
        {
            Program program = _programsRepo.Get(id);
            if (program == null)
            {
                string message = $"Program not found for id: {id}";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.NotFound, message));
            }
            return program;
        }

        // POST: api/Programs
        /// <summary>
        /// This will create program for provided body
        /// </summary>
        /// <param name="value">Program model object</param>
        /// <returns>Returns the created program id</returns>
        /// <exception cref="HttpResponseException"></exception>
        public int Post([FromBody] Program value)
        {
            string message = "Creating program: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of program";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                return _programsRepo.Create(value);
            }
            catch (Exception ex)
            {
                message = "Failed to create program";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // PUT: api/Programs/5
        /// <summary>
        /// This will update the program details for id
        /// </summary>
        /// <param name="id">Id of Program to be updated</param>
        /// <param name="value">Program model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int id, [FromBody] Program value)
        {
            string message = "Updating program: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            try
            {
                if (value == null || !ModelState.IsValid)
                {
                    message = "Bad payload of program";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
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
                message = $"Failed to update program: {id}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }

        // DELETE: api/Programs/5
        /// <summary>
        /// This will delete the program for id
        /// </summary>
        /// <param name="id">Id of program to be deleted</param>
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
                string message = $"Failed to delete program: {id}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }
    }
}
