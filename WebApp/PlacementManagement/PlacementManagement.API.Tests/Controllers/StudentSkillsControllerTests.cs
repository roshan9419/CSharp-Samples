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
    public class StudentSkillsControllerTests
    {
        private readonly StudentSkillsController _controller;
        private readonly DatabaseConfig _dbConfig;
        private readonly int _studentId = 22090001;

        public StudentSkillsControllerTests()
        {
            // Arrange
            _dbConfig = new DatabaseConfig();
            var dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
            var skillRepo = new StudentSkillRepository(dbService, _dbConfig);
            _controller = new StudentSkillsController(skillRepo);
        }

        [TestMethod()]
        public void GetStudentSkills_ShouldReturnStudentSkillsList()
        {
            // Arrange
            _dbConfig.StudentSkill.GetAll = "GetStudentSkills";

            // Act
            var result = _controller.Get(_studentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void PostStudentSkill_WithInvalidModelState_ShouldReturnBadRequest400()
        {
            // Arrange
            _dbConfig.StudentSkill.Create = "CreateStudentSkill";
            var model = new StudentSkill();

            // Act
            Action call = () => _controller.Post(null);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod()]
        public void PutStudentSkill_WithInvalidSkillId_ShouldReturnNotFound404()
        {
            // Arrange
            _dbConfig.StudentSkill.Update = "UpdateStudentSkill";
            var model = new StudentSkill { StudentId = _studentId, SkillId = -1 };

            // Act
            Action call = () => _controller.Put(_studentId, -1, model);

            // Assert
            var ex = Assert.ThrowsException<HttpResponseException>(call);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}