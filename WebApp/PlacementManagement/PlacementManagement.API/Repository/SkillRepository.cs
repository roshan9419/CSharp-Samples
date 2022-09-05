using PlacementManagement.API.Models;
using PlacementManagement.API.Utils;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace PlacementManagement.API.Repository
{
    public class SkillRepository : GenericRepository<Skill>, IRepository<Skill>
    {
        private readonly DatabaseConfig _dbConfig;
        public SkillRepository(MySqlDBService dbService, DatabaseConfig dbConfig) : base(dbService)
        {
            _dbConfig = dbConfig;
        }

        public int Create(Skill skill)
        {
            var skillId = Create(_dbConfig.Skill.Create, skill.GetDBParameters());
            return Convert.ToInt32(skillId);
        }

        public bool Update(Skill skill)
        {
            return Update(_dbConfig.Skill.Update, skill.GetDBParameters());
        }

        public bool Delete(int skillId)
        {
            return Delete(_dbConfig.Skill.Delete, new DBParameter[] {
                new DBParameter { Key = "SkillId", Value = skillId }
            });
        }

        public Skill Get(int skillId)
        {
            return Get(_dbConfig.Skill.Get, new DBParameter[] {
                new DBParameter { Key = "SkillId", Value = skillId }
            });
        }

        public List<Skill> GetAll(Pagination pagination)
        {
            return GetAll(_dbConfig.Skill.GetAll, null);
        }
    }
}