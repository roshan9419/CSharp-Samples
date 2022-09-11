using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Repository
{
    /// <summary>
    /// Student academic related operations like his/her programs, qualifications and skills
    /// </summary>
    public interface IStudentAcademicRepository<TEntity, TPEntity> : 
        IManageRepository<TPEntity> where TPEntity : class
    {
        /// <summary>
        /// This will add a new entity
        /// </summary>
        Task Add(TEntity entity);

        /// <summary>
        /// This will update the entity
        /// </summary>
        Task Update(TEntity entity);

        /// <summary>
        /// This will delete the entity
        /// </summary>
        /// <param name="studentId">StudentId of student</param>
        /// <param name="id">Academic id can be ProgramId, QualificationTypeId or SkillId</param>
        /// <returns></returns>
        Task Remove(int studentId, int id);

        /// <summary>
        /// This will list all the academic entities of studentId
        /// </summary>
        /// <returns>Returns list of academic entities like of StudentProgram</returns>
        Task<List<TEntity>> GetAll(int studentId);
    }
}
