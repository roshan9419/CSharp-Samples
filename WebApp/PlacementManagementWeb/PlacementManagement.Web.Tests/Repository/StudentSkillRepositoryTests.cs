using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacementManagement.Models;
using PlacementManagement.Services;
using PlacementManagement.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository.Tests
{
    [TestClass()]
    public class StudentSkillRepositoryTests
    {
        private readonly StudentSkillRepository _skillRepo;
        private int _studentId = 22090001;

        public StudentSkillRepositoryTests()
        {
            // Assign
            var apiService = new APIService("https://localhost:44373/api/");
            _skillRepo = new StudentSkillRepository(apiService);
        }

        [TestMethod()]
        public async Task GetAll_ShouldReturnSkills_OfAStudent()
        {
            // Act
            var result = await _skillRepo.GetAll(studentId: _studentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task Add_ShouldThrowException_WhenModelStateIsInvalid()
        {
            // Assign
            var studentSkill = new StudentSkill { StudentId = _studentId, Experience = 0 };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _skillRepo.Add(studentSkill));
        }

        [TestMethod()]
        public async void Remove_ShouldThrowException_WhenSkillIdIsUnknown()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _skillRepo.Remove(_studentId, -1));
        }

        [TestMethod()]
        public async void Update_ShouldThrowException_WhenSkillIdIsUnknown()
        {
            // Assign
            var studentSkill = new StudentSkill
            {
                StudentId = _studentId,
                SkillId = -1,
                Experience = 1,
                ProjectsDone = 4
            };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _skillRepo.Update(studentSkill));
        }
    }
}