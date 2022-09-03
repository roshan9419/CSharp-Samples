using PlacementManagement.Services.Models;
using System.Data;

namespace PlacementManagement.Services
{
    public interface IDBService
    {
        DataTable Get(string procedureName, DBParameter[] dbParams, CommandType commandType);
        object Create(string procedureName, DBParameter[] dbParams, CommandType commandType);
        bool Delete(string procedureName, DBParameter[] dbParams, CommandType commandType);
        bool Update(string procedureName, DBParameter[] dbParams, CommandType commandType);
    }
}
