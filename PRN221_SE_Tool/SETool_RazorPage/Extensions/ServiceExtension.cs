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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            // ROLE
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleService, RoleService>();

            // GENERIC
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
