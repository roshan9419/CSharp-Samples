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
    public class ProgramsControllerTests
    {
        private readonly ProgramsController _controller;
        private readonly DatabaseConfig _dbConfig;
        
        public ProgramsControllerTests()
        {
            // Arrange
            _dbConfig = new DatabaseConfig();
            var dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
            var programRepo = new ProgramRepository(dbService, _dbConfig);
            _controller = new ProgramsController(programRepo);
        }

        [TestMethod()]
        public void GetPrograms_ShouldReturnProgramsList()
        {
            // Arrange
            _dbConfig.Program.GetAll = "GetPrograms";
            var pagination = new Pagination { Page = 1 };

            // Act
            var result = _controller.Get(pagination);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void GetProgram_WithUnknownProgramId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.Program.Get = "GetProgram";

            // Act
            Action call = () => _controller.Get(-1);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void GetProgram_WithValidProgramId_ShouldReturnProgram()
        {
            // Arrange
            _dbConfig.Program.Get = "GetProgram";

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PutProgram_WithInvalidModelState_ShouldReturnBadRequest400()
        {
            // Arrange
            _dbConfig.Program.Get = "GetProgram";
            _dbConfig.Program.Update = "UpdateProgram";
            var model = new Program { };

            // Act
            Action call = () => _controller.Put(1, null);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void DeleteProgram_WithUnknownProgramId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.Program.Get = "GetProgram";
            _dbConfig.Program.Delete = "DeleteProgram";

            // Act
            Action call = () => _controller.Delete(-1);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}