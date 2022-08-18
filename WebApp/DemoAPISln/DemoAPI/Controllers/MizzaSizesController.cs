using DemoAPI.Repository;
using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class MizzaSizesController : ApiController
    {
        MySQLCommandViewModel _commandVM;
        public MizzaSizesController()
        {
            _commandVM = new MySQLCommandViewModel("MIzzaNextDB");
        }

        // GET api/mizzasizes
        public IEnumerable<MizzaSize> Get()
        {
            var dt = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes");
            var mizzaSizes = new BunchMizza().MizzaSizes.ConvertToObjects(dt);

            return mizzaSizes;
        }

        // GET api/mizzasizes/5
        public MizzaSize Get(string id)
        {
            var dt = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes", id);
            var mizzaSizes = new BunchMizza().MizzaSizes.ConvertToObjects(dt);

            if (mizzaSizes.Count == 0)
            {
                // not found response 404
            }

            return mizzaSizes.First();
        }

        // POST api/mizzasizes
        public string Post([FromBody] MizzaSize value)
        {
            // handle (bad request)
            if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaSize", value))
            {
                // failed to create response
            }
            return value.MizzaSizeID;
        }

        // PUT api/mizzasizes/5
        public void Put(string id, [FromBody] MizzaSize value)
        {
            // handle (bad request, not found)
            if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaSize", value))
            {
                // failed to update
            }
        }

        // DELETE api/mizzasizes/5
        public void Delete(string id)
        {
            // handle (not found)
            if (!_commandVM.DeleteUsingStoredProcedure("DeleteMizzaSize", id))
            {
                // failed to delete
            }
        }
    }
}
