using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacementManagement.API.Controllers;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PlacementManagement.API.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        private readonly DatabaseConfig _dbConfig;
        private readonly StudentsController _controller;

        public StudentsControllerTests()
        {
            // Arrange
            _dbConfig = new DatabaseConfig();
            var dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
            var studentRepo = new StudentRepository(dbService, _dbConfig);
            _controller = new StudentsController(studentRepo);
        }

        [TestMethod()]
        public void GetStudents_ShouldReturnStudentsList()
        {
            // Arrange
            _dbConfig.Student.GetAll = "GetStudents";
            var pagination = new StudentPagination { Page = 1, Limit = 2 };

            // Act
            var result = _controller.Get(pagination);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void GetStudent_WithUnknownStudentId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.Student.Get = "GetStudent";

            // Act
            Action call = () => _controller.Get(-1);

            // Act & Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void PutStudent_WithInvalidModelState_ShouldReturnBadRequest400()
        {
            // Arrange
            _dbConfig.Student.Update = "UpdateStudent";
            var model = new Student
            {
                FirstName = "Test",
                Country = "India",
                Gender = DataModels.Enums.Gender.Male
            };

            // Act
            Action call = () => _controller.Put(22090001, model);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void DeleteStudent_WithUnknownStudentId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.Student.Get = "GetStudent";
            _dbConfig.Student.Delete = "DeleteStudent";

            // Act
            Action call = () => _controller.Delete(-100);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}