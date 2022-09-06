using PlacementManagement.API.Utils;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace PlacementManagement.API.Repository
{
    public abstract class GenericRepository<TEntity> where TEntity : new()
    {
        private readonly IDBService _dbService;

        public GenericRepository(IDBService dbService)
        {
            _dbService = dbService;
        }

        protected object Create(string procedureName, DBParameter[] dbParams)
        {
            return _dbService.Create(procedureName, dbParams, CommandType.StoredProcedure);
        }

        protected bool Update(string procedureName, DBParameter[] dbParams)
        {
            return _dbService.Update(procedureName, dbParams, CommandType.StoredProcedure);
        }

        protected bool Delete(string procedureName, DBParameter[] dbParams)
        {
            return _dbService.Delete(procedureName, dbParams, CommandType.StoredProcedure);
        }

        protected TEntity Get(string procedureName, DBParameter[] dbParams)
        {
            var dataTable = _dbService.Get(procedureName, dbParams, CommandType.StoredProcedure);
            var resultList = dataTable.ConvertToObjects<TEntity>();
            
            if (resultList.Count == 0)
                throw new Exception("Entity not found");

            return resultList[0];
        }

        protected List<TEntity> GetAll(string procedureName, DBParameter[] dbParams)
        {
            var dataTable = _dbService.Get(procedureName, dbParams, CommandType.StoredProcedure);
            return dataTable.ConvertToObjects<TEntity>();
        }

        protected List<TEntity> ExecuteQuery(string query, DBParameter[] dbParams)
        {
            var dataTable = _dbService.Get(query, dbParams, CommandType.Text);
            return dataTable.ConvertToObjects<TEntity>();
        }
    }
}