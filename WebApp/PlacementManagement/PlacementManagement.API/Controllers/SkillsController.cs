using log4net;
using Newtonsoft.Json;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.API.Utils;
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
                string message = "Failed to get skills";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
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
                string message = $"Skill not found for id: {id}";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.NotFound, message));
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
            string message = "Creating skill: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            if (value == null || !ModelState.IsValid)
            {
                message = "Bad payload of skill";
                _logger.Debug(message);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
            }

            try
            {
                return _skillsRepo.Create(value);
            }
            catch (Exception ex)
            {
                message = "Failed to create skill";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
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
            string message = "Updating skill: " + JsonConvert.SerializeObject(value);
            _logger.Debug(message);

            try
            {
                if (value == null || !ModelState.IsValid)
                {
                    message = "Bad payload of skill";
                    _logger.Debug(message);
                    throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.BadRequest, message));
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
                message = $"Failed to update skill: {id}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
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
                string message = $"Failed to delete skill: {id}";
                _logger.Error(message, ex);
                throw new HttpResponseException(HttpUtils.GetHttpResponse(HttpStatusCode.InternalServerError, message));
            }
        }
    }
}
