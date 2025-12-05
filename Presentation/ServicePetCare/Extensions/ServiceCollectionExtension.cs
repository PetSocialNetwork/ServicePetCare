using FluentValidation;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using ServicePetCare.WebApi.Filters;
using ServicePetCare.Domain.Interfaces;
using ServicePetCare.DataEntityFramework;
using ServicePetCare.DataEntityFramework.Repositories;
using ServicePetCare.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ServicePetCare.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            services.AddApplicationComponents(configuration);
        }

        public static void ConfigureMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddControllers(options =>
            {
                //options.Filters.Add<CentralizedExceptionHandlingFilter>();
            });

            services.AddFluentValidationAutoValidation();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PetCareService", Version = "v1" });
            });

            services.AddHttpClient();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void AddApplicationComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddDomainServices();
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped(typeof(IRepositoryEF<>), typeof(EFRepository<>));
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<IDogWalkingServiceRepository, DogWalkingServiceRepository>();
        }

        private static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<PetCareService>();
            services.AddScoped<TypeService>();
            services.AddScoped<DogWalkingService>();
            services.AddScoped<DogWalkingFactory>();
        }
    }
}
