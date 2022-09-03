using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class StudentProgramRepository : GenericRepository<StudentProgram>, IStudentRepository<StudentProgram>
    {
        private readonly DatabaseConfig _dbConfig;
        public StudentProgramRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public void Create(StudentProgram studentProgram)
        {
            Create(_dbConfig.StudentProgram.Create, studentProgram.GetDBParameters());
        }

        public bool Update(StudentProgram studentProgram)
        {
            return Update(_dbConfig.StudentProgram.Update, studentProgram.GetDBParameters());
        }

        public bool Delete(int studentId, int programId)
        {
            return Delete(_dbConfig.StudentProgram.Delete, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId },
                new DBParameter { Key = "ProgramId", Value = programId }
            });
        }

        public List<StudentProgram> GetAll(int studentId)
        {
            return GetAll(_dbConfig.StudentProgram.GetAll, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId }
            });
        }
    }
}