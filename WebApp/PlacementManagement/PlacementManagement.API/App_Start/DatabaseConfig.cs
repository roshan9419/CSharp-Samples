using System.Configuration;

namespace PlacementManagement.API
{
    public class DatabaseConfig : ConfigurationSection
    {
        [ConfigurationProperty("skill", IsRequired = true)]
        public StoredProcedure Skill
        {
            get { return (StoredProcedure)this["skill"]; }
            set { this["skill"] = value; }
        }

        [ConfigurationProperty("program", IsRequired = true)]
        public StoredProcedure Program
        {
            get { return (StoredProcedure)this["program"]; }
            set { this["program"] = value; }
        }

        [ConfigurationProperty("qualificationType", IsRequired = true)]
        public StoredProcedure QualificationType
        {
            get { return (StoredProcedure)this["qualificationType"]; }
            set { this["qualificationType"] = value; }
        }

        [ConfigurationProperty("student", IsRequired = true)]
        public StoredProcedure Student
        {
            get { return (StoredProcedure)this["student"]; }
            set { this["student"] = value; }
        }

        [ConfigurationProperty("studentProgram", IsRequired = true)]
        public StoredProcedure StudentProgram
        {
            get { return (StoredProcedure)this["studentProgram"]; }
            set { this["studentProgram"] = value; }
        }

        [ConfigurationProperty("studentQualification", IsRequired = true)]
        public StoredProcedure StudentQualification
        {
            get { return (StoredProcedure)this["studentQualification"]; }
            set { this["studentQualification"] = value; }
        }

        [ConfigurationProperty("studentSkill", IsRequired = true)]
        public StoredProcedure StudentSkill
        {
            get { return (StoredProcedure)this["studentSkill"]; }
            set { this["studentSkill"] = value; }
        }


        public class StoredProcedure : ConfigurationElement
        {
            [ConfigurationProperty("create", IsRequired = true)]
            public string Create
            {
                get { return (string)this["create"]; }
                set { this["create"] = value; }
            }

            [ConfigurationProperty("update", IsRequired = true)]
            public string Update
            {
                get { return (string)this["update"]; }
                set { this["update"] = value; }
            }

            [ConfigurationProperty("delete", IsRequired = true)]
            public string Delete
            {
                get { return (string)this["delete"]; }
                set { this["delete"] = value; }
            }

            [ConfigurationProperty("get")]
            public string Get
            {
                get { return (string)this["get"]; }
                set { this["get"] = value; }
            }

            [ConfigurationProperty("getAll", IsRequired = true)]
            public string GetAll
            {
                get { return (string)this["getAll"]; }
                set { this["getAll"] = value; }
            }
        }
    }
}