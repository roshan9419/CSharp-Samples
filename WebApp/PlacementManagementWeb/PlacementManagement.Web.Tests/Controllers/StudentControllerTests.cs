using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacementManagement.Models;
using PlacementManagement.Services;
using PlacementManagement.Web.Controllers;
using PlacementManagement.Web.Repository;
using PlacementManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers.Tests
{
    [TestClass()]
    public class StudentControllerTests
    {
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            // Arrange
            var apiService = new APIService("https://localhost:44373/api/");
            var studentRepo = new StudentRepository(apiService);
            var programRepo = new StudentProgramRepository(apiService);
            var qualificationRepo = new StudentQualificationRepository(apiService);
            var skillRepo = new StudentSkillRepository(apiService);

            _controller = new StudentController(studentRepo, programRepo, qualificationRepo, skillRepo);
        }

        [TestMethod()]
        public async Task Index_ShouldReturnViewResult_WithStudents()
        {
            // Act
            var result = await _controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(IEnumerable<StudentDetailViewModel>));
        }

        [TestMethod()]
        public async Task Details_ShouldReturnViewResult_WithErrorMessage_WhenStudentIdIsUnknown()
        {
            // Act
            var result = await _controller.Details(studentId: -1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(((ViewResult)result).ViewData["ErrorMessage"]);
        }

        [TestMethod()]
        public async Task Details_ShouldReturnViewResult_WithStudent()
        {
            // Act
            var result = await _controller.Details(studentId: 22090001);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(StudentDetailViewModel));
        }
    }
}