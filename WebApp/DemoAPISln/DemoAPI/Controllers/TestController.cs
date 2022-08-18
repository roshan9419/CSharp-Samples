using DemoAPI.Repository;
using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DemoAPI.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/test
        public IEnumerable<MizzaSize> Get()
        {
            var commandVM = new MySQLCommandViewModel("MIzzaNextDB");
            var dt = commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes");
            var mizzaSizes = new BunchMizza().MizzaSizes.ConvertToObjects(dt);

            return mizzaSizes;
        }

        // GET: api/test/id
        public int Get(string id)
        {
            var commandVM = new MySQLCommandViewModel("MIzzaNextDB");
            int count = commandVM.GetCount($"SELECT COUNT(*) FROM {id}");
            return count;
        }

        // POST api/test
        public string Post([FromBody] string value)
        {
            return "Value Recieved => " + value;
        }
    }
}