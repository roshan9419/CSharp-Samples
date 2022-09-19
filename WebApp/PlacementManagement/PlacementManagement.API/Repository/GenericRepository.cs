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

        /// <summary>
        /// This will call the storedProcedure along with dbParams for creating a record
        /// </summary>
        /// <param name="procedureName">StoredProcedure name to be called</param>
        /// <param name="dbParams">Parameters to be passed when calling this stored procedure</param>
        /// <returns>Returns the value retrieved after calling</returns>
        protected object Create(string procedureName, DBParameter[] dbParams)
        {
            return _dbService.Create(procedureName, dbParams, CommandType.StoredProcedure);
        }

        /// <summary>
        /// This will call the storedProcedure along with dbParams to update a record
        /// </summary>
        /// <param name="procedureName">StoredProcedure name to be called</param>
        /// <param name="dbParams">Parameters to be passed when calling this stored procedure</param>
        /// <returns>Returns the success status</returns>
        protected bool Update(string procedureName, DBParameter[] dbParams)
        {
            return _dbService.Update(procedureName, dbParams, CommandType.StoredProcedure);
        }

        /// <summary>
        /// This will call the storedProcedure along with dbParams to delete a record
        /// </summary>
        /// <param name="procedureName">StoredProcedure name to be called</param>
        /// <param name="dbParams">Parameters to be passed when calling this stored procedure</param>
        /// <returns>Returns the success status</returns>
        protected bool Delete(string procedureName, DBParameter[] dbParams)
        {
            return _dbService.Delete(procedureName, dbParams, CommandType.StoredProcedure);
        }

        /// <summary>
        /// This will call the storedProcedure along with dbParams to get a record
        /// </summary>
        /// <param name="procedureName">StoredProcedure name to be called</param>
        /// <param name="dbParams">Parameters to be passed when calling this stored procedure</param>
        /// <returns>Returns the single record if present otherwise default value will be returned</returns>
        protected TEntity Get(string procedureName, DBParameter[] dbParams)
        {
            var dataTable = _dbService.Get(procedureName, dbParams, CommandType.StoredProcedure);
            var resultList = dataTable.ConvertToObjects<TEntity>();

            if (resultList.Count == 0)
                return default(TEntity);

            return resultList[0];
        }

        /// <summary>
        /// This will call the storedProcedure along with dbParams to get multiple records
        /// </summary>
        /// <param name="procedureName">StoredProcedure name to be called</param>
        /// <param name="dbParams">Parameters to be passed when calling this stored procedure</param>
        /// <returns>Returns multiple records</returns>
        protected List<TEntity> GetAll(string procedureName, DBParameter[] dbParams)
        {
            var dataTable = _dbService.Get(procedureName, dbParams, CommandType.StoredProcedure);
            return dataTable.ConvertToObjects<TEntity>();
        }

        /// <summary>
        /// This will execute the given query along with dbParams
        /// </summary>
        /// <param name="query">Query to be executed</param>
        /// <param name="dbParams">Parameters to be passed when calling this stored procedure</param>
        /// <returns>Returns the list of records</returns>
        protected List<TEntity> ExecuteQuery(string query)
        {
            var dataTable = _dbService.Get(query, null, CommandType.Text);
            return dataTable.ConvertToObjects<TEntity>();
        }
    }
}