using log4net;
using Newtonsoft.Json;
using PlacementManagement.Models;
using PlacementManagement.Services;
using PlacementManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.Web.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly APIService _service;

        public StudentRepository(APIService service)
        {
            _service = service;
        }

        public async Task<int> CreateStudent(Student student)
        {
            _logger.Debug("Creating new student: " + JsonConvert.SerializeObject(student));

            try
            {
                var studentId = await _service.Create("students", student);
                return Convert.ToInt32(studentId);
            }
            catch (APIException ex)
            {
                string msg = "Failed to create Student";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "Student contains invalid details";
                        break;
                    case HttpStatusCode.Conflict:
                        msg = "Duplicate student entry";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task UpdateStudent(int studentId, Student student)
        {
            _logger.Debug("Updating student: " + JsonConvert.SerializeObject(student));

            try
            {
                await _service.Update($"students/{studentId}", student);
            }
            catch (APIException ex)
            {
                string msg = "Failed to update Student";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        msg = "Student contains invalid details";
                        break;
                    case HttpStatusCode.NotFound:
                        msg = "Student not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task DeleteStudent(int studentId)
        {
            _logger.Debug($"Deleting student: {studentId}");
            
            try
            {
                await _service.Delete($"students/{studentId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to delete Student";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "Student not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<Student> GetStudent(int studentId)
        {
            _logger.Debug($"Getting student: {studentId}");

            try
            {
                return await _service.Get<Student>($"students/{studentId}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Student";
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        msg = "Student not found";
                        break;
                }
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
        public async Task<Student> GetStudentByUserId(string userId)
        {
            _logger.Debug($"Getting student by userId: {userId}");

            try
            {
                var students = await _service.GetMany<Student>($"students?userId={userId}");
                
                if (students.Count == 0)
                {
                    string msg = $"No student associated with userId: {userId}";
                    _logger.Debug(msg);
                    throw new Exception(msg);
                }

                return students.First();
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Student";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<Student>> GetAllStudents(int page, int limit)
        {
            _logger.Debug($"Getting all students of page: {page} and limit: {limit}");

            try
            {
                return await _service.GetMany<Student>($"students?page={page}&limit={limit}");
            }
            catch (APIException ex)
            {
                string msg = "Failed to get Students";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }

        public async Task<List<Student>> GetFilteredStudents(StudentFilter filter)
        {
            _logger.Debug("Getting filtered students having filter: " + JsonConvert.SerializeObject(filter));

            try
            {
                return await _service.GetManyUsingPost<StudentFilter, Student>("search", filter);
            }
            catch (APIException ex)
            {
                string msg = "Failed to get filtered students";
                _logger.Error(msg, ex);
                throw new Exception(msg);
            }
        }
    }
}