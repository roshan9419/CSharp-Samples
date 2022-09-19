using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacementManagement.API.Controllers;
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
    public class StudentQualificationsControllerTests
    {
        private readonly StudentQualificationsController _controller;
        private readonly DatabaseConfig _dbConfig;
        private readonly int _studentId = 22090001;

        public StudentQualificationsControllerTests()
        {
            // Arrange
            _dbConfig = new DatabaseConfig();
            var dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
            var qualRepo = new StudentQualificationRepository(dbService, _dbConfig);
            _controller = new StudentQualificationsController(qualRepo);
        }

        [TestMethod()]
        public void GetStudentQualifications_ShouldReturnQualificationsList()
        {
            // Arrange
            _dbConfig.StudentQualification.GetAll = "GetStudentQualifications";

            // Act
            var result = _controller.Get(studentId: _studentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod()]
        public void PostStudentQualification_WithInvalidModelState_ShouldReturnBadRequest400()
        {
            // Arrange
            _dbConfig.StudentQualification.Create = "CreateStudent";
            var model = new StudentQualification();

            // Act
            Action call = () => _controller.Post(null);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void PutStudentQualification_WithUnknownStudentId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.StudentQualification.Update = "UpdateStudentQualification";
            var model = new StudentQualification
            {
                StudentId = -100,
                QualificationTypeId = 1,
                PassingYear = 2023,
                Percentage = 60
            };

            // Act
            Action call = () => _controller.Put(model.StudentId, model.QualificationTypeId, model);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void DeleteStudentQualification_WithUnknownQualTypeId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.StudentQualification.Delete = "DeleteStudentQualification";

            // Act
            Action call = () => _controller.Delete(2209001, -2);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}