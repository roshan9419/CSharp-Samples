﻿using PlacementManagement.API.Models;
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
        private readonly IRepository<Student> _studentRepo;
        public StudentsController(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET: api/Students?UserId=""
        public IEnumerable<Student> Get([FromUri] StudentPagination stdPagination)
        {
            Pagination pagination = new Pagination
            {
                Page = stdPagination.Page,
                Limit = stdPagination.Limit,
                OtherParams = new object[] { stdPagination.UserId }
            };

            return _studentRepo.GetAll(pagination);
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            return _studentRepo.Get(id);
        }

        // POST: api/Students
        public int Post([FromBody] Student value)
        {
            return _studentRepo.Create(value);
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody] Student value)
        {
            _studentRepo.Update(value);
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            _studentRepo.Delete(id);
        }
    }
}
