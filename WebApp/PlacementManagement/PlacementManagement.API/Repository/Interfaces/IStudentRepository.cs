using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.API.Repository
{
    public interface IStudentRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int studentId, int param);
        List<TEntity> GetAll(int studentId);
    }
}
