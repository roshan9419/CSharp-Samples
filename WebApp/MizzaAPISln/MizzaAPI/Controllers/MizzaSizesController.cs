using Mizza.DataModels;
using Mizza.DataRepo;
using MizzaAPI.Models;
using MizzaAPI.Repository;
using MizzaAPI.Utils;
using System.Collections.Generic;
using System.Web.Http;

namespace MizzaAPI.Controllers
{
    public class MizzaSizesController : ApiController
    {
        MizzaItemRepository _mizzaRepo;
        public MizzaSizesController()
        {
            _mizzaRepo = new MizzaItemRepository();
        }

        // GET: api/MizzaSizes
        public IEnumerable<MizzaSize> Get()
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaSizes", new DBParameter[] {
                new DBParameter { Key = "MizzaSizeID", Value = null }
            });
            return _mizzaRepo.MizzaSizes.ConvertToObjects(dt);
        }

        // GET: api/MizzaSizes/5
        public MizzaSize Get(string id)
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaSizes", new DBParameter[] {
                new DBParameter { Key = "MizzaSizeID", Value = id }
            });
            return _mizzaRepo.MizzaSizes.ConvertToObjects(dt)[0];
        }

        // POST: api/MizzaSizes
        public void Post([FromBody] MizzaSize value)
        {
            _mizzaRepo.CommandVM.CreateRecord("CreateMizzaSize", value.GetDBParameters());
        }

        // PUT: api/MizzaSizes/5
        public void Put(string id, [FromBody] MizzaSize value)
        {
            _mizzaRepo.CommandVM.UpdateRecord("UpdateMizzaSize", value.GetDBParameters());
        }

        // DELETE: api/MizzaSizes/5
        public void Delete(string id)
        {
            _mizzaRepo.CommandVM.DeleteRecord("DeleteMizzaSize", new DBParameter[] {
                new DBParameter { Key = "MizzaSizeID", Value = id }
            });
        }

        // TODO: Handle exceptions
        // TODO: Sending appropriate status codes
    }
}
