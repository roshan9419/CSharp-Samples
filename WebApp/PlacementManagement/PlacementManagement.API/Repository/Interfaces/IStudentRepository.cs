using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.API.Repository
{
    public interface IStudentRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// This will create the entity
        /// </summary>
        void Create(TEntity entity);

        /// <summary>
        /// This will update the existing entity
        /// </summary>
        /// <returns>Returns the success status</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// This will delete the existing entity for studentId and param
        /// </summary>
        /// <returns>Returns the success status</returns>
        bool Delete(int studentId, int param);

        /// <summary>
        /// This will return all the records for studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Returns list of entities</returns>
        List<TEntity> GetAll(int studentId);
    }
}
