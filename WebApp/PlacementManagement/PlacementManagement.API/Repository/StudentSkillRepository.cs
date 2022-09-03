using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class StudentSkillRepository : GenericRepository<StudentSkill>, IStudentRepository<StudentSkill>
    {
        private readonly DatabaseConfig _dbConfig;
        public StudentSkillRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public void Create(StudentSkill studentProgram)
        {
            Create(_dbConfig.StudentSkill.Create, studentProgram.GetDBParameters());
        }

        public bool Update(StudentSkill studentProgram)
        {
            return Update(_dbConfig.StudentSkill.Update, studentProgram.GetDBParameters());
        }

        public bool Delete(int studentId, int skillId)
        {
            return Delete(_dbConfig.StudentSkill.Delete, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId },
                new DBParameter { Key = "SkillId", Value = skillId }
            });
        }

        public List<StudentSkill> GetAll(int studentId)
        {
            return GetAll(_dbConfig.StudentSkill.GetAll, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId }
            });
        }
    }
}