using PlacementManagement.Models;
using PlacementManagement.Web.Repository;
using PlacementManagement.Services;
using System;
using System.Web.Configuration;
using Unity;
using Unity.Injection;

namespace PlacementManagement.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Register services 
            container.RegisterType<APIService>(
                new InjectionConstructor(new object[] { WebConfigurationManager.AppSettings["pmsApiBaseUrl"] }));

            // Register repositories
            container.RegisterType<IManageRepository<Program>, ProgramRepository>();
            container.RegisterType<IManageRepository<QualificationType>, QualificationRepository>();
            container.RegisterType<IManageRepository<Skill>, SkillRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentAcademicRepository<StudentProgram, Program>, StudentProgramRepository>();
            container.RegisterType<IStudentAcademicRepository<StudentQualification, QualificationType>, StudentQualificationRepository>();
            container.RegisterType<IStudentAcademicRepository<StudentSkill, Skill>, StudentSkillRepository>();
        }
    }
}