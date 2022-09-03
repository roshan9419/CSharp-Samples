using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class ProgramRepository : GenericRepository<Program>, IRepository<Program>
    {
        private readonly DatabaseConfig _dbConfig;

        public ProgramRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public int Create(Program program)
        {
            var programId = Create(_dbConfig.Program.Create, program.GetDBParameters());
            return Convert.ToInt32(programId);
        }

        public bool Update(Program program)
        {
            return Update(_dbConfig.Program.Update, program.GetDBParameters());
        }

        public bool Delete(int programId)
        {
            return Delete(_dbConfig.Program.Delete, new DBParameter[] {
                new DBParameter { Key = "ProgramId", Value = programId }
            });
        }

        public Program Get(int programId)
        {
            return Get(_dbConfig.Program.Get, new DBParameter[] {
                new DBParameter { Key = "ProgramId", Value = programId }
            });
        }

        public List<Program> GetAll()
        {
            return GetAll(_dbConfig.Program.GetAll, null);
        }
    }
}