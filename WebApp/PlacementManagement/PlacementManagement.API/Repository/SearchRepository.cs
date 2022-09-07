using PlacementManagement.API.Models;
using PlacementManagement.DataModels;
using PlacementManagement.DataModels.Enums;
using PlacementManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlacementManagement.API.Repository
{
    public class SearchRepository : GenericRepository<Student>, ISearchRepository
    {
        public SearchRepository(MySqlDBService dbService) : base(dbService)
        {
        }


        /*
         
        SELECT 

	        S.StudentId,
            S.Gender,
            SP.CurrentCGPA,
            SP.Backlogs,
            SP.BatchEndYear,
            SP.ProgramId,
            SQ.QualificationTypeId,
            SQ.Percentage,
            SS.SkillId
    
        FROM Student S
        INNER JOIN StudentProgram SP ON S.StudentId = SP.StudentId
        INNER JOIN StudentQualification SQ ON S.StudentId = SQ.StudentId
        INNER JOIN StudentSkill SS ON S.StudentId = SS.StudentId

        WHERE S.Gender IN (1, 2)

        AND SP.CurrentCGPA >= 7

        AND SP.Backlogs <= 1

        AND SP.BatchEndYear IN (2021, 2025, 2023)

        AND SP.ProgramId IN (4, 1)

        AND (
	        (SQ.QualificationTypeId = 1 AND GetQualificationPercentage(SQ.StudentId, 1) >= 60) 
	        OR 
            (SQ.QualificationTypeId = 2 AND GetQualificationPercentage(SQ.StudentId, 2) >= 70)
        )

        AND SS.SkillId IN (13, 19, 3)

        GROUP BY S.StudentId
        ;
         
         */

        public List<Student> GetStudents(StudentFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            string query = "SELECT S.* FROM Student S";

            if (IsProgramFilterPresent(filter))
                query += " INNER JOIN StudentProgram SP ON S.StudentId = SP.StudentId";

            if (IsQualificationsPresent(filter))
                query += " INNER JOIN StudentQualification SQ ON S.StudentId = SQ.StudentId";

            if (IsSkillsPresent(filter))
                query += " INNER JOIN StudentSkill SS ON S.StudentId = SS.StudentId";

            query += " WHERE";

            if (IsNullOrEmpty(filter.Genders))
                filter.Genders = (Gender[])Enum.GetValues(typeof(Gender));

            List<int> genders = new List<int>();
            foreach (var gender in filter.Genders)
                genders.Add((int)gender);

            query += $" S.Gender IN ({string.Join(",", genders)})";

            if (!IsNullOrEmpty(filter.MinimumCGPA))
                query += $" AND SP.CurrentCGPA >= {filter.MinimumCGPA}";

            if (!IsNullOrEmpty(filter.MaximumBacklog))
                query += $" AND SP.Backlogs <= {filter.MaximumBacklog}";

            if (!IsNullOrEmpty(filter.Batches))
                query += $" AND SP.BatchEndYear IN ({string.Join(",", filter.Batches)})";

            if (!IsNullOrEmpty(filter.ProgramIds))
                query += $" AND SP.ProgramId IN ({string.Join(",", filter.ProgramIds)})";

            if (!IsNullOrEmpty(filter.SkillIds))
                query += $" AND SS.SkillId IN ({string.Join(",", filter.SkillIds)})";

            if (!IsNullOrEmpty(filter.Qualifications))
            {
                var qualFilters = new List<string>();
                foreach (var qual in filter.Qualifications)
                {
                    if (qual == null) continue;
                    string qualFilter = $"(SQ.QualificationTypeId = {qual.QualificationTypeId} AND " +
                        $"(" +
                            $" SELECT Percentage FROM StudentQualification" +
                            $" WHERE StudentQualification.StudentId = S.StudentId" +
                            $" AND StudentQualification.QualificationTypeId = {qual.QualificationTypeId}" +
                        $")" +
                        $" >= {qual.MinimumPercentage})";
                    qualFilters.Add(qualFilter);
                }

                query += $" AND ({string.Join("OR", qualFilters)})";
            }

            query += " GROUP BY S.StudentId;";

            return ExecuteQuery(query, null);
        }

        private bool IsProgramFilterPresent(StudentFilter filter)
        {
            return (
                !IsNullOrEmpty(filter.MinimumCGPA) ||
                !IsNullOrEmpty(filter.MaximumBacklog) ||
                !IsNullOrEmpty(filter.ProgramIds) ||
                !IsNullOrEmpty(filter.Batches)
            );
        }

        private bool IsQualificationsPresent(StudentFilter filter) => !IsNullOrEmpty(filter.Qualifications);

        private bool IsSkillsPresent(StudentFilter filter) => !IsNullOrEmpty(filter.SkillIds);

        private bool IsNullOrEmpty(object property)
        {
            return property == null || (property.GetType().IsArray && ((dynamic)property).Length == 0);
        }
    }
}