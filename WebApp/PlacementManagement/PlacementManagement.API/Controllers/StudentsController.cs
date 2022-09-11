using log4net;
using Newtonsoft.Json;
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
    public class StudentsController : ApiController
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly IRepository<Student> _studentRepo;

        public StudentsController(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET: api/Students?UserId=""
        /// <summary>
        /// This will list the students in pages
        /// </summary>
        public IEnumerable<Student> Get([FromUri] StudentPagination stdPagination)
        {
            Pagination pagination = new Pagination
            {
                Page = stdPagination.Page,
                Limit = stdPagination.Limit,
                OtherParams = new object[] { stdPagination.UserId }
            };

            try
            {
                return _studentRepo.GetAll(pagination);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to get students", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/Students/5
        /// <summary>
        /// This will return the student details for id
        /// </summary>
        public Student Get(int id)
        {
            Student student = _studentRepo.Get(id);
            if (student == null)
            {
                _logger.Debug($"Student not found of id: {id}");
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return student;
        }

        // POST: api/Students
        /// <summary>
        /// This will create a new student and returns the studentId
        /// </summary>
        public int Post([FromBody] Student value)
        {
            _logger.Debug("Creating student: " + JsonConvert.SerializeObject(value));

            if (!ModelState.IsValid)
            {
                _logger.Debug("Bad payload of student");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                return _studentRepo.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to create student", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Students/5
        /// <summary>
        /// This will update the existing student for id
        /// </summary>
        public void Put(int id, [FromBody] Student value)
        {
            _logger.Debug("Updating student: " + JsonConvert.SerializeObject(value));

            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.Debug("Bad payload of student");
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                Student student = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _studentRepo.Update(value);

                if (!success)
                    throw new Exception("Update not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to update student: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Students/5
        /// <summary>
        /// This will delete the existing student for id
        /// </summary>
        public void Delete(int id)
        {
            try
            {
                Student student = Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool success = _studentRepo.Delete(id);

                if (!success)
                    throw new Exception("Delete not successful");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to delete student: {id}", ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
