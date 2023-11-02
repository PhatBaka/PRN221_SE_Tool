using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SETool_Business.Services;
using SETool_Business.Services.Extensions;
using SETool_Business.Services.Impls;
using SETool_Data.Repositories.IRepos;
using SETool_Data.Repositories.Repos;

namespace SETool_RazorPage.Extensions
{
    public static class ServiceExtension
    {
        public static void AddConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            // VALIDATOR
            services.AddScoped<IValidationService, ValidationService>();

            //  USER
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();

            // ROLE
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddSingleton<IRoleRepository, RoleRepository>();

            // GROUP
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddSingleton<IGroupRepository, GroupRepository>();

            // PROJECT
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();

            // TEACHER PROJECT
            services.AddScoped<ITeacherProjectRepository, TeacherProjectRepository>();
            services.AddSingleton<ITeacherProjectRepository, TeacherProjectRepository>();

            // SEMESTER
            services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddSingleton<ISemesterRepository, SemesterRepository>();

            // GENERIC
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
