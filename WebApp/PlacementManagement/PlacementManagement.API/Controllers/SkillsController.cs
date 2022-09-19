using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace PlacementManagement.API.Controllers
{
    public class SkillsController : ApiController
    {
        private static readonly ILog _logger = LogHelper.GetLogger();
        private readonly IRepository<Skill> _skillsRepo;

        public SkillsController(IRepository<Skill> skillsRepo)
        {
            _skillsRepo = skillsRepo;
        }

        // GET: api/Skills
        /// <summary>
        /// This will list all the Skills
        /// </summary>
        /// <param name="pagination">Pagination object containing Page, Limit values</param>
        /// <returns>Returns list of Skills</returns>
        /// <exception cref="HttpResponseException"></exception>
        public IEnumerable<Skill> Get([FromUri] Pagination pagination)
        {
            try
            {
                return _skillsRepo.GetAll(pagination);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to get skills", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }

        // GET: api/Skills/5
        /// <summary>
        /// This will returns the skill for id
        /// </summary>
        /// <param name="id">Id of skill</param>
        /// <returns>Returns Skill object</returns>
        /// <exception cref="HttpResponseException"></exception>
        public Skill Get(int id)
        {
            Skill skill = _skillsRepo.Get(id);
            if (skill == null)
            {
                _logger.Debug($"Skill not found for id: {id}");
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return skill;
        }

        // POST: api/Skills
        /// <summary>
        /// This will create new skill
        /// </summary>
        /// <param name="value">Skill model object</param>
        /// <returns>Returns the id of created skill</returns>
        /// <exception cref="HttpResponseException"></exception>
        public int Post([FromBody] Skill value)
        {
            _logger.Debug("Creating skill: " + JsonConvert.SerializeObject(value));

            if (value == null || !ModelState.IsValid)
            {
                _logger.Debug("Bad payload of skill");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                return _skillsRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create skill", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Skills/5
        /// <summary>
        /// This will update the skill for id
        /// </summary>
        /// <param name="id">Id to skill to be updated</param>
        /// <param name="value">Skill model object</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Put(int id, [FromBody] Skill value)
        {
            _logger.Debug("Updating skill: " + JsonConvert.SerializeObject(value));

            try
            {
                if (value == null || !ModelState.IsValid)
                {
                    _logger.Debug("Bad payload of skill");
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                Skill skill = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _skillsRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to update skill: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Skills/5
        /// <summary>
        /// This will delete the skill for id
        /// </summary>
        /// <param name="id">Id of skill to be deleted</param>
        /// <exception cref="HttpResponseException"></exception>
        public void Delete(int id)
        {
            try
            {
                Skill skill = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _skillsRepo.Delete(id);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete skill: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
