using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int param);
        TEntity Get(int param);
        List<TEntity> GetAll();
    }
}
