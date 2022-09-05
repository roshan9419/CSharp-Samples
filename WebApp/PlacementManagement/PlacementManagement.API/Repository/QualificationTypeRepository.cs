using PlacementManagement.API.Models;
using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class QualificationTypeRepository : GenericRepository<QualificationType>, IRepository<QualificationType>
    {
        private readonly DatabaseConfig _dbConfig;

        public QualificationTypeRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public int Create(QualificationType qualificationType)
        {
            var qualTypeId = Create(_dbConfig.QualificationType.Create, qualificationType.GetDBParameters());
            return Convert.ToInt32(qualTypeId);
        }

        public bool Update(QualificationType qualificationType)
        {
            return Update(_dbConfig.QualificationType.Update, qualificationType.GetDBParameters());
        }

        public bool Delete(int id)
        {
            return Delete(_dbConfig.QualificationType.Delete, new DBParameter[] {
                new DBParameter { Key = "Id", Value = id }
            });
        }

        public QualificationType Get(int id)
        {
            return Get(_dbConfig.QualificationType.Get, new DBParameter[] {
                new DBParameter { Key = "Id", Value = id }
            });
        }

        public List<QualificationType> GetAll(Pagination pagination)
        {
            return GetAll(_dbConfig.QualificationType.GetAll, null);
        }
    }
}