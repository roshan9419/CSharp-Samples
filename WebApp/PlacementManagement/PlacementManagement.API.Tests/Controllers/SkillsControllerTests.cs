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
    public class SkillsControllerTests
    {
        private readonly SkillsController _controller;
        private readonly DatabaseConfig _dbConfig;

        public SkillsControllerTests()
        {
            // Arrange
            _dbConfig = new DatabaseConfig();
            var dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
            var skillRepo = new SkillRepository(dbService, _dbConfig);
            _controller = new SkillsController(skillRepo);
        }

        [TestMethod()]
        public void GetSkills_ShouldReturnSkillsList()
        {
            // Arrange
            _dbConfig.Skill.GetAll = "GetSkills";
            var pagination = new Pagination { Page = 1 };

            // Act
            var result = _controller.Get(pagination);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void GetSkill_WithUnknownSkillId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.Skill.Get = "GetSkill";

            // Act
            Action call = () => _controller.Get(-1);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void GetSkill_WithValidSkillId_ShouldReturnSkill()
        {
            // Arrange
            _dbConfig.Skill.Get = "GetSkill";

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PutSkill_WithInvalidModelState_ShouldReturnBadRequest400()
        {
            // Arrange
            _dbConfig.Skill.Get = "GetSkill";
            _dbConfig.Skill.Update = "UpdateSkill";
            var model = new Skill { };

            // Act
            Action call = () => _controller.Put(1, null);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void DeleteSkill_WithUnknownSkillId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.Skill.Get = "GetSkill";
            _dbConfig.Skill.Delete = "DeleteSkill";

            // Act
            Action call = () => _controller.Delete(-1);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}