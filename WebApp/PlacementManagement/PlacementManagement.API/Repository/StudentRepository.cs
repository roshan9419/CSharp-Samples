using PlacementManagement.API.Models;
using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class StudentRepository : GenericRepository<Student>, IRepository<Student>
    {
        private readonly DatabaseConfig _dbConfig;
        public StudentRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public int Create(Student student)
        {
            var studentId = Create(_dbConfig.Student.Create, student.GetDBParameters());
            return Convert.ToInt32(studentId);
        }

        public bool Update(Student student)
        {
            return Update(_dbConfig.Student.Update, student.GetDBParameters());
        }

        public bool Delete(int studentId)
        {
            return Delete(_dbConfig.Student.Delete, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId }
            });
        }

        public Student Get(int studentId)
        {
            return Get(_dbConfig.Student.Get, new DBParameter[] {
                new DBParameter { Key = "StudentId", Value = studentId }
            });
        }

        public List<Student> GetAll(Pagination pagination)
        {
            var dbParams = new DBParameter[] {
                new DBParameter { Key = "PageNo", Value = pagination.Page },
                new DBParameter { Key = "PageSize", Value = pagination.Limit },
                new DBParameter { Key = "UserId", Value = pagination.OtherParams[0] }
            };

            return GetAll(_dbConfig.Student.GetAll, dbParams);
        }
    }
}