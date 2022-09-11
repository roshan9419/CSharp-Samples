using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
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
        /// <returns>Returns the list of Student</returns>
        public List<Student> Post([FromBody] StudentFilter filter)
        {
            _logger.Debug("Applied StudentFilter: " + JsonConvert.SerializeObject(filter));

            try
            {
                return _searchRepo.GetStudents(filter);
            }
            catch(Exception ex)
            {
                _logger.Error("Failed to get filtered students", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
