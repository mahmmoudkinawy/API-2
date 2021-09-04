using API.Data;
using API.Interfaces;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, 
            IConfiguration config)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
