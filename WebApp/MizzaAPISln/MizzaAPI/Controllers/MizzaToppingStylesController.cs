using Mizza.DataModels;
using Mizza.DataRepo;
using MizzaAPI.Models;
using MizzaAPI.Repository;
using MizzaAPI.Utils;
using System.Collections.Generic;
using System.Web.Http;

namespace MizzaAPI.Controllers
{
    public class MizzaToppingStylesController : ApiController
    {
        MizzaToppingRepository _mizzaRepo;
        public MizzaToppingStylesController()
        {
            _mizzaRepo = new MizzaToppingRepository();
        }

        // GET: api/MizzaToppingStyles
        public IEnumerable<MizzaToppingStyle> Get()
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaToppingStyles", new DBParameter[] {
                new DBParameter { Key = "ToppingStyleID", Value = null }
            });
            return _mizzaRepo.MizzaToppingStyles.ConvertToObjects(dt);
        }

        // GET: api/MizzaToppingStyles/5
        public MizzaToppingStyle Get(string id)
        {
            var dt = _mizzaRepo.CommandVM.GetRecords("GetMizzaToppingStyles", new DBParameter[] {
                new DBParameter { Key = "ToppingStyleID", Value = id }
            });
            return _mizzaRepo.MizzaToppingStyles.ConvertToObjects(dt)[0];
        }

        // POST: api/MizzaToppingStyles
        public void Post([FromBody] MizzaToppingStyle value)
        {
            _mizzaRepo.CommandVM.CreateRecord("CreateMizzaToppingStyle", value.GetDBParameters());
        }

        // PUT: api/MizzaToppingStyles/5
        public void Put(string id, [FromBody] MizzaToppingStyle value)
        {
            _mizzaRepo.CommandVM.UpdateRecord("UpdateMizzaToppingStyle", value.GetDBParameters());
        }

        // DELETE: api/MizzaToppingStyles/5
        public void Delete(string id)
        {
            _mizzaRepo.CommandVM.DeleteRecord("DeleteMizzaToppingStyle", new DBParameter[] {
                new DBParameter { Key = "ToppingStyleID", Value = id }
            });
        }
    }
}
