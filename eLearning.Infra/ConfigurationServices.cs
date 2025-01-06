using eLearning.Domain.Repository;
using eLearning.Infra.Data;
using eLearning.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Infra
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
