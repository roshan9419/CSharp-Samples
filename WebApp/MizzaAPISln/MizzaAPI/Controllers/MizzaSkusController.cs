using Mizza.DataModels;
using Mizza.DataRepo;
using MizzaAPI.Models;
using MizzaAPI.Repository;
using MizzaAPI.Utils;
using System.Collections.Generic;
using System.Web.Http;

namespace MizzaAPI.Controllers
{
    public class MizzaSkusController : ApiController
    {
        MizzaItemRepository _mizzaRepo;
        public MizzaSkusController()
        {
            _mizzaRepo = new MizzaItemRepository();
        }

        // GET: api/MizzaSkus
        public IEnumerable<MizzaSKU> Get()
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaSkus", new DBParameter[] {
                new DBParameter { Key = "MizzaSKUID", Value = null }
            });
            return _mizzaRepo.MizzaSkus.ConvertToObjects(dt);
        }

        // GET: api/MizzaSkus/5
        public MizzaSKU Get(string id)
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaSkus", new DBParameter[] {
                new DBParameter { Key = "MizzaSKUID", Value = id }
            });
            return _mizzaRepo.MizzaSkus.ConvertToObjects(dt)[0];
        }

        // POST: api/MizzaSkus
        public void Post([FromBody] MizzaSKU value)
        {
            _mizzaRepo.CommandVM.CreateRecord("CreateMizzaSku", value.GetDBParameters());
        }

        // PUT: api/MizzaSkus/5
        public void Put(string id, [FromBody] MizzaSKU value)
        {
            _mizzaRepo.CommandVM.UpdateRecord("UpdateMizzaSku", value.GetDBParameters());
        }

        // DELETE: api/MizzaSkus/5
        public void Delete(string id)
        {
            _mizzaRepo.CommandVM.DeleteRecord("DeleteMizzaSku", new DBParameter[] {
                new DBParameter { Key = "MizzaSKUID", Value = id }
            });
        }

        // TODO: Handle exceptions
        // TODO: Sending appropriate status codes
    }
}
