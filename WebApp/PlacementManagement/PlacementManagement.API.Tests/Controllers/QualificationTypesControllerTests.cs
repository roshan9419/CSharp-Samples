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
    public class QualificationTypesControllerTests
    {
        private readonly QualificationTypesController _controller;
        private readonly DatabaseConfig _dbConfig;

        public QualificationTypesControllerTests()
        {
            // Arrange
            _dbConfig = new DatabaseConfig();
            var dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
            var qualRepo = new QualificationTypeRepository(dbService, _dbConfig);
            _controller = new QualificationTypesController(qualRepo);
        }

        [TestMethod()]
        public void GetQualificationTypes_ShouldReturnQualificationTypesList()
        {
            // Arrange
            _dbConfig.QualificationType.GetAll = "GetQualificationTypes";
            var pagination = new Pagination { Page = 1 };

            // Act
            var result = _controller.Get(pagination);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void GetQualificationType_WithUnknownQualificationTypeId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.QualificationType.Get = "GetQualificationType";

            // Act
            Action call = () => _controller.Get(-1);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void GetQualificationType_WithValidQualificationTypeId_ShouldReturnQualificationType()
        {
            // Arrange
            _dbConfig.QualificationType.Get = "GetQualificationType";

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PutQualificationType_WithInvalidModelState_ShouldReturnBadRequest400()
        {
            // Arrange
            _dbConfig.QualificationType.Get = "GetQualificationType";
            _dbConfig.QualificationType.Update = "UpdateQualificationType";
            var model = new QualificationType { };

            // Act
            Action call = () => _controller.Put(1, null);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void DeleteQualificationType_WithUnknownProgramId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.QualificationType.Get = "GetQualificationType";
            _dbConfig.QualificationType.Delete = "DeleteQualificationType";

            // Act
            Action call = () => _controller.Delete(-1);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}