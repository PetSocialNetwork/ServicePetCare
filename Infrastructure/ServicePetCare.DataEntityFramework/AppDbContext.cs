using Microsoft.EntityFrameworkCore;
using ServicePetCare.Domain.Entities;

namespace ServicePetCare.DataEntityFramework
{
    public class AppDbContext : DbContext
    {
        DbSet<Service> Services => Set<Service>();
        DbSet<ServiceType> ServiceTypes => Set<ServiceType>();
        DbSet<DogWalking> DogWalkingServices => Set<DogWalking>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
