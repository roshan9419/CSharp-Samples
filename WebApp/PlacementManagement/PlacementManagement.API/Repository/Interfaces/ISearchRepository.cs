using PlacementManagement.API.Models;
using PlacementManagement.DataModels;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public interface ISearchRepository
    {
        /// <summary>
        /// This will list all the students matching this filter
        /// </summary>
        /// <returns>Returns the list of Student</returns>
        List<Student> GetStudents(StudentFilter studentFilter);
    }
}
