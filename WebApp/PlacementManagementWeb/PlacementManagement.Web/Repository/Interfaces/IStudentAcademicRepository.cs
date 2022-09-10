﻿using System;
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
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(int studentId, int id);
        Task<List<TEntity>> GetAll(int studentId);
    }
}
