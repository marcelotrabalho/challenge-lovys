using challenge_lovys_application;
using challenge_lovys_application.Interfaces;
using challenge_lovys_repository.Context;
using challenge_lovys_repository.Interfaces;
using challenge_lovys_repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace challenge_lovys_ioc
{
    public class ServicesMiddleware
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Entity Framework in Memory
            services.AddDbContext<LovysContext>(
                options => options.UseInMemoryDatabase("LovysContext")
                );

            // Configure the Dependency Injection
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IBaseScheduleApplication, ScheduleApplication>();
            services.AddTransient<IAvailableTimesRepository, AvailableTimesRepository>();
        }
    }
}
