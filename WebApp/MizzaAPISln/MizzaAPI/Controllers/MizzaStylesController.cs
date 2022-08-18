using Mizza.DataModels;
using Mizza.DataRepo;
using MizzaAPI.Models;
using MizzaAPI.Repository;
using MizzaAPI.Utils;
using System.Collections.Generic;
using System.Web.Http;

namespace MizzaAPI.Controllers
{
    public class MizzaStylesController : ApiController
    {
        MizzaItemRepository _mizzaRepo;
        public MizzaStylesController()
        {
            _mizzaRepo = new MizzaItemRepository();
        }

        // GET: api/MizzaStyles
        public IEnumerable<MizzaStyle> Get()
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaStyles", new List<DBParameter> {
                new DBParameter { Key = "MizzaStyleID", Value = null }
            });
            return _mizzaRepo.MizzaStyles.ConvertToObjects(dt);
        }

        // GET: api/MizzaStyles/5
        public MizzaStyle Get(string id)
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaStyles", new List<DBParameter> {
                new DBParameter { Key = "MizzaStyleID", Value = id }
            });
            return _mizzaRepo.MizzaStyles.ConvertToObjects(dt)[0];
        }

        // POST: api/MizzaStyles
        public void Post([FromBody] MizzaStyle value)
        {
            _mizzaRepo.CommandVM.CreateRecord("CreateMizzaStyle", value.GetDBParameters());
        }

        // PUT: api/MizzaStyles/5
        public void Put(string id, [FromBody] MizzaStyle value)
        {
            _mizzaRepo.CommandVM.UpdateRecord("UpdateMizzaStyle", value.GetDBParameters());
        }

        // DELETE: api/MizzaStyles/5
        public void Delete(string id)
        {
            _mizzaRepo.CommandVM.DeleteRecord("DeleteMizzaStyle", new List<DBParameter> {
                new DBParameter { Key = "MizzaStyleID", Value = id }
            });
        }

        // TODO: Handle exceptions
        // TODO: Sending appropriate status codes
    }
}
