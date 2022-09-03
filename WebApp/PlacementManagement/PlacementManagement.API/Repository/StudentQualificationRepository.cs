using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class StudentQualificationRepository : GenericRepository<StudentQualification>, IStudentRepository<StudentQualification>
    {
        private readonly DatabaseConfig _dbConfig;
        public StudentQualificationRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public void Create(StudentQualification stdQual)
        {
            Create(_dbConfig.StudentQualification.Create, stdQual.GetDBParameters());
        }

        public bool Update(StudentQualification stdQual)
        {
            return Update(_dbConfig.StudentQualification.Update, stdQual.GetDBParameters());
        }

        public bool Delete(int studentId, int qualTypeId)
        {
            return Delete(_dbConfig.StudentQualification.Delete, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId },
                new DBParameter { Key = "QualificationTypeId", Value = qualTypeId }
            });
        }

        public List<StudentQualification> GetAll(int studentId)
        {
            return GetAll(_dbConfig.StudentQualification.GetAll, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId }
            });
        }
    }
}