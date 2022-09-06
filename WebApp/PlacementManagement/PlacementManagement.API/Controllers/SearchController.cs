using PlacementManagement.API.Models;
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
    public class SearchController : ApiController
    {
        private readonly ISearchRepository _searchRepo;
        public SearchController(ISearchRepository searchRepo)
        {
            _searchRepo = searchRepo;
        }

        // POST: api/Search
        public List<Student> Post([FromBody] StudentFilter filter)
        {
            return _searchRepo.GetStudents(filter);
        }
    }
}
