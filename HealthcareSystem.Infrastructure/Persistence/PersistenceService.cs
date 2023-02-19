using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthcareSystem.Infrastructure.Persistence
{
    public static class PersistenceService
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlite(configuration.GetConnectionString("HealthcareSystem")));
        }
    }
}