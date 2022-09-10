using System.Collections.Generic;
using PlacementManagement.API.Models;

namespace PlacementManagement.API.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// This will create a new entity
        /// </summary>
        /// <returns>The newly created id</returns>
        int Create(TEntity entity);

        /// <summary>
        /// This will update the entity
        /// </summary>
        /// <returns>The success flag if updated or not</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// This will delete the entity for id
        /// </summary>
        /// <returns>The success flag if deleted or not</returns>
        bool Delete(int param);

        /// <summary>
        /// This will return the entity for id
        /// </summary>
        /// <returns>Returns the entity</returns>
        TEntity Get(int param);

        /// <summary>
        /// This will return the entities for provided pagination values
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>Returns the entites</returns>
        List<TEntity> GetAll(Pagination pagination);
    }
}
