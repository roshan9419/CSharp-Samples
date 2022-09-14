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
    public class StudentQualificationRepositoryTests
    {
        private readonly StudentQualificationRepository _qualRepo;
        private int _studentId = 22090001;

        public StudentQualificationRepositoryTests()
        {
            // Arrange
            var apiService = new APIService("https://localhost:44373/api/");
            _qualRepo = new StudentQualificationRepository(apiService);
        }

        [TestMethod()]
        public async Task GetAll_ShouldReturnQualifications_OfAStudent()
        {
            // Act
            var result = await _qualRepo.GetAll(studentId: _studentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task Add_ShouldThrowException_WhenModelStateIsInvalid()
        {
            // Arrange
            var studentQual = new StudentQualification { StudentId = _studentId, PassingYear = -2020 };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _qualRepo.Add(studentQual));
        }

        [TestMethod()]
        public async void Remove_ShouldThrowException_WhenQualificationIdIsUnknown()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _qualRepo.Remove(_studentId, -1));
        }

        [TestMethod()]
        public async void Update_ShouldThrowException_WhenQualificationIdIsUnknown()
        {
            // Arrange
            var studentQual = new StudentQualification
            {
                StudentId = _studentId,
                QualificationTypeId = -1,
                PassingYear = 2019,
                Percentage = 80.06m
            };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _qualRepo.Update(studentQual));
        }
    }
}