using HealthcareSystem.Business.Abstracts;
using HealthcareSystem.Business.Service;
using HealthcareSystem.Infrastructure.Abstracts;
using HealthcareSystem.Infrastructure.Repositories;
using HealthcareSystem.Infrastructure.UnitOfWork;

namespace HeathcareSystem
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddScoped<IPatientService, PatientService>();

            return services;
        }
    }
}
