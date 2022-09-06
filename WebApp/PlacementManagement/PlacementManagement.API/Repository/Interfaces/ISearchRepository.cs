using PlacementManagement.API.Models;
using PlacementManagement.DataModels;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public interface ISearchRepository
    {
        List<Student> GetStudents(StudentFilter studentFilter);
    }
}
