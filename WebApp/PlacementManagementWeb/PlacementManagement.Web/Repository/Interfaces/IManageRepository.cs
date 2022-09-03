using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository
{
    /// <summary>
    /// Manage additional things like Skills, Programs, QualificationTypes
    /// </summary>
    public interface IManageRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
    }
}
