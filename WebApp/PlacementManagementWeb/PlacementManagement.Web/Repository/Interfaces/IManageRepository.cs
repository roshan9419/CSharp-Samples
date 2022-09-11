using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository
{
    /// <summary>
    /// Manage additional things like Skills, Programs, QualificationTypes
    /// </summary>
    public interface IManageRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// This will create a new entity
        /// </summary>
        Task Create(TEntity entity);

        /// <summary>
        /// This will update the entity of id
        /// </summary>
        Task Update(int id, TEntity entity);

        /// <summary>
        /// This will delete the entity of id
        /// </summary>
        Task Delete(int id);

        /// <summary>
        /// This will get the entity details of id
        /// </summary>
        /// <returns>Return object of entity type</returns>
        Task<TEntity> Get(int id);

        /// <summary>
        /// This will list all the entities
        /// </summary>
        /// <returns>Returns list of entities</returns>
        Task<List<TEntity>> GetAll();
    }
}
