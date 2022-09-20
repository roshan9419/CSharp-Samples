using PlacementManagement.API.Controllers;
using PlacementManagement.API.Models;
using PlacementManagement.API.Repository;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlacementManagement.API.xUnit.Tests.Controllers
{
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
        
        [Fact]
        public void GetPrograms_ShouldReturnProgramsList()
        {
            // Arrange
            _dbConfig.Program.GetAll = "GetPrograms";
            var pagination = new Pagination { Page = 1 };

            // Act
            var result = _controller.Get(pagination);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
