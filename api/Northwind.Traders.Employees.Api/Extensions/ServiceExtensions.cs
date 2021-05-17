using Microsoft.Extensions.DependencyInjection;
using Northwind.Traders.Employees.Api.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
