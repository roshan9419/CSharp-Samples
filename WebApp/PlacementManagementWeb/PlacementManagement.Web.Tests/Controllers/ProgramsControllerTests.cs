using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacementManagement.Models;
using PlacementManagement.Services;
using PlacementManagement.Web.Controllers;
using PlacementManagement.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers.Tests
{
    [TestClass()]
    public class ProgramsControllerTests
    {
        private readonly ProgramsController _controller;

        public ProgramsControllerTests()
        {
            // Arrange
            var apiService = new APIService("https://localhost:44373/api/");
            var programRepo = new ProgramRepository(apiService);
            _controller = new ProgramsController(programRepo);
        }

        [TestMethod()]
        public async Task Index_ShouldReturnViewResult_WithPrograms()
        {
            // Act
            var result = await _controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(IEnumerable<Program>));
        }

        [TestMethod()]
        public async Task Create_ShouldReturnViewResult_WithErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var program = new Program { };

            // Act
            var result = await _controller.Create(program);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(((ViewResult)result).ViewData["ErrorMessage"]);
        }

        [TestMethod()]
        public async Task Create_ShouldRedirectToIndex()
        {
            // Arrange
            var program = new Program { ProgramName = "Test Program " + DateTime.Now.Millisecond.ToString() };

            // Act
            var result = await _controller.Create(program);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public async Task Edit_ShouldReturnViewResult_WithErrorMessage_WhenProgramIdIsUnknown()
        {
            // Arrange
            var program = new Program { ProgramId = -100, ProgramName = "Test Program" };

            // Act
            var result = await _controller.Edit(-100, program);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(((ViewResult)result).ViewData["ErrorMessage"]);
        }
    }
}