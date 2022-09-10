using PlacementManagement.Services.Models;
using System.Data;

namespace PlacementManagement.Services
{
    public interface IDBService
    {
        /// <summary>
        /// This will call the query or procedureName with dbParams to get dataTable result
        /// </summary>
        /// <returns>Returns the DataTable with filled values</returns>
        DataTable Get(string procedureName, DBParameter[] dbParams, CommandType commandType);
        
        /// <summary>
        /// This will call the query or procedureName with dbParams and retrieves the returned first cell data
        /// </summary>
        /// <returns>Returns the first cell data</returns>
        object Create(string procedureName, DBParameter[] dbParams, CommandType commandType);
        
        /// <summary>
        /// This will call the query or procedureName with dbParams
        /// </summary>
        /// <returns>Returns the success status if deleted or not</returns>
        bool Delete(string procedureName, DBParameter[] dbParams, CommandType commandType);
        
        /// <summary>
        /// This will call the query or procedureName with dbParams
        /// </summary>
        /// <returns>Returns the success status if updated or not</returns>
        bool Update(string procedureName, DBParameter[] dbParams, CommandType commandType);
    }
}
