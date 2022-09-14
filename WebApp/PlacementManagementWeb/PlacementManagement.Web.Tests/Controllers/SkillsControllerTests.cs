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
    public class SkillsControllerTests
    {
        private readonly SkillsController _controller;

        public SkillsControllerTests()
        {
            // Assign
            var apiService = new APIService("https://localhost:44373/api/");
            var skillRepo = new SkillRepository(apiService);
            _controller = new SkillsController(skillRepo);
        }

        [TestMethod()]
        public async Task Index_ShouldReturnViewResult_WithSkills()
        {
            // Act
            var result = await _controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(IEnumerable<Skill>));
        }

        [TestMethod()]
        public async Task Create_ShouldReturnViewResult_WithErrorMessage_WhenModelStateIsInvalid()
        {
            // Assign
            var skill = new Skill { };

            // Act
            var result = await _controller.Create(skill);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(((ViewResult)result).ViewData["ErrorMessage"]);
        }

        [TestMethod()]
        public async Task Create_ShouldRedirectToIndex()
        {
            // Assign
            var skill = new Skill { SkillName = "Test Skill " + DateTime.Now.Millisecond.ToString() };

            // Act
            var result = await _controller.Create(skill);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public async Task Edit_ShouldReturnViewResult_WithErrorMessage_WhenSkillIdIsUnknown()
        {
            // Assign
            var skill = new Skill { SkillId = -100, SkillName = "Test Skill" };

            // Act
            var result = await _controller.Edit(-100, skill);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(((ViewResult)result).ViewData["ErrorMessage"]);
        }
    }
}