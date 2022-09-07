using PlacementManagement.API.Models;
using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.DataModels.Enums;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.API.Repository
{
    public class SearchRepository : GenericRepository<Student>, ISearchRepository
    {
        private readonly string _studentTable = typeof(Student).GetTableName();
        private readonly string _stdProgramTable = typeof(StudentProgram).GetTableName();
        private readonly string _stdQualificationTable = typeof(StudentQualification).GetTableName();
        private readonly string _stdSkillTable = typeof(StudentSkill).GetTableName();

        public SearchRepository(MySqlDBService dbService) : base(dbService)
        {
        }

        public List<Student> GetStudents(StudentFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            string query = $"SELECT S.* FROM {_studentTable} S";

            if (IsProgramFilterPresent(filter))
                query += $" INNER JOIN {_stdProgramTable} SP ON S.StudentId = SP.StudentId";

            if (IsQualificationsPresent(filter))
                query += $" INNER JOIN {_stdQualificationTable} SQ ON S.StudentId = SQ.StudentId";

            if (IsSkillsPresent(filter))
                query += $" INNER JOIN {_stdSkillTable} SS ON S.StudentId = SS.StudentId";

            query += " WHERE";

            query = AddStudentFilter(query, filter);
            query = AddProgramFilter(query, filter);
            query = AddSkillFilter(query, filter);
            query = AddQualificationsFilter(query, filter);

            int limit = filter.Limit;
            int offset = limit * (filter.Page - 1);

            query += $" GROUP BY S.StudentId LIMIT {offset},{limit};";

            return ExecuteQuery(query, null);
        }

        private string AddStudentFilter(string query, StudentFilter filter)
        {
            if (filter.Genders.IsNullOrEmpty())
                filter.Genders = (Gender[])Enum.GetValues(typeof(Gender));

            List<int> genders = new List<int>();
            foreach (var gender in filter.Genders)
                genders.Add((int)gender);

            return query += $" S.Gender IN ({string.Join(",", genders)})";
        }

        private string AddProgramFilter(string query, StudentFilter filter)
        {
            if (!filter.MinimumCGPA.IsNullOrEmpty())
                query += $" AND SP.CurrentCGPA >= {filter.MinimumCGPA}";

            if (!filter.MaximumBacklog.IsNullOrEmpty())
                query += $" AND SP.Backlogs <= {filter.MaximumBacklog}";

            if (!filter.Batches.IsNullOrEmpty())
                query += $" AND SP.BatchEndYear IN ({string.Join(",", filter.Batches)})";

            if (!filter.ProgramIds.IsNullOrEmpty())
                query += $" AND SP.ProgramId IN ({string.Join(",", filter.ProgramIds)})";

            return query;
        }

        private string AddSkillFilter(string query, StudentFilter filter)
        {
            if (!filter.SkillIds.IsNullOrEmpty())
                query += $" AND SS.SkillId IN ({string.Join(",", filter.SkillIds)})";
            
            return query;
        }

        private string AddQualificationsFilter(string query, StudentFilter filter)
        {
            if (!filter.Qualifications.IsNullOrEmpty())
            {
                var qualFilters = new List<string>();
                foreach (var qual in filter.Qualifications)
                {
                    if (qual == null) continue;
                    string qualFilter = $"(SQ.QualificationTypeId = {qual.QualificationTypeId} AND " +
                        $"(" +
                            $" SELECT Percentage FROM {_stdQualificationTable}" +
                            $" WHERE {_stdQualificationTable}.StudentId = S.StudentId" +
                            $" AND {_stdQualificationTable}.QualificationTypeId = {qual.QualificationTypeId}" +
                        $")" +
                        $" >= {qual.MinimumPercentage})";
                    qualFilters.Add(qualFilter);
                }

                query += $" AND ({string.Join("OR", qualFilters)})";
            }

            return query;
        }

        private bool IsProgramFilterPresent(StudentFilter filter)
        {
            return (
                !filter.MinimumCGPA.IsNullOrEmpty() ||
                !filter.MaximumBacklog.IsNullOrEmpty() ||
                !filter.ProgramIds.IsNullOrEmpty() ||
                !filter.Batches.IsNullOrEmpty()
            );
        }

        private bool IsQualificationsPresent(StudentFilter filter) => !filter.Qualifications.IsNullOrEmpty();

        private bool IsSkillsPresent(StudentFilter filter) => !filter.SkillIds.IsNullOrEmpty();
    }
}