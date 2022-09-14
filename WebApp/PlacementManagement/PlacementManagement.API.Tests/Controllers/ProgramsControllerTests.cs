using PlacementManagement.API.Controllers;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.Services;
using System.Configuration;
using System.Web.Http;
using Xunit;

namespace PlacementManagement.API.Tests.Controllers
{
    public class ProgramsControllerTests
    {
        private readonly DatabaseConfig _dbConfig;
        private readonly MySqlDBService _dbService;

        public ProgramsControllerTests()
        {
            _dbConfig = new DatabaseConfig();
            _dbService = new MySqlDBService("Server=127.0.0.1;Database=pms;Uid=root;Pwd=lsq1234;");
        }

        [Fact]
        [Trait("Manage", "Program")]
        public void GetPrograms_ShouldReturnAllPrograms()
        {
            // Arrange
            _dbConfig.Program.GetAll = "GetAllPrograms";
            var programController = new ProgramsController(new ProgramRepository(_dbService, _dbConfig));
            var pagination = new Pagination { Page = 1, Limit = 10 };

            // Act
            var programs = programController.Get(pagination);

            // Assert
            //Assert.Throws<HttpResponseException>(()=>programController.Get(pagination));
            Assert.NotEmpty(programs);
        }

        [Fact]
        public void GetProgram_ShouldReturnProgramWithSameId()
        {
        }

        [Fact]
        public void GetProgram_ShouldReturnNotFound()
        {
        }

        [Fact]
        public void PostProgram_ShouldReturnProgramId()
        {
        }

        [Fact]
        public void PutProgram_ShouldUpdateProgramWithSameId()
        {
        }

        [Fact]
        public void PutProgram_ShouldFailAsNotFound()
        {
        }

        [Fact]
        public void DeleteProgram_ShouldDeleteProgramWithSameId()
        {
        }
    }
}
