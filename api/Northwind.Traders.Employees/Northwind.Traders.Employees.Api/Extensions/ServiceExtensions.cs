using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Traders.Employees.DataAccess.IRepositories;
using Northwind.Traders.Employees.DataAccess.Repositories;
using Northwind.Traders.Employees.DataAccess.Wrapper;
using Northwind.Traders.Employees.Infrastructure.IServices;
using Northwind.Traders.Employees.Infrastructure.Services;
using Northwind.Traders.Employees.Logging;
using Northwind.Traders.Employees.Model.Entities;

namespace Northwind.Traders.Employees.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            // CORS (Cross-Origin Resource Sharing) is a mechanism that gives rights to the user to access resources from the server on a different domain.
            // Because we will use React as a client-side on a different domain than the server’s domain, configuring CORS is mandatory.
            // Is not a security feature, CORS relaxes security. An API is not safer by allowing CORS. 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<INLogManager, NLogManager>();
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            // Configure DbContext with Scoped lifetime   
            services.AddDbContext<northwindtradersContext>(options =>
            {
                options.UseNpgsql("Server=localhost; Database=northwind-traders;User Id=postgres; Password=admin;");
                //options.UseNpgsql(configuration.GetConnectionString("ManagementConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void  ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
