using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly ISearchRepository _searchRepo;
        
        public SearchController(ISearchRepository searchRepo)
        {
            _searchRepo = searchRepo;
        }

        // POST: api/Search
        /// <summary>
        /// This will list all the students matching the provided filter
        /// </summary>
        /// <param name="filter">StudentFilter object</param>
        /// <returns>Returns the list of Student</returns>
        /// <exception cref="HttpResponseException"></exception>
        public List<Student> Post([FromBody] StudentFilter filter)
        {
            string message = "Applied StudentFilter: " + JsonConvert.SerializeObject(filter);
            _logger.Debug(message);

            try
            {
                return _searchRepo.GetStudents(filter);
            }
            catch(Exception ex)
            {
                message = "Failed to get filtered students";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }
    }
}
